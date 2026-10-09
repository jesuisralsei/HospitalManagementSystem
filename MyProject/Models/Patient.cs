using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace MyProject.Models
{
    public class Patient
    {
        
        public int PatientId { get; set; }


        public string PatientName { get; set; } = null!;


        public string PatientDescription { get; set; } = null!;


        public int PatientAge { get; set; }

        public string PatientLocation { get; set; } = null!;

        
        public int DoctorId { get; set; }

        [JsonIgnore]
        public List<Doctor>? Doctors { get; set; }

        public List<Visits>? Visits {get; set; }

        [NotMapped]
        public IFormFile? MedicalRecord { get; set; }

        public string MedicalRecordPath { get; set; } = null!;
    }
}
