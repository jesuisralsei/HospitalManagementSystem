namespace MyProject.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = null!;

        public int DoctorAge { get; set; }

        public string DoctorLocation { get; set; } = null!;

        public string DoctorDescription { get; set; } = null!;

        public string DoctorProfessionality { get; set; } = null!;

        public int PatientId { get; set; }
        public List<Patient>? Patients { get; set; }


    }
}
