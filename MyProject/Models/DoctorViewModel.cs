namespace MyProject.Models
{
    public class DoctorViewModel
    {
        public List<Doctor>? Doctors { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public string? Term { get; set; }
        public string? OrderBy { get; set; }
    }
}
