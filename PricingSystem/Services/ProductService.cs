using Microsoft.AspNetCore.Hosting;
using PricingSystem.DTOs;
using PricingSystem.Models;
using PricingSystem.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PricingSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly IWebHostEnvironment _env;

        public ProductService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public Product GetProduct(string productId)
        {
            var filePath = Path.Combine(
                _env.ContentRootPath,
                "Data",
                "products.json");

            var json = File.ReadAllText(filePath);

            var root = JsonSerializer.Deserialize<ProductRoot>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return root?.Products?
                .FirstOrDefault(p => p.Id == productId);
        }
    }
}
