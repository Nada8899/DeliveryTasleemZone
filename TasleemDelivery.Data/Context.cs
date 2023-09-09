using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasleemDelivery.Data.Extensions;
using TasleemDelivery.Models;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Data
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        public Context()
        {
            
        }
       public Context(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<ClientChat> Chat { get; set; }
        public DbSet<Delivery> Delivery { get; set; }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<SubAdmin> SubAdmin { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<EducationLevel> EducationLevel { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Client> Client { get; set; }

        public DbSet<Language> Languge { get; set; }
        public DbSet<Proposal> Proposal { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<SavedJob> SavedJob { get; set; }
        public DbSet<Skill> Skill { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyGlobalFilter<IBaseModel<int>>(x => !x.IsDeleted);

            modelBuilder.ApplyGlobalFilter<IBaseModel<string>>(x => !x.IsDeleted);
        }




    }
}