﻿using System.ComponentModel.DataAnnotations;

namespace PatientService.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public string PhotoPath { get; set; }
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


        // Appointments and Medical History
        public List<Appointment> Appointments { get; set; }
        public List<MedicalHistory> MedicalHistories { get; set; }
        // Foreign key for Bed
        public int? BedId { get; set; } // Optional bed assignment
        public Bed Bed { get; set; } // Navigation property
    }
}
