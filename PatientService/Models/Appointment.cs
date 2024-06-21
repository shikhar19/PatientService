namespace PatientService.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string DoctorName { get; set; }
        public string Reason { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int BedId { get; set; }
        public bool IsCritical { get; set; }
    }
}
