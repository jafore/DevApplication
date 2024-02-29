using DevApplication.Models;
using DevApplication.Models.EntityModel;

namespace DevApplication.Repository.IRepository
{
    public interface IAllergyDetailsRepository : IRepository<AllergiesDetail>
    {
        void Update(AllergiesDetail allergiesDetail);
    }

   
}
