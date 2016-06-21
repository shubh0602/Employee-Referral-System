namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(nullable: false),
                        IsSalaryDisclosed = c.Boolean(nullable: false),
                        MinSalary = c.Long(nullable: false),
                        MaxSalary = c.Long(nullable: false),
                        JobDescription = c.String(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreateDate = c.DateTime(nullable: false),
                        Designation_DesignationId = c.Int(),
                        Experience_ExperienceId = c.Int(),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Designations", t => t.Designation_DesignationId)
                .ForeignKey("dbo.Experiences", t => t.Experience_ExperienceId)
                .Index(t => t.Designation_DesignationId)
                .Index(t => t.Experience_ExperienceId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        MinExperience = c.Int(nullable: false),
                        MaxExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceId);
            
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        RequirementId = c.Int(nullable: false, identity: true),
                        RequirementDesc = c.String(),
                        Job_JobId = c.Int(),
                    })
                .PrimaryKey(t => t.RequirementId)
                .ForeignKey("dbo.Job", t => t.Job_JobId)
                .Index(t => t.Job_JobId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        Job_JobId = c.Int(),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.Job", t => t.Job_JobId)
                .Index(t => t.Job_JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Job_JobId", "dbo.Job");
            DropForeignKey("dbo.Requirements", "Job_JobId", "dbo.Job");
            DropForeignKey("dbo.Job", "Experience_ExperienceId", "dbo.Experiences");
            DropForeignKey("dbo.Job", "Designation_DesignationId", "dbo.Designations");
            DropIndex("dbo.Tags", new[] { "Job_JobId" });
            DropIndex("dbo.Requirements", new[] { "Job_JobId" });
            DropIndex("dbo.Job", new[] { "Experience_ExperienceId" });
            DropIndex("dbo.Job", new[] { "Designation_DesignationId" });
            DropTable("dbo.Tags");
            DropTable("dbo.Requirements");
            DropTable("dbo.Experiences");
            DropTable("dbo.Designations");
            DropTable("dbo.Job");
        }
    }
}
