using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("Company1Responsibility")]
    public class Company1Responsibility
    {
        public Company1Responsibility()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponsibilityID { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Description { get; set; }

        
        public int Company1WorkExpDetID { get; set; }

        [ForeignKey("Company1WorkExpDetID")]
        public virtual WorkExperienceDetailed_CompanyOne WorkExperienceDetailed_CompanyOne { get; set; }
    }
}