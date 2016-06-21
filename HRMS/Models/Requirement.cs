using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HRMS.Models
{
    public class Requirement
    {
        [Key]
        public int RequirementId { get; set; }
        public string RequirementDesc { get; set; }
    }
}
