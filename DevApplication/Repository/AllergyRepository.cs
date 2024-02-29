using DevApplication.Connection;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;

namespace DevApplication.Repository
{
    public class AllergyRepository : Repository<Allergy>, IAllergyRepository
    {
        private ApplicationDbContext _db;

        public AllergyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Allergy allergy)
        {
            _db.Update(allergy);
        }
    }


   
}
