using Microsoft.AspNetCore.Mvc;
using PricingSystem.DTOs;
using PricingSystem.Services.Interfaces;
using System;
using Microsoft.AspNetCore.Http;

namespace PricingSystem.Controllers
{
    [ApiController]
    [Route("api/pricing/calculate")]
    public class PricingController : ControllerBase
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        [HttpGet]
        public IActionResult Calculate([FromQuery] OrderRequest request)
        {
            try
            {
                var result = _pricingService.CalculatePrice(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
