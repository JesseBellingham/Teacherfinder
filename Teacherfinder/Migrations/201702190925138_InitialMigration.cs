namespace Teacherfinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.aspnetUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(maxLength: 150),
                        ClaimValue = c.String(maxLength: 500),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.aspnetUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.aspnetUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.aspnetUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.aspnetUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.aspnetUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Location_LocationId = c.Int(),
                        Student_StudentId = c.Int(),
                        Teacher_TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Location", t => t.Location_LocationId)
                .ForeignKey("dbo.Student", t => t.Student_StudentId)
                .ForeignKey("dbo.Teacher", t => t.Teacher_TeacherId)
                .Index(t => t.Location_LocationId)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Teacher_TeacherId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationCity = c.String(nullable: false),
                        LocationCountry = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Lesson_LessonId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Lesson", t => t.Lesson_LessonId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.Lesson_LessonId);
            
            CreateTable(
                "dbo.Enrolment",
                c => new
                    {
                        EnrolmentId = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrolmentId)
                .ForeignKey("dbo.Lesson", t => t.LessonId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.LessonId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        LessonId = c.Int(nullable: false, identity: true),
                        LessonType_LessonTypeId = c.Int(),
                        Location_LocationId = c.Int(),
                        Teacher_TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.LessonId)
                .ForeignKey("dbo.LessonType", t => t.LessonType_LessonTypeId)
                .ForeignKey("dbo.Location", t => t.Location_LocationId)
                .ForeignKey("dbo.Teacher", t => t.Teacher_TeacherId)
                .Index(t => t.LessonType_LessonTypeId)
                .Index(t => t.Location_LocationId)
                .Index(t => t.Teacher_TeacherId);
            
            CreateTable(
                "dbo.LessonType",
                c => new
                    {
                        LessonTypeId = c.Int(nullable: false, identity: true),
                        LessonTypeCode = c.String(),
                        LessonTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.LessonTypeId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(),
                        HometownLocationId = c.Int(),
                        CurrentLocationId = c.Int(),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.aspnetUser", t => t.ApplicationUserId)
                .ForeignKey("dbo.Location", t => t.CurrentLocationId)
                .ForeignKey("dbo.Location", t => t.HometownLocationId)
                .Index(t => t.HometownLocationId)
                .Index(t => t.CurrentLocationId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.aspnetUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Instrument",
                c => new
                    {
                        InstrumentId = c.Int(nullable: false, identity: true),
                        InstrumentName = c.String(),
                        InstrumentType_InstrumentTypeId = c.Int(),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.InstrumentId)
                .ForeignKey("dbo.InstrumentType", t => t.InstrumentType_InstrumentTypeId)
                .ForeignKey("dbo.Student", t => t.Student_StudentId)
                .Index(t => t.InstrumentType_InstrumentTypeId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.InstrumentType",
                c => new
                    {
                        InstrumentTypeId = c.Int(nullable: false, identity: true),
                        InstrumentTypeCode = c.String(),
                        InstrumentTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.InstrumentTypeId);
            
            CreateTable(
                "dbo.LessonOffering",
                c => new
                    {
                        LessonOfferingId = c.Int(nullable: false, identity: true),
                        MaxEnrolments = c.Int(nullable: false),
                        Lesson_LessonId = c.Int(),
                        Location_LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.LessonOfferingId)
                .ForeignKey("dbo.Lesson", t => t.Lesson_LessonId)
                .ForeignKey("dbo.Location", t => t.Location_LocationId)
                .Index(t => t.Lesson_LessonId)
                .Index(t => t.Location_LocationId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.aspnetUserRole", "IdentityUser_Id", "dbo.aspnetUser");
            DropForeignKey("dbo.aspnetUserLogin", "IdentityUser_Id", "dbo.aspnetUser");
            DropForeignKey("dbo.aspnetUserClaim", "IdentityUser_Id", "dbo.aspnetUser");
            DropForeignKey("dbo.aspnetUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.LessonOffering", "Location_LocationId", "dbo.Location");
            DropForeignKey("dbo.LessonOffering", "Lesson_LessonId", "dbo.Lesson");
            DropForeignKey("dbo.Booking", "Teacher_TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Booking", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Instrument", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.Instrument", "InstrumentType_InstrumentTypeId", "dbo.InstrumentType");
            DropForeignKey("dbo.Enrolment", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Teacher", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Person", "HometownLocationId", "dbo.Location");
            DropForeignKey("dbo.Person", "CurrentLocationId", "dbo.Location");
            DropForeignKey("dbo.Person", "ApplicationUserId", "dbo.aspnetUser");
            DropForeignKey("dbo.Lesson", "Teacher_TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Student", "Lesson_LessonId", "dbo.Lesson");
            DropForeignKey("dbo.Lesson", "Location_LocationId", "dbo.Location");
            DropForeignKey("dbo.Lesson", "LessonType_LessonTypeId", "dbo.LessonType");
            DropForeignKey("dbo.Enrolment", "LessonId", "dbo.Lesson");
            DropForeignKey("dbo.Booking", "Location_LocationId", "dbo.Location");
            DropIndex("dbo.LessonOffering", new[] { "Location_LocationId" });
            DropIndex("dbo.LessonOffering", new[] { "Lesson_LessonId" });
            DropIndex("dbo.Instrument", new[] { "Student_StudentId" });
            DropIndex("dbo.Instrument", new[] { "InstrumentType_InstrumentTypeId" });
            DropIndex("dbo.Person", new[] { "ApplicationUserId" });
            DropIndex("dbo.Person", new[] { "CurrentLocationId" });
            DropIndex("dbo.Person", new[] { "HometownLocationId" });
            DropIndex("dbo.Teacher", new[] { "PersonId" });
            DropIndex("dbo.Lesson", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Lesson", new[] { "Location_LocationId" });
            DropIndex("dbo.Lesson", new[] { "LessonType_LessonTypeId" });
            DropIndex("dbo.Enrolment", new[] { "StudentId" });
            DropIndex("dbo.Enrolment", new[] { "LessonId" });
            DropIndex("dbo.Student", new[] { "Lesson_LessonId" });
            DropIndex("dbo.Student", new[] { "PersonId" });
            DropIndex("dbo.Booking", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Booking", new[] { "Student_StudentId" });
            DropIndex("dbo.Booking", new[] { "Location_LocationId" });
            DropIndex("dbo.aspnetUserRole", new[] { "IdentityUser_Id" });
            DropIndex("dbo.aspnetUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.aspnetUserLogin", new[] { "IdentityUser_Id" });
            DropIndex("dbo.aspnetUserClaim", new[] { "IdentityUser_Id" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.LessonOffering");
            DropTable("dbo.InstrumentType");
            DropTable("dbo.Instrument");
            DropTable("dbo.aspnetUser");
            DropTable("dbo.Person");
            DropTable("dbo.Teacher");
            DropTable("dbo.LessonType");
            DropTable("dbo.Lesson");
            DropTable("dbo.Enrolment");
            DropTable("dbo.Student");
            DropTable("dbo.Location");
            DropTable("dbo.Booking");
            DropTable("dbo.aspnetUserRole");
            DropTable("dbo.aspnetUserLogin");
            DropTable("dbo.aspnetUserClaim");
        }
    }
}
