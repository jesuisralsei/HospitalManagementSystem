using Microsoft.Data.SqlClient.DataClassification;

namespace MyProject.Models
{
    public class DoctorPatient
    {
        public int DoctorsDoctorId { get; set; }
        public Doctor? doctor { get; set; }

        public int PatientsPatientId { get; set; }
        public Patient? patient { get; set; }
        public List<Patient>? patients {  get; set; }
        public List<Doctor>? doctors { get; set; }
    }
}
