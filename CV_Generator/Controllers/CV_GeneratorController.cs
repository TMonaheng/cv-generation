using CV_Generator.Entities;
using CV_Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CV_Generator.Controllers
{
    public class CV_GeneratorController : Controller
    {
        // GET: CV_Generator
        public ActionResult Index()
        {
            CV_ViewModel cvModel = new CV_ViewModel();

            
            return View(cvModel);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult GenerateCV()
        {
            return View();
        }

        public ActionResult SaveData(CV_ViewModel cvModel, string ButtonName)
        {
            if (Session["Strengths"] != null)
            {
                cvModel.StrengthList = new List<Strength>();
                cvModel.StrengthList.AddRange((List<Strength>)Session["Strengths"]);
            }

            if (Session["Achievements"] != null)
            {
                cvModel.AchievementList = new List<Achievement>();
               cvModel.AchievementList.AddRange((List<Achievement>)Session["Achievements"]);
            }

            if (Session["Skills"] != null)
            {
                cvModel.SkillList = new List<Skill>();
                cvModel.SkillList.AddRange((List<Skill>)Session["Skills"]);
            }

            if (Session["Languages"] != null)
            {
                cvModel.LanguageList = new List<Language>();
                cvModel.LanguageList.AddRange((List<Language>)Session["Languages"]);
            }

            if (Session["Qualifications"] != null)
            {
                cvModel.QualificationList = new List<Qualification>();
                cvModel.QualificationList.AddRange((List<Qualification>)Session["Qualifications"]);
            }

            if (Session["WorkExperiences_Summary"] != null)
            {
                cvModel.WorkExperience_SummaryList = new List<WorkExperienceSummary>();
                cvModel.WorkExperience_SummaryList.AddRange((List<WorkExperienceSummary>)Session["WorkExperiences_Summary"]);
            }

            if (Session["Comp1Responsibilities"] != null)
            {
                cvModel.Comp1ResponsibilityList = new List<Company1Responsibility>();
                cvModel.Comp1ResponsibilityList.AddRange((List<Company1Responsibility>)Session["Comp1Responsibilities"]);
            }

            if (Session["Comp2Responsibilities"] != null)
            {
                cvModel.Comp2ResponsibilityList = new List<Company2Responsibility>();
                cvModel.Comp2ResponsibilityList.AddRange((List<Company2Responsibility>)Session["Comp2Responsibilities"]);
            }

            if (Session["References"] != null)
            {
                cvModel.ReferenceList = new List<Reference>();
                cvModel.ReferenceList.AddRange((List<Reference>)Session["References"]);
            }

            if (ButtonName == "Add Strength to List")
            {
                if(cvModel.StrengthList == null)
                {
                    cvModel.StrengthList = new List<Strength>();
                    cvModel.StrengthList.Add(cvModel.SingleStrength);
                    Session["Strengths"] = cvModel.StrengthList;
                    cvModel.SingleStrength = new Strength();
                    return View("Index", cvModel);
                }
                else
                {
                    cvModel.StrengthList.Add(cvModel.SingleStrength);
                    Session["Strengths"] = cvModel.StrengthList;
                    cvModel.SingleStrength = new Strength();
                    return View("Index", cvModel);
                }
                
            }
            else if(ButtonName == "Add Achievement to List")
            {
                if(cvModel.AchievementList == null)
                {
                    cvModel.AchievementList = new List<Achievement>();
                    cvModel.AchievementList.Add(cvModel.SingleAchievement);
                    Session["Achievements"] = cvModel.AchievementList;
                    cvModel.SingleAchievement = new Achievement();
                    return View("Index", cvModel);
                }
                else
                {
                    cvModel.AchievementList.Add(cvModel.SingleAchievement);
                    Session["Achievements"] = cvModel.AchievementList;
                    cvModel.SingleAchievement = new Achievement();
                    return View("Index", cvModel);
                }
 
            }
            else if (ButtonName == "Add Skill to List")
            {
                if (cvModel.SkillList == null)
                {
                    cvModel.SkillList = new List<Skill>();
                    cvModel.SkillList.Add(cvModel.SingleSkill);
                    Session["Skills"] = cvModel.SkillList;
                    cvModel.SingleSkill = new Skill();
                    return View("Index", cvModel);
                }
                else
                {
                    cvModel.SkillList.Add(cvModel.SingleSkill);
                    Session["Skills"] = cvModel.SkillList;
                    cvModel.SingleSkill = new Skill();
                    return View("Index", cvModel);
                }
 
            }
            else if (ButtonName == "Add Language to List")
            {

                if (cvModel.LanguageList == null)
                {
                    cvModel.LanguageList = new List<Language>();
                    cvModel.LanguageList.Add(cvModel.SingleLanguage);
                    Session["Languages"] = cvModel.LanguageList;
                    cvModel.SingleLanguage = new Language();
                    return View("Index", cvModel);
                }
                else
                {
                    cvModel.LanguageList.Add(cvModel.SingleLanguage);
                    Session["Languages"] = cvModel.LanguageList;
                    cvModel.SingleLanguage = new Language();
                    return View("Index", cvModel);
                }     
                
            }
            else if (ButtonName == "Add Qualification to List")
            {
                if (cvModel.QualificationList == null)
                {
                    cvModel.QualificationList = new List<Qualification>();
                    cvModel.QualificationList.Add(cvModel.SingleQualification);
                    Session["Qualifications"] = cvModel.QualificationList;
                    cvModel.SingleQualification = new Qualification();
                    return View("Index", cvModel);
                }
                else
                {
                    cvModel.QualificationList.Add(cvModel.SingleQualification);
                    Session["Qualifications"] = cvModel.QualificationList;
                    cvModel.SingleQualification = new Qualification();
                    return View("Index", cvModel);
                }

            }
            else if (ButtonName == "Add Summary to List")
            {
                if (cvModel.WorkExperience_SummaryList == null)
                {
                    cvModel.WorkExperience_SummaryList = new List<WorkExperienceSummary>();
                    cvModel.WorkExperience_SummaryList.Add(cvModel.SingleWorkExperience_Summary);
                    Session["WorkExperiences_Summary"] = cvModel.WorkExperience_SummaryList;
                    cvModel.SingleWorkExperience_Summary = new WorkExperienceSummary();
                    return View("Index", cvModel);
                }
                else
                {
                    cvModel.WorkExperience_SummaryList.Add(cvModel.SingleWorkExperience_Summary);
                    Session["WorkExperiences_Summary"] = cvModel.WorkExperience_SummaryList;
                    cvModel.SingleWorkExperience_Summary = new WorkExperienceSummary();
                    return View("Index", cvModel);
                }
    
            }
            else if (ButtonName == "Add CO.1 Responsibility to List")
            {
                if (cvModel.Comp1ResponsibilityList == null)
                {
                    cvModel.Comp1ResponsibilityList = new List<Company1Responsibility>();
                    cvModel.Comp1ResponsibilityList.Add(cvModel.Comp1SingleResponsibility);
                    Session["Comp1Responsibilities"] = cvModel.Comp1ResponsibilityList;
                    cvModel.Comp1SingleResponsibility = new Company1Responsibility();
                    return View("Index", cvModel);
                }
                else
                {
                    cvModel.Comp1ResponsibilityList.Add(cvModel.Comp1SingleResponsibility);
                    Session["Comp1Responsibilities"] = cvModel.Comp1ResponsibilityList;
                    cvModel.Comp1SingleResponsibility = new Company1Responsibility();
                    return View("Index", cvModel);
                }

            }
            else if (ButtonName == "Add CO.2 Responsibility to List")
            {
                if (cvModel.Comp2ResponsibilityList == null)
                {
                    cvModel.Comp2ResponsibilityList = new List<Company2Responsibility>();
                    cvModel.Comp2ResponsibilityList.Add(cvModel.Comp2SingleResponsibility);
                    Session["Comp2Responsibilities"] = cvModel.Comp2ResponsibilityList;
                    cvModel.Comp2SingleResponsibility = new Company2Responsibility();
                    return View("Index", cvModel);
                }
                else
                {
                    cvModel.Comp2ResponsibilityList.Add(cvModel.Comp2SingleResponsibility);
                    Session["Comp2Responsibilities"] = cvModel.Comp2ResponsibilityList;
                    cvModel.Comp2SingleResponsibility = new Company2Responsibility();
                    return View("Index", cvModel);
                }

            }
            
            else if (ButtonName == "Add Reference to List")
            {
                if (cvModel.ReferenceList == null)
                {
                    cvModel.ReferenceList = new List<Reference>();
                    cvModel.ReferenceList.Add(cvModel.SingleReference);
                    Session["References"] = cvModel.ReferenceList;
                    cvModel.SingleReference = new Reference();
                    return View("Index", cvModel);
                }
                else
                {
                    cvModel.ReferenceList.Add(cvModel.SingleReference);
                    Session["References"] = cvModel.ReferenceList;
                    cvModel.SingleReference = new Reference();
                    return View("Index", cvModel);
                }

            }
            else if (ButtonName == "Save Profile")
            {
                
                using (ApplicationDbContext data = new ApplicationDbContext())
                {
                    Candidate candidate = new Candidate();
                    
                    candidate.FirstName = cvModel.FirstName;
                    candidate.LastName = cvModel.LastName;
                    candidate.IDNumber = cvModel.IDNumber;
                    candidate.PhoneNumber = cvModel.PhoneNumber;
                    candidate.Email = cvModel.Email;
                    candidate.CountryOfBirth = cvModel.CountryOfBirth;
                    candidate.BEEStatus = cvModel.BEEStatus;
                    candidate.Gender = cvModel.Gender;
                    candidate.ProfileStatement = cvModel.ProfileStatement;
                    candidate.StrengthList = cvModel.StrengthList;
                    candidate.AchievementList = cvModel.AchievementList;
                    candidate.SkillList = cvModel.SkillList;
                    candidate.LanguageList = cvModel.LanguageList;
                    candidate.QualificationList = cvModel.QualificationList;
                    candidate.WorkExperience_SummaryList = cvModel.WorkExperience_SummaryList;
                  
                    candidate.ReferenceList = cvModel.ReferenceList;

                    candidate.PermanentPosition = cvModel.PermanentPosition;
                    candidate.ContractPosition = cvModel.ContractPosition;
                    candidate.wasPermanent = cvModel.wasPermanent;

                    candidate.CommencementAvailability = cvModel.CommencementAvailability;
                    candidate.LeavePlanned = cvModel.LeavePlanned;
                    candidate.LeavePlannedDate = cvModel.LeavePlannedDate;
                    candidate.Disclosures = cvModel.Disclosures;
                    candidate.Comments = cvModel.Comments;

                    candidate.CompanyOne = cvModel.CompanyOne;
                    candidate.CompanyTwo = cvModel.CompanyTwo;

                    candidate.CompanyOne.Comp1ResponsibilityList = cvModel.Comp1ResponsibilityList;
                    candidate.CompanyTwo.Comp2ResponsibilityList = cvModel.Comp2ResponsibilityList;

                    if(candidate.IDNumber == null)   
                    {
                        TempData["Incomplete"] = true;
                    }

                    data.Candidates.Add(candidate);

                    data.SaveChanges();
                    
                   
                }
                return View("Index", cvModel);
            }
            else
            {
                return View("Index", cvModel);
            }
             
            
        }

        //
        // POST: /Account/Register
        [HttpPost]
        public ActionResult GenerateCV(CV_ViewModel model)
        {
            if (ModelState.IsValid)
            {
                

               
            }

            
            return View(model);
        }
    }
}