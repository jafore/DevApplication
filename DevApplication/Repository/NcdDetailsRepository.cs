using DevApplication.Connection;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;

namespace DevApplication.Repository
{
    public class NcdDetailsRepository : Repository<NcdDetail>, INcdDetailsRepository
    {
        private ApplicationDbContext _db;

        public NcdDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(NcdDetail ncdDetail)
        {
            _db.Update(ncdDetail);
        }
    }


   
}
