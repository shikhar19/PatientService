using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using PatientService.Models;
using PatientService.Services;

namespace PatientService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("GetPatients")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

       
        [HttpGet("GetPatients/{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PatientRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPatient = await _patientService.GetPatientByEmailAsync(model.Email);

            if (existingPatient != null)
            {
                return Conflict("Email already in use.");
            }

            var patient = new Patient
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                ContactDetails = model.ContactDetails,
                Gender = model.Gender,
                PhotoPath = model.PhotoPath,
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                BedId = model.BedId,
                MedicalHistories = model.MedicalHistories.Select(m => new MedicalHistory
                {
                    Description = m.Description,
                    Date = m.Date
                }).ToList()
            };

            await _patientService.AddPatientAsync(patient);

            return Ok();
        }

        [HttpPut("UpdatePatient/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromForm] Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            await _patientService.UpdatePatientAsync(patient);
            return NoContent();
        }

        [HttpDelete("DeletePatient/{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
    }
}
