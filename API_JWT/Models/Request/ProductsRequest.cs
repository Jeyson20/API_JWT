using System.ComponentModel.DataAnnotations;

namespace API_JWT.Models.Request
{
    public class ProductsRequest
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
