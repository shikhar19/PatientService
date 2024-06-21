using Microsoft.EntityFrameworkCore;
using PatientService.Models;

namespace PatientService.Data
{
    public class PatientDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        // ReSharper disable once ConvertToPrimaryConstructor
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {

        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Bed> Beds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Bed)
                .WithMany(b => b.Patients)
                .HasForeignKey(p => p.BedId)
                .OnDelete(DeleteBehavior.SetNull); // Set null when bed is deleted

            base.OnModelCreating(modelBuilder);
        }
    }
}
