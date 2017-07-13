using CV_Generator.Entities;
using CV_Generator.Models;
using Rotativa;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CV_Generator.Controllers
{
    public class CandidateListController : Controller
    {
        [Authorize(Roles = "Admin, KhonoApprover, OptimApprover, KhonoReviewer, OptimReviewer")]
        // GET: CandidateList
        public ActionResult Index()
        {
            CV_ViewModel cvModel = new CV_ViewModel();

            using (ApplicationDbContext data = new ApplicationDbContext())
            {
               
                var CandicateResults = from a in data.Candidates  select a;
                
                cvModel.CandidateList = CandicateResults.ToList<Candidate>();
                
            }
            
            return View("Index", cvModel);
        }


        [Authorize(Roles = "Admin, KhonoApprover, OptimApprover, KhonoReviewer, OptimReviewer")]
        public ActionResult PopulateCV(int id, string ButtonName, CV_ViewModel cvModel)
        {
            if (ButtonName == "Generate Khonology CV")
            {
                using (ApplicationDbContext data = new ApplicationDbContext())
                {
                    var CandicateResults = (from a in data.Candidates
                                        .Include("CompanyOne.Comp1ResponsibilityList")
                                        .Include("CompanyTwo.Comp2ResponsibilityList")
                                        .Include("SkillList")
                                        .Include("AchievementList")
                                        .Include("StrengthList")
                                        .Include("LanguageList")
                                        .Include("ReferenceList")
                                        .Include("QualificationList")
                                        .Include("WorkExperience_SummaryList")
                                        .Include("CompanyOne")
                                        .Include("CompanyTwo")
                                        .Include("PermanentPosition")
                                        .Include("ContractPosition")
                                            where a.CandidateID == id
                                            select a).SingleOrDefault();

                    //return View("Khonology", CandicateResults);
                    return new Rotativa.ViewAsPdf("Khonology", CandicateResults);
                }
            }
            else if(ButtonName == "Generate Optim CV")
            {
                using (ApplicationDbContext data = new ApplicationDbContext())
                {
                    var CandicateResults = (from a in data.Candidates
                                        .Include("CompanyOne.Comp1ResponsibilityList")
                                        .Include("CompanyTwo.Comp2ResponsibilityList")
                                        .Include("SkillList")
                                        .Include("AchievementList")
                                        .Include("StrengthList")
                                        .Include("LanguageList")
                                        .Include("ReferenceList")
                                        .Include("QualificationList")
                                        .Include("WorkExperience_SummaryList")
                                        .Include("CompanyOne")
                                        .Include("CompanyTwo")
                                        .Include("PermanentPosition")
                                        .Include("ContractPosition")
                                            where a.CandidateID == id
                                            select a).SingleOrDefault();


                    //return View("Optim", CandicateResults);
                    return new Rotativa.ViewAsPdf("Optim", CandicateResults);
                    
                }
            }
            else if(ButtonName == "Submit Review")
            {
                
                using (ApplicationDbContext data = new ApplicationDbContext())
                {
                    var candidate = (from a in data.Candidates where a.CandidateID == id select a).SingleOrDefault();

                    candidate.isReviewed = cvModel.isReviewed;
                    data.Entry(candidate).Property(m => m.isReviewed).IsModified = true;

                    data.SaveChanges();

                    var CandicateResults = from a in data.Candidates select a;

                    cvModel.CandidateList = CandicateResults.ToList<Candidate>();
                }

                return View("Index", cvModel);
            }
            else
            {
                

                using (ApplicationDbContext data = new ApplicationDbContext())
                {
                    var candidate = (from a in data.Candidates where a.CandidateID == id select a).SingleOrDefault();

                    candidate.isApproved = cvModel.isApproved;
                    data.Entry(candidate).Property(m => m.isApproved).IsModified = true;

                    data.SaveChanges();

                    var CandicateResults = from a in data.Candidates select a;

                    cvModel.CandidateList = CandicateResults.ToList<Candidate>();
                }

                return View("Index", cvModel);
            }
        }

        //public ActionResult Khonology(int id)
        //{
        //    using (ApplicationDbContext data = new ApplicationDbContext())
        //    {
        //        var CandicateResults = (from a in data.Candidates
        //                            .Include("CompanyOne.Comp1ResponsibilityList")
        //                            .Include("CompanyTwo.Comp2ResponsibilityList")
        //                            .Include("SkillList")
        //                            .Include("AchievementList")
        //                            .Include("StrengthList")
        //                            .Include("LanguageList")
        //                            .Include("ReferenceList")
        //                            .Include("QualificationList")
        //                            .Include("WorkExperience_SummaryList")
        //                            .Include("CompanyOne")
        //                            .Include("CompanyTwo")
        //                            .Include("PermanentPosition")
        //                            .Include("ContractPosition")
        //                                where a.CandidateID == id
        //                                select a).SingleOrDefault();

        //        return View("Khonology",CandicateResults);
        //    }
        //}

        //public ActionResult PrintKhonology()
        //{
        //    return new ActionAsPdf("Khonology") { FileName="khono.pdf"};
        //}
    }
}