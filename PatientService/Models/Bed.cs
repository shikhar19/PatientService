using System.ComponentModel.DataAnnotations.Schema;

namespace PatientService.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public string Ward { get; set; }
        public bool IsOccupied { get; set; }
        public string? BedType { get; set; }

        // Foreign key to Patient
        public int? PatientId { get; set; }

        // Navigation property for Patient
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
