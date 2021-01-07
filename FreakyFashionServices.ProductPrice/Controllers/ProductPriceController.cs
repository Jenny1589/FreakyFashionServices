using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FreakyFashionServices.ProductPrice.Models;
using System;
using System.Collections.Generic;

namespace FreakyFashionServices.ProductPrice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPriceInfo(string products)
        {
            if (products is null) return Ok(new List<PriceInfo>());

            var randomizer = new Random();
            var priceInfo = products.Split(',').Select(articleNumber => new PriceInfo()
            {
                ArticleNumber = articleNumber,
                Price = Math.Round(randomizer.NextDouble() * 1000, 2)
            });

            return Ok(priceInfo);
        }
    }
}