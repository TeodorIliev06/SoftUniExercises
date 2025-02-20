using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicines.Common;

namespace Medicines.Data.Models
{
    public class Pharmacy
    {
        public Pharmacy()
        {
            this.Medicines = new List<Medicine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PharmacyNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        //Will specify the structure in a regex
        public string PhoneNumber { get; set; } = null!;

        [Required] 
        public bool IsNonStop { get; set; }

        public ICollection<Medicine> Medicines { get; set; }
    }
}
