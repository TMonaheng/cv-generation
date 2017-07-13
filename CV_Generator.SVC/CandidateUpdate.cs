using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Generator.SVC
{
    class CandidateUpdate
    {
        public CandidateUpdate(int id, string fn, string ln, string idNum,bool rev, bool appr, bool emSent)
        {
            this.firstName = fn;
            this.lastName = ln;
            this.id = id;
            this.idNumber = idNum;
            this.reviewed = rev;
            this.approved = appr;
            this.emailSent = emSent;
        }
        
       public int id { get; set; }
       public string firstName { get; set; }
       public string lastName { get; set; }
       public string idNumber{get;set;}
       public bool reviewed { get; set; }
       public bool approved { get; set; }
       public bool emailSent { get; set; }
    }
}
