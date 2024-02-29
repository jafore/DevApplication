using DevApplication.Connection;
using DevApplication.Models;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;

namespace DevApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Patient = new PatientRepositiory(_db);
            Allergies = new AllergyRepository(_db);
            AllergyDetails = new AllergyDetailsRepository(_db);
            NcdDetails = new NcdDetailsRepository(_db);
            Ncds = new NcdRepository(_db);
            DiseaseInformation = new DiseaseInformationRepository(_db);


        }

        public IPatientRepository Patient { get; }
        public IAllergyRepository Allergies { get; }
      
        public INcdRepository Ncds { get; }
        public IAllergyDetailsRepository AllergyDetails { get; }
    
        public INcdDetailsRepository NcdDetails { get; }
   
        public IDiseaseInformationRepository DiseaseInformation { get; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
