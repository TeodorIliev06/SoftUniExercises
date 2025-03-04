﻿using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
            this.Visitations = new HashSet<Visitation>();
            this.Diagnoses = new HashSet<Diagnose>();
        }

        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PatientFirstNameLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.PatientLastNameLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.PatientAddressLength)]
        public string Address { get; set; } = null!;

        [Required]
        [Unicode(false)]
        [MaxLength(ValidationConstants.PatientAddressLength)]
        public string Email { get; set; } = null!;

        [Required]
        public bool HasInsurance { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }
        public virtual ICollection<Diagnose> Diagnoses { get; set; }
    }
}
