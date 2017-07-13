using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("Permanent")]
    public class Permanent
    {
        public Permanent()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermanentID { get; set; }

        public DateTime? DateCreated { get; set; }
        public decimal CurrentSalary {get;set;}
        public decimal CurrentBonus {get;set;}
        public decimal CurrentIncentives {get;set;}
        public decimal RequiredSalary { get;set;}
        public decimal RequiredBonus { get;set;}
        public decimal RequiredIncentives { get;set;}

        
    }
}