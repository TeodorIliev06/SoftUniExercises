using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicines.Common;
using Newtonsoft.Json;

namespace Medicines.DataProcessor.ImportDtos
{
    public class PatientImportDto
    {
        [Required]
        [JsonProperty("FullName")]
        [MinLength(ValidationConstants.PatientFullNameMinLength)]
        [MaxLength(ValidationConstants.PatientFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [JsonProperty("AgeGroup")]
        [Range(ValidationConstants.PatientAgeGroupMinValue, ValidationConstants.PatientAgeGroupMaxValue)]
        public int AgeGroup { get; set; }

        [Required]
        [JsonProperty("Gender")]
        [Range(ValidationConstants.PatientGenderMinValue, ValidationConstants.PatientGenderMaxValue)]
        public int Gender { get; set; }

        [Required]
        [JsonProperty(nameof(Medicines))]
        public int[] Medicines { get; set; }
    }
}
