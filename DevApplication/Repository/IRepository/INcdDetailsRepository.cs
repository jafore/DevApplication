using DevApplication.Models;
using DevApplication.Models.EntityModel;

namespace DevApplication.Repository.IRepository
{
    public interface INcdDetailsRepository : IRepository<NcdDetail>
    {
        void Update(NcdDetail ncdDetail);
    }

   
}
