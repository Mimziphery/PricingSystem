using PricingSystem.DTOs;
using PricingSystem.Models;

namespace PricingSystem.Services.Interfaces
{
    public interface IProductService
    {
        Product GetProduct(string productId);
    }
}
