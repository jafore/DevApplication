using DevApplication.Models;
using DevApplication.Models.EntityModel;

namespace DevApplication.Repository.IRepository
{
    public interface INcdRepository : IRepository<Ncd>
    {
        void Update(Ncd ncd);
    }

   
}
