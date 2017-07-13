using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("CompanyTwo_WorkExperienceDetailed")]
    public class WorkExperienceDetailed_CompanyTwo
    {
        public WorkExperienceDetailed_CompanyTwo()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Company2WorkExpDetID { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? EndDate { get; set; }

        public string ReasonForLeaving { get; set; }

        

        public virtual List<Company2Responsibility> Comp2ResponsibilityList { get; set; }
    }
}