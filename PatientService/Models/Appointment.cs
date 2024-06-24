using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientService.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string DoctorName { get; set; }
        public string Reason { get; set; }
        public int PatientId { get; set; }

        // Navigation properties
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public bool IsCritical { get; set; }
    }
}
