using PricingSystem.Services.Interfaces;

namespace PricingSystem.Services
{
    public class DiscountService : IDiscountService
    {

        public decimal CalculateDiscount(int quantity, decimal subtotal)
        {

            if(subtotal >= 500)
            {
                if (quantity == 100)
                    return 0.15m;

                if (quantity > 50)
                    return 0.10m;

                if (quantity >= 10)
                    return 0.05m;
            }

            return 0;
        }

        public decimal CalculateDiscountAmount(decimal subtotal, decimal percent)
        {

           return subtotal * percent;
        }
    }
}
