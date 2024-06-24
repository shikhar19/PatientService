using System.ComponentModel.DataAnnotations;

namespace PatientService.Models
{
    public class MedicalHistoryModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
