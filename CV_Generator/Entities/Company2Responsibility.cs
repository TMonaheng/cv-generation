using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("Company2Responsibility")]
    public class Company2Responsibility
    {
        public Company2Responsibility()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponsibilityID { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Description { get; set; }

        
        public int Company2WorkExpDetID { get; set; }

        [ForeignKey("Company2WorkExpDetID")]
        public virtual WorkExperienceDetailed_CompanyTwo WorkExperienceDetailed_CompanyTwo { get; set; }
    }
}