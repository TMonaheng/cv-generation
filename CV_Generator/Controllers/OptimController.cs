using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using CV_Generator.Entities;
using CV_Generator.Models;

namespace CV_Generator.Controllers
{
    public class OptimController : Controller
    {

        public ActionResult Index(CV_ViewModel cvModel, int id)
        {
            using (ApplicationDbContext data = new ApplicationDbContext())
            {

                var CandicateResults = (from a in data.Candidates where a.CandidateID == id select a).SingleOrDefault();
                var SkillsResults = from a in data.Skill where a.CandidateID == id select a;
                var AchievementsResults = from a in data.Achievement where a.CandidateID == id select a;
                var StrengthsResults = from a in data.Strength where a.CandidateID == id select a;
                var LanguagesResults = from a in data.Language where a.CandidateID == id select a;
                var ReferencesResults = from a in data.Reference where a.CandidateID == id select a;
                var QualificationsResults = from a in data.Qualification where a.CandidateID == id select a;
                var WorkExperienceSummaryResults = from a in data.WorkExperienceSummary where a.CandidateID == id select a;

                var ContractResults = (from a in data.Contract where a.ContractID == CandicateResults.ContractID select a).SingleOrDefault();
                var PermanentResults = (from a in data.Permanent where a.PermanentID == CandicateResults.PermanentID select a).SingleOrDefault();

                var Company1Results = (from a in data.WorkExperienceDetailed_CompanyOne where a.Company1WorkExpDetID == CandicateResults.Company1WorkExpDetID select a).SingleOrDefault();
                var Company1ResponsibilityResults = from a in data.Company1Responsibility where a.Company1WorkExpDetID == Company1Results.Company1WorkExpDetID select a;

                var Company2Results = (from a in data.WorkExperienceDetailed_CompanyTwo where a.Company2WorkExpDetID == CandicateResults.Company2WorkExpDetID select a).SingleOrDefault();
                var Company2ResponsibilityResults = from a in data.Company2Responsibility where a.Company2WorkExpDetID == Company2Results.Company2WorkExpDetID select a;

                cvModel.FirstName = CandicateResults.FirstName;
                cvModel.LastName = CandicateResults.LastName;
                cvModel.CountryOfBirth = CandicateResults.CountryOfBirth;
                cvModel.BEEStatus = CandicateResults.BEEStatus;
                cvModel.Gender = CandicateResults.Gender;
                cvModel.ProfileStatement = CandicateResults.ProfileStatement;
                cvModel.CommencementAvailability = CandicateResults.CommencementAvailability;
                cvModel.Disclosures = CandicateResults.Disclosures;
                cvModel.Comments = CandicateResults.Comments;
                cvModel.LeavePlanned = CandicateResults.LeavePlanned;
                cvModel.LeavePlannedDate = CandicateResults.LeavePlannedDate;
                cvModel.IDNumber = CandicateResults.IDNumber;

                //cvModel.ContractPosition = new Contract();
                cvModel.ContractPosition = ContractResults;

                //cvModel.PermanentPosition = new Permanent();
                cvModel.PermanentPosition = PermanentResults;

                cvModel.CompanyOne = new WorkExperienceDetailed_CompanyOne();
                cvModel.CompanyOne = Company1Results;
                cvModel.Comp1ResponsibilityList = new List<Company1Responsibility>();
                cvModel.Comp1ResponsibilityList = Company1ResponsibilityResults.ToList();

                cvModel.CompanyTwo = new WorkExperienceDetailed_CompanyTwo();
                cvModel.CompanyTwo = Company2Results;
                cvModel.Comp2ResponsibilityList = new List<Company2Responsibility>();
                cvModel.Comp2ResponsibilityList = Company2ResponsibilityResults.ToList();

                cvModel.SkillList = new List<Skill>();
                cvModel.SkillList = SkillsResults.ToList();

                cvModel.WorkExperience_SummaryList = new List<WorkExperienceSummary>();
                cvModel.WorkExperience_SummaryList = WorkExperienceSummaryResults.ToList();

                cvModel.AchievementList = new List<Achievement>();
                cvModel.AchievementList = AchievementsResults.ToList();

                cvModel.LanguageList = new List<Language>();
                cvModel.LanguageList = LanguagesResults.ToList();

                cvModel.StrengthList = new List<Strength>();
                cvModel.StrengthList = StrengthsResults.ToList();

                cvModel.QualificationList = new List<Qualification>();
                cvModel.QualificationList = QualificationsResults.ToList();

                cvModel.ReferenceList = new List<Reference>();
                cvModel.ReferenceList = ReferencesResults.ToList();
            }

            return View("Khono", cvModel);
        }
    }
}
