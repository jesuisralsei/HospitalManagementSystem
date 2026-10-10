using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class HospitalController : Controller
    {
        private readonly DataContext dataContext;
        public HospitalController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Patient()
        {
            var patients = dataContext.Patients;
            return View(patients);
        }
        //Get method for the patients

        [HttpGet]
        public IActionResult AddPatient()
        {
            ViewBag.Doctors = dataContext.Doctors.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {

                dataContext.Patients.Add(patient);
                dataContext.SaveChanges();
                return RedirectToAction("Patient");

            }
            return View(patient);
        }


        public IActionResult Doctor()
        {

            var doctors = dataContext.Doctors.Include(d => d.Patients).ToList();
            return View(doctors);

        }


      

        [HttpPost]

        public IActionResult AddDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {

                dataContext.Doctors.Add(doctor);
                dataContext.SaveChanges();
                return RedirectToAction("Doctor");
            }
            return View(doctor);

        }
        public IActionResult AddDoctor()
        {
            return View();
        }

        public IActionResult AssignDoctor()
        {

            var Doctor = dataContext.Doctors.Include(d => d.Patients);
            return View(Doctor);
        }
        //the get one for the departments

        [HttpGet]

        public IActionResult AddDepartment()
        {
            ViewBag.Doctors = dataContext.Doctors.ToList();

            return View();
        }

        //here to add a department

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                dataContext.Departments.Add(department);
                dataContext.SaveChanges();
                return RedirectToAction("Departments");
            }

            return View(department);
        }


        

        public IActionResult Departments()
        {
            var departments = dataContext.Departments;
            return View(departments);
        }

        //dashboard

        public IActionResult DashBoard()
        {
            // Fetch counts from the database for your dashboard statistics
            ViewBag.PatientCount = dataContext.Patients.Count();
            ViewBag.DoctorCount = dataContext.Doctors.Count();
            ViewBag.DepartmentCount = dataContext.Departments.Count();

            return View();

        }
        // Get method for uploading medical records
        [HttpPost]

        public async Task<IActionResult> UploadMedicalRecord(int patientId, IFormFile medicalRecord)
        {
            if (medicalRecord != null && medicalRecord.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                Directory.CreateDirectory(uploadsFolder); // Ensure the directory exists
                var filePath = Path.Combine(uploadsFolder, medicalRecord.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await medicalRecord.CopyToAsync(stream);
                }
                // Update the patient's MedicalRecordPath in the database
                var patient = dataContext.Patients.FirstOrDefault(p => p.PatientId == patientId);
                if (patient != null)
                {
                    patient.MedicalRecordPath = filePath;
                    dataContext.SaveChanges();
                }
                return RedirectToAction("Patient");
            }
            return View("UploadMedicalRecord"); // Handle error case
        }

        public IActionResult UploadMedicalRecord()
        {
            return View();
        }

        //patient details page
        public IActionResult PatientDetails(int? Id)
        {
            var patient = dataContext.Patients.FirstOrDefault(p => p.PatientId == Id);

            if (patient == null)
                return NotFound();

            return View(patient);
    
        }

        //update the patient information

        public async Task<IActionResult> UpdatePatient(int Id)
        {
            var patient = await dataContext.Patients.FirstOrDefaultAsync(p => p.PatientId == Id);
            return View(patient);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePatient(int Id, Patient patient)
        {
            if (ModelState.IsValid)
            {
                dataContext.Patients.Update(patient);
               await dataContext.SaveChangesAsync();
                return RedirectToAction($"PatientDetails/{Id}");
            }
            return View(patient);
        }

        //Doctor Details

        public IActionResult DoctorDetails(int? Id)
        {
            var doctor = dataContext.Doctors.FirstOrDefault(p => p.DoctorId == Id);

            if (doctor == null)
                return NotFound();

            return View(doctor);

        }


        //Update doctor

        public async Task<IActionResult> UpdateDoctor(int Id)
        {
            var doctor = await dataContext.Doctors.FirstOrDefaultAsync(d => d.DoctorId == Id);
            return View(doctor);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(int Id, Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                dataContext.Doctors.Update(doctor);
                await dataContext.SaveChangesAsync();
                return RedirectToAction($"DoctorDetails/{Id}");
            }
            return View(doctor);
        }
    }
}
