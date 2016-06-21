using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRMS.Repository.DatabaseContext
{
    public class HRMSContext : DbContext
    {
        public HRMSContext()
            : base()
        {

        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
    }
}