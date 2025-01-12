using P01_HospitalDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Doctor
    {

        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }

        [Key]
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.DoctorNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.DoctorSpecialityLength)]
        public string Specialty { get; set; } = null!;

        public ICollection<Visitation> Visitations { get; set; }
    }
}