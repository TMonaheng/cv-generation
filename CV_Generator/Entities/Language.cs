using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("Language")]
    public class Language
    {
        public Language()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageID { get; set; }

        public DateTime? DateCreated { get; set; }
        public string LanguageName { get; set; }
        public string SpeakProficiency { get; set; }
        public string ReadProficiency {get;set;}
        public string WriteProficiency {get;set;}

        public int CandidateID { get; set; }

        [ForeignKey("CandidateID")]
        public virtual Candidate Candidate { get; set; }
    }
}