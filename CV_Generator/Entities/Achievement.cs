using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Generator.Entities
{
    [Table("Achievement")]
    public class Achievement
    {
        public Achievement()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AchievementID { get; set; }

        public DateTime? DateCreated { get; set; }
        public string Description { get; set; }

        public int CandidateID { get; set; }

        [ForeignKey("CandidateID")]
        public virtual Candidate Candidate { get; set; }
    }
}