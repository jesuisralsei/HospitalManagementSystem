namespace MyProject.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Location { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public int? HeadDoctorId { get; set; }

        public int Capacity { get; set; }

        public int NumberOfBeds { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        //one to many relationship with doctors
        //public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
