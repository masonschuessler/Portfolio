using System.ComponentModel.DataAnnotations;

namespace Project2_1.Models
{
    public class PriceQuotation
    {
        [Required(ErrorMessage = "Please enter a valid price!")]
        [Range(1, 1000000, ErrorMessage = "Sales Price must be between 1 and 1000000")]
        public decimal? Subtotal { get; set; }

        [Required(ErrorMessage = "Please enter a valid discount percent!")]
        [Range(0, 100, ErrorMessage = "Discount Percent must be between 0 and 100")]
        public decimal? DiscountPercent { get; set; }

        public decimal CalculateDiscount()
        {
            if (Subtotal.HasValue && DiscountPercent.HasValue)
            {
                return Subtotal.Value * (DiscountPercent.Value / 100);
            }
            else
            {
                return 0.0m;
            }
        }

        public decimal CalculateTotal()
        {
            if (Subtotal.HasValue)
            {
                decimal discount = CalculateDiscount();
                return Subtotal.Value - discount;
            }
            else
            {
                return 0.0m;
            }
        }
    }
}
