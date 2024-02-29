using DevApplication.Connection;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;

namespace DevApplication.Repository
{
    public class NcdRepository : Repository<Ncd>, INcdRepository
    {
        private ApplicationDbContext _db;

        public NcdRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Ncd ncd)
        {
            _db.Update(ncd);
        }
    }


   
}
