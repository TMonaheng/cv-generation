using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CV_Generator.Entities;

namespace CV_Generator.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skill{ get; set; }
        public DbSet<Achievement> Achievement { get; set; }
        public DbSet<Strength> Strength { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<Company1Responsibility> Company1Responsibility { get; set; }
        public DbSet<Company2Responsibility> Company2Responsibility { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Permanent> Permanent { get; set; }
        public DbSet<WorkExperienceSummary> WorkExperienceSummary { get; set; }
        public DbSet<WorkExperienceDetailed_CompanyOne> WorkExperienceDetailed_CompanyOne { get; set; }
        public DbSet<WorkExperienceDetailed_CompanyTwo> WorkExperienceDetailed_CompanyTwo { get; set; }



        //public DbSet<WorkExperienceDetailed_CompanyTwo> Comp2DetailedWorkExperience { get; set; }
        //public DbSet<WorkExperienceDetailed_CompanyOne> Comp1DetailedWorkExperience { get; set; }
    }
}