namespace DevApplication.Models
{
    public class PatientSave
    {
        public string[]? Name { get; set; }
        public int[]? Disease { get; set; }
        public int[]? Epilepsy { get; set; }
        public List<int>? NCDs { get; set; }
        public List <int>? Allergies { get; set; }
    }




}
