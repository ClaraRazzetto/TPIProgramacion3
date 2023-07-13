using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shop.API.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Shop.API.Entities
{
    public class SaleOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Client Client { get; set; }
        [Required]
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Product Product { get; set; }
        [Required]
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        [Required]
        public SaleOrderState State { get; set; }

        public float Total
        {
            get
            {
                return ProductQuantity * Product.Price;
            }
        }
    }
}
