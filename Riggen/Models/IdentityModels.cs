using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Riggen.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Display(Name = "Profilbild")]
        public string ProfileImage { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Fullständigt namn")]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            // Database.SetInitializer(new  DropCreateDatabaseAlways<ApplicationDbContext>());
            //Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Riggen.Models.ResultModel> ResultModels { get; set; }

        public System.Data.Entity.DbSet<Riggen.Models.TournamentModel> TournamentModels { get; set; }

        public System.Data.Entity.DbSet<Riggen.Models.ScoreHistoryModel> ScoreHistoryModels { get; set; }

        public System.Data.Entity.DbSet<Riggen.Models.NewsModel> NewsModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            //modelBuilder.Entity<TournamentResultModel>()
            //    .HasMany(a => a.Results)
            //    .WithOptional(a => a.ApplicationUser).WillCascadeOnDelete(false);
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasOptional(a => a.)
            //    .WithMany(a => a.ApplicationUsers)
            //    .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<Riggen.Models.GuestUserModel> GuestUserModels { get; set; }
    }
}