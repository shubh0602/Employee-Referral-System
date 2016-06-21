using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRMS.Models
{
    public class Designation
    {
        [Key]
        [Column("DesignationId")]
        public int DesignationId { get; set; }

        [Column("DesignationName")]
        public string DesignationName { get; set; }

        //public virtual Job Job { get; set; }
    }
}
