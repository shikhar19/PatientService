using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientService.Models
{
    public class MedicalHistory
    {
        [Key]
        public int MedicalHistoryId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        // Foreign key
        public int PatientId { get; set; }

        // Navigation property
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
