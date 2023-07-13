using Microsoft.VisualBasic;
using Shop.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Shop.API.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ProductCategories Category { get; set; }
        [Required]
        public ProductSizes Size { get; set; }
        [Required]    
        public float Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();
    }
}
