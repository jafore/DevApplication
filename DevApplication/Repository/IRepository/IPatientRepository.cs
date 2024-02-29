using DevApplication.Models;
using DevApplication.Models.EntityModel;

namespace DevApplication.Repository.IRepository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient patient);
    }

   
}
