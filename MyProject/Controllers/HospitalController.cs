using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


    }
}
