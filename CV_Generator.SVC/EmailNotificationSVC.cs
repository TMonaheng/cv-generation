using System;
using System.Collections.Generic;

using System.Data;

using System.IO;

using System.Net.Mail;
using System.Net.Mime;
using System.ServiceProcess;
using System.Text;
using System.Timers;

using System.Data.SqlClient;


namespace CV_Generator.SVC
{
    public partial class EmailNotificationSVC : ServiceBase
    {
       
        private Timer serviceTimer;

        
 
        public EmailNotificationSVC()
        {
            InitializeComponent();
            serviceTimer = new System.Timers.Timer();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            
            serviceTimer.Interval = 30000;
            serviceTimer.Elapsed += new ElapsedEventHandler(ServiceTimer_Tick);
            serviceTimer.Enabled = true;
        }

        protected override void OnStop()
        {
            
            serviceTimer.AutoReset = false;
            serviceTimer.Enabled = false;
            serviceTimer.Stop();
        }

        private static void createTextFile(string text, string fileName)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\" + fileName +".txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();
            }
            catch
            {
                
            }
        }

        private static void SendEmail(string receiverEmail, string subject, string message)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("pdzimbanete@gmail.com", "pd7445264");
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 200000;
                MailMessage mailMessage = new MailMessage();
                ContentType htmlType = new ContentType("text/html");

              

                mailMessage.BodyEncoding = Encoding.Default;
                mailMessage.To.Add(receiverEmail);
                mailMessage.From = new MailAddress("pdzimbanete@gmail.com");
                mailMessage.Priority = MailPriority.High;
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(message, htmlType);
                smtpClient.Send(mailMessage);
                createTextFile("Mail sent successfully", "EmailSuccess");
            }
            catch(Exception ex)
            {
                createTextFile(ex.Message, "EmailError");
            }
            
        }

        private List<CandidateUpdate> GenerateCandidateList()
        {
            List<CandidateUpdate> candidateList = new List<CandidateUpdate>();

            string connectionString = @"Data Source=TRAINING12-PC\SQLEXPRESS;Initial Catalog=CV_Generator;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataReader reader = null;

            string sqlCommandString = "SELECT * FROM Candidate";

            try
            {
                connection.Open();
                command = new SqlCommand(sqlCommandString, connection);
                command.ExecuteNonQuery();

                reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    
                    count++;
                    int id = (int)reader["CandidateID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string idNumber = (string)reader["IDNumber"];
                    bool reviewed = (bool)reader["isReviewed"];
                    bool approved = (bool)reader["isApproved"];
                    bool emailSent = (bool)reader["emailSent"];

                    CandidateUpdate candidate = new CandidateUpdate(id,firstName, lastName, idNumber, reviewed, approved, emailSent);

                    candidateList.Add(candidate);
                }

                

            }
            catch (Exception ex)
            {
                createTextFile(ex.Message, "SQL_Error");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return candidateList;
        }

        private void ServiceTimer_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            string notification;

            List<CandidateUpdate> candidateList = new List<CandidateUpdate>();
            candidateList = GenerateCandidateList();
            
            
            string connectionString = @"Data Source=TRAINING12-PC\SQLEXPRESS;Initial Catalog=CV_Generator;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            

            foreach (CandidateUpdate cand in candidateList)
            {
                if(cand.reviewed == true && cand.approved == true)
                {
                    if(cand.emailSent == false)
                    {
                        notification = "Good day \n This is a notification that the profile of candidate, " + cand.firstName + " " + cand.lastName
                                     + " (" + cand.idNumber + "), has been reviewed and approved";
                        SendEmail("philani.dzimbanete@khonology.co.za", "Subject", notification);

                        try
                        {
                            SqlCommand command = connection.CreateCommand();
                            command.CommandText = @"UPDATE Candidate SET emailSent=@EmailWasSent WHERE CandidateID=@id";
                            command.Parameters.Add("@EmailWasSent", SqlDbType.Bit);
                            command.Parameters["@EmailWasSent"].Value = true;
                            command.Parameters.Add("@id", SqlDbType.Int);
                            command.Parameters["@id"].Value = cand.id;

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            createTextFile(ex.Message, "SQL_Error");
                        }
                        finally
                        {
                            if (connection != null)
                            {
                                connection.Close();
                            }
                        }
                    }
                }
                
            }

            

            

            //command.Parameters.AddWithValue("@emailSent", true);
            //command.ExecuteNonQuery();
            //createTextFile("Candidate " + firstName + "updated", "UpdateReport for " + firstName);

        }

       
    }
}
