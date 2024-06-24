using System.ComponentModel.DataAnnotations;

namespace PatientService.Models
{
    public class PatientRegisterModel
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string PhotoPath { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public string ContactDetails { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public int? BedId { get; set; }

        public List<MedicalHistoryModel> MedicalHistories { get; set; }
    }
}
