using DevApplication.Connection;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;

namespace DevApplication.Repository
{
    public class DiseaseInformationRepository : Repository<DiseaseInformation>, IDiseaseInformationRepository
    {
        private ApplicationDbContext _db;

        public DiseaseInformationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(DiseaseInformation diseaseInformation)
        {
            _db.Update(diseaseInformation);
        }
    }


   
}
