namespace PatientService.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactDetails { get; set; }
        public string Address { get; set; }

        // Medical Information
        public string Allergies { get; set; }
        public string MedicalConditions { get; set; }
        public string PreviousSurgeries { get; set; }
        public string Medications { get; set; }

        // Appointments and Medical History
        public List<Appointment> Appointments { get; set; }
        public List<MedicalHistory> MedicalHistories { get; set; }
    }
}
