using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRMS.Models
{
    public class Salary
    {
        [Column("MinSalary")]
        public Int64 MinSalary { get; set; }
        [Column("MaxSalary")]
        public Int64 MaxSalary { get; set; }
    }
}
