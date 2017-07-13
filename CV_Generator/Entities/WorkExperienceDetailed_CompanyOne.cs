using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("CompanyOne_WorkExperienceDetailed")]
    public class WorkExperienceDetailed_CompanyOne
    {
        public WorkExperienceDetailed_CompanyOne()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Company1WorkExpDetID { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? EndDate { get; set; }

        public string ReasonForLeaving { get; set; }

        public virtual List<Company1Responsibility> Comp1ResponsibilityList { get; set; }
    }
}