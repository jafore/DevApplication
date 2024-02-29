using DevApplication.Models.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace DevApplication.Connection
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

         //public DbSet<Product> Products { get; set; }  
         public DbSet<User?> Users { get; set; }

        public virtual DbSet<AllergiesDetail> AllergiesDetails { get; set; }

        public virtual DbSet<Allergy> Allergies { get; set; }

        public virtual DbSet<DiseaseInformation> DiseaseInformation { get; set; }

        public virtual DbSet<Ncd> Ncds { get; set; }

        public virtual DbSet<NcdDetail> NCDDetails { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

    }
}
