using PricingSystem.DTOs;

namespace PricingSystem.Services.Interfaces
{
    public interface IPricingService
    {
        public PricingResponse CalculatePrice(OrderRequest request);
    }
}
