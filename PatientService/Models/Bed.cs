namespace PatientService.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public string Ward { get; set; }
        public bool IsOccupied { get; set; }
        public string? BedType { get; set; }

        // Navigation property for Patients assigned to this bed
        public ICollection<Patient> Patients { get; set; }
    }
}
