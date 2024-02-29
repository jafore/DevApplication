using DevApplication.Models;
using DevApplication.Models.EntityModel;

namespace DevApplication.Repository.IRepository
{
    public interface IAllergyRepository : IRepository<Allergy>
    {
        void Update(Allergy allergy);
    }

   
}
