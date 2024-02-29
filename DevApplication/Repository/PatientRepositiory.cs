using DevApplication.Connection;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;

namespace DevApplication.Repository
{
    public class PatientRepositiory : Repository<Patient>, IPatientRepository
    {
        private ApplicationDbContext _db;

        public PatientRepositiory(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Patient patient)
        {
            _db.Update(patient);
        }
    }


   
}
