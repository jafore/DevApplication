using DevApplication.Connection;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;

namespace DevApplication.Repository
{
    public class AllergyDetailsRepository : Repository<AllergiesDetail>, IAllergyDetailsRepository
    {
        private ApplicationDbContext _db;

        public AllergyDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(AllergiesDetail allergiesDetail)
        {
            _db.Update(allergiesDetail);
        }
    }


   
}
