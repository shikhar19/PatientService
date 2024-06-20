namespace PatientService.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Treatments { get; set; }
        public string TestResults { get; set; }
        public string Immunizations { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
