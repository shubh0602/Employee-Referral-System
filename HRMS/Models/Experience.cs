using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRMS.Models
{
    public class Experience
    {
        [Column("ExperienceId")]
        public int ExperienceId { get; set; }
        [Column("MinExperience")]
        public int MinExperience { get; set; }
        [Column("MaxExperience")]
        public int MaxExperience { get; set; }
    }
}
