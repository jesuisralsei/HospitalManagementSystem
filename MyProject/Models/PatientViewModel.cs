namespace MyProject.Models
{
    public class PatientViewModel
    {

        public List<Patient>? Patients { get; set; }

        public string PatientNameSortOrder { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public string? Term { get; set; }
        public string? OrderBy { get; set; }

    }
}
