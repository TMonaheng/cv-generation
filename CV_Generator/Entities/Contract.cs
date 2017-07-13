using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("Contract")]
    public class Contract
    {
        public Contract()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractID { get; set; }

        public DateTime? DateCreated { get; set; }
        public decimal CurrentHourlyRate { get; set; }
        public decimal RequiredHourlyRate { get; set; }

        
    }
}