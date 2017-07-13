using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("Reference")]
    public class Reference
    {
        public Reference()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferenceID { get; set; }

        public DateTime? DateCreated { get; set; }
        public string Name {get;set;}
        public string CurrentPosition {get;set;}
        public string ContactNumber {get;set;}
        public string Email {get;set;}

        public int CandidateID { get; set; }

        [ForeignKey("CandidateID")]
        public virtual Candidate Candidate { get; set; }
    }
}