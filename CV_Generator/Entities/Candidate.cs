using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("Candidate")]
    public class Candidate
    {
        public Candidate()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateID { get; set; }

        //[Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }

        

        public string Email {get;set;}
        public string IDNumber {get;set;}
        public string PhoneNumber {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string CountryOfBirth {get;set;}
        public string BEEStatus {get;set;}
        public string Gender {get;set;}
        public string ProfileStatement {get;set;}
        
        public string CommencementAvailability {get;set;}
        public string LeavePlanned {get;set;}

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? LeavePlannedDate {get;set;}

        public string Disclosures {get;set;}
        public string Comments {get;set;}

        public bool wasPermanent { get; set; }

        public bool isApproved { get; set; }
        public bool isReviewed { get; set; }
        public bool emailSent { get; set; }

        public int? PermanentID { get; set; }
        [ForeignKey("PermanentID")]
        public virtual Permanent PermanentPosition { get; set; }

        public int? ContractID { get; set; }
        [ForeignKey("ContractID")]
        public virtual Contract ContractPosition { get; set; }
        
        public int? Company1WorkExpDetID { get; set; }
        [ForeignKey("Company1WorkExpDetID")]
        public virtual WorkExperienceDetailed_CompanyOne CompanyOne { get; set; }

        public int? Company2WorkExpDetID { get; set; }
        [ForeignKey("Company2WorkExpDetID")]
        public virtual WorkExperienceDetailed_CompanyTwo CompanyTwo { get; set; }




        public virtual List<Strength> StrengthList { get; set; }
        public virtual List<Achievement> AchievementList { get; set; }
        public virtual List<Language> LanguageList { get; set; }
        public virtual List<Qualification> QualificationList { get; set; }
        public virtual List<Reference> ReferenceList { get; set; }
        
        public virtual List<Skill> SkillList { get; set; }
        
        public virtual List<WorkExperienceSummary> WorkExperience_SummaryList { get; set; }
    }
}