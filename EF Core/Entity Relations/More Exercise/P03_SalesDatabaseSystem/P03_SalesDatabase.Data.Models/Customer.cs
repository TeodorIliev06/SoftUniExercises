using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CustomerNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Unicode(false)]
        [MaxLength(ValidationConstants.CustomerEmailLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.CustomerCreditCardNumberLength)]
        public string CreditCardNumber { get; set; } = null!;
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
