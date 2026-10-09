namespace MyProject.Models
{
    public class Visits
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public DateTime VisitDate { get; set; }

        public string? Reason { get; set; }

        public string? Diagnosis { get; set; }

        public string? Notes { get; set; }

        //many to one relationship with patients
    }
}
