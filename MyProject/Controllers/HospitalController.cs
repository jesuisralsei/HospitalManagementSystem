using Google.Protobuf.WellKnownTypes;
using IronPdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MyProject.Data;
using MyProject.Models;
using System.Linq.Expressions;


namespace MyProject.Controllers
{
    public class HospitalController : Controller
    {
        private readonly DataContext dataContext;
        private readonly IWebHostEnvironment _environment;
        public HospitalController(DataContext _dataContext, IWebHostEnvironment environment)
        {
            dataContext = _dataContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Patient(string term = "", string orderby = "", int currentPage = 1)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(orderby) ? "name_desc" : "";
            var PatData = new PatientViewModel();
            int pageSize = 10;

            var query = dataContext.Patients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(term))
            {
                query = query.Where(p => p.PatientName.StartsWith(term));
            }





            if (orderby == "name_desc")
            {
                query = query.OrderByDescending(p => p.PatientName);
                PatData.OrderBy = "name_desc";
            }
            else
            {
                query = query.OrderBy(p => p.PatientName);
                PatData.OrderBy = "name_asc";
            }

            int totalRecords = query.Count();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var patientsList = query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList(); 

            PatData.Patients = patientsList;
            PatData.CurrentPage = currentPage;
            PatData.TotalPages = totalPages;
            PatData.PageSize = pageSize;
            PatData.Term = term;
            PatData.OrderBy = orderby;

            return View(PatData);
        }
        //Get method for the patients

        [HttpGet]
        public IActionResult AddPatient()
        {
            ViewBag.Doctors = dataContext.Doctors.ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(Patient patient) //IFormFile formfile
        {
            //if (formfile == null)
            //{
            //    return BadRequest("No File Was Selected");
            //}
            //using var stream = new MemoryStream();
            //formfile.CopyTo(stream);
            //var pdfile = new PdfFileModel
            //{
            //    FileName = Path.GetFileName(formfile.FileName),
            //    FilePath = Path.GetFullPath(formfile.FileName)

            //};
            string fileName = Guid.NewGuid().ToString() + "_" + patient.MedicalRecord.FileName;

            string UploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            string filePath = Path.Combine(UploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await patient.MedicalRecord.CopyToAsync(stream);
            }

            patient.MedicalRecordPath = "/uploads/" + fileName;
            ViewBag.Doctors = dataContext.Doctors.ToList();
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

        //making a visti

        [HttpGet]
        public IActionResult MakeVisit()
        {
            ViewBag.Doctors = dataContext.Doctors.ToList();
            ViewBag.Patients = dataContext.Patients.ToList();
            ViewBag.Departments = dataContext.Departments.ToList();
            ViewBag.Visits = dataContext.Visits.ToList();
            return View();

        }
        [HttpPost]

        public async Task<IActionResult> MakeVisit(Visits visit)
        {
            if (ModelState.IsValid) {

                dataContext.Visits.Update(visit);
                dataContext.SaveChanges();
                RedirectToAction("ViewVisits");
            
            }
            return View();

        }
    }
}
