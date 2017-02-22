namespace Teacherfinder.DataLayer
{
    using Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class TeacherfinderDataContext : IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        //public DbSet<ApplicationUser> aspnetUsers { get; set; }
        public DbSet<IdentityUserLogin> aspnetUserLogins { get; set; }
        public DbSet<IdentityUserClaim> aspnetUserClaims { get; set; }
        public DbSet<IdentityUserRole> aspnetUserRoles { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }
        public DbSet<LessonOffering> LessonOfferings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public TeacherfinderDataContext() : base("name=TeacherfinderDataContext") { }

        public static TeacherfinderDataContext Create()
        {
            return new TeacherfinderDataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Configure Asp Net Identity Tables
            modelBuilder.Entity<Person>()
                .ToTable("Person")
                .HasRequired(p => p.ApplicationUser);
                //.WithOptional()
                //.WillCascadeOnDelete(false);
            //modelBuilder.Entity<Person>().Property(u => u.PasswordHash).HasMaxLength(500);
            //modelBuilder.Entity<Person>().Property(u => u.Stamp).HasMaxLength(500);
            //modelBuilder.Entity<Person>().Property(u => u.PhoneNumber).HasMaxLength(50);
            
            modelBuilder.Entity<IdentityUserRole>().ToTable("aspnetUserRole").HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserLogin>().ToTable("aspnetUserLogin").HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityUserClaim>().ToTable("aspnetUserClaim");
            modelBuilder.Entity<IdentityUser>().ToTable("aspnetUser").HasKey(u => u.Id);
            modelBuilder.Entity<IdentityUserClaim>().Property(u => u.ClaimType).HasMaxLength(150);
            modelBuilder.Entity<IdentityUserClaim>().Property(u => u.ClaimValue).HasMaxLength(500);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);

            //modelBuilder.Entity<Person>()

            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}