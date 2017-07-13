using CV_Generator.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Generator.Models
{
    public class CV_ViewModel
    {




        //CANDIDATE TABLE-----------------------------------------
        
        public List<Candidate> CandidateList { get; set; }

        public bool isPermanent { get; set; }

        public bool isReviewed { get; set; }
        public bool isApproved { get; set; }

        public string action { get; set; }

        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Country Of Birth")]
        public string CountryOfBirth { get; set; }

        [Display(Name = "BEE Status (Black, White, Indian, etc.)")]
        public string BEEStatus { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Profile Statement:")]
        public string ProfileStatement { get; set; }
        
        public List<Strength> StrengthList { get; set; }
        [Display(Name = "Strengths")]
        public Strength SingleStrength { get; set; }
        
        public List<Achievement> AchievementList { get; set; }
        [Display(Name = "Achievements:")]
        public Achievement SingleAchievement { get; set; }
        
        public List<Skill> SkillList { get; set; }
        [Display(Name = "Skills")]
        public Skill SingleSkill { get; set; }
        
        public List<Language> LanguageList { get; set; }
        [Display(Name = "Languages:")]
        public Language SingleLanguage { get; set; }
        
        public List<Qualification> QualificationList { get; set; }
        [Display(Name = "Qualification (Add one at a time):")]
        public Qualification SingleQualification { get; set; }

        [Display(Name = "Work Experience Summary:")]
        public List<WorkExperienceSummary> WorkExperience_SummaryList { get; set; }
        public WorkExperienceSummary SingleWorkExperience_Summary { get; set; }

        [Display(Name = "Responsibilities")]
        public List<Company1Responsibility> Comp1ResponsibilityList { get; set; }
        public Company1Responsibility Comp1SingleResponsibility { get; set; }

        [Display(Name = "Responsibilities")]
        public List<Company2Responsibility> Comp2ResponsibilityList { get; set; }
        public Company2Responsibility Comp2SingleResponsibility { get; set; }

        [Display(Name = "References")]
        public List<Reference> ReferenceList { get; set; }
        public Reference SingleReference { get; set; }

        public WorkExperienceDetailed_CompanyOne CompanyOne { get; set; }
        public WorkExperienceDetailed_CompanyTwo CompanyTwo { get; set; }

        public Contract ContractPosition { get; set; }
        public Permanent PermanentPosition { get; set; }

        [Display(Name = "Commencement Availability")]
        public string CommencementAvailability { get; set; }

        [Display(Name = "LeavePlanned")]
        public string LeavePlanned { get; set; }

        [Display(Name = "LeavePlannedDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? LeavePlannedDate { get; set; }

        [Display(Name = "Disclosures")]
        public string Disclosures { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        public bool wasPermanent { get; set; }

        [Display(Name = "Prefered Employment Type")]
        public string EmploymentType { get; set; }


        //QUALIFICATIONS TABLE---------------------------------------------



    }

    
}