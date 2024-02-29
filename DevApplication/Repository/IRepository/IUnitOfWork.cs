namespace DevApplication.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPatientRepository Patient { get; }
        IAllergyDetailsRepository AllergyDetails { get; }
        IAllergyRepository Allergies { get; }
        INcdDetailsRepository NcdDetails { get; }
        INcdRepository Ncds { get; }
        IDiseaseInformationRepository DiseaseInformation { get; }
       
             
        void Save();
    }
}
