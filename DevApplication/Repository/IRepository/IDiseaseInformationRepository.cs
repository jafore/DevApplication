using DevApplication.Models;
using DevApplication.Models.EntityModel;

namespace DevApplication.Repository.IRepository
{
    public interface IDiseaseInformationRepository : IRepository<DiseaseInformation>
    {
        void Update(DiseaseInformation diseaseInformation);
    }

   
}
