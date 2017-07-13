using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //for [Key]
using System.ComponentModel.DataAnnotations.Schema; //For Table and Database
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("Qualification")]
    public class Qualification
    {
        public Qualification()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QualificationID { get; set; }
        public DateTime? DateCreated { get; set; }
        public string QualificationName { get; set; }
        public string Institution { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? YearCompleted { get; set; }

        public int CandidateID { get; set; }

        [ForeignKey("CandidateID")]
        public virtual Candidate Candidate { get; set; }

    }
}