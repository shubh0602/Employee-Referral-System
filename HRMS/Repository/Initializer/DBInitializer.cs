using HRMS.Models;
using HRMS.Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRMS.Repository.Initializer
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<HRMSContext>
    {
        //protected override void Seed(HRMSContext context)
        //{
        //    Job stud = new Job()
        //    {
        //        JobTitle = "My 1st Job",
        //        Experience = new Experience
        //        {
        //            MinExperience = 2,
        //            MaxExperience = 8
        //        },
        //        IsSalaryDisclosed = false,
        //        JobDescription = "This is a test description for the 1st job.... Awesome!",
        //        Salary = new Salary { MaxSalary = 1000000, MinSalary = 500000 },
        //        Tags = new List<Tag> { new Tag { TagName = "ASP.NET" }, new Tag { TagName = "OOJS" } },
        //        Designation = new Designation { DesignationName = "Developer" }
        //    };

        //    //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "ALTER DATABASE [" + context.Database.Connection.Database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");

        //    context.Jobs.Add(stud);

        //    base.Seed(context);
        //}
    }
}