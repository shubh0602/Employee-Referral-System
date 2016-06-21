using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    [Table("Job")]
    public class Job
    {
        public Job()
        {
            CreateDate = DateTime.Now;
        }
        [Key]
        public int JobId { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public List<Tag> Tags { get; set; }

        public bool IsSalaryDisclosed { get; set; }

        public Salary Salary { get; set; }

        public Experience Experience { get; set; }

        public Designation Designation { get; set; }

        [Required]
        public string JobDescription { get; set; }

        public List<Requirement> JobRequirements { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public DateTime CreateDate { get; set; }
    }
}