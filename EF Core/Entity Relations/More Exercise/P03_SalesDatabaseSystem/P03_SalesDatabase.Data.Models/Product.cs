using P03_SalesDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ProductNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
