using Microsoft.EntityFrameworkCore;
using PatientService.Data;
using PatientService.Models;

namespace PatientService.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDbContext _context;

        public PatientRepository(PatientDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients
                .Include(p => p.Appointments)
                .Include(p => p.MedicalHistories)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.Appointments)
                .Include(p => p.MedicalHistories)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                throw new InvalidOperationException();
            }

            return patient;

        }

        public async Task AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
