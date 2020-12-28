using System;
using System.Collections.Generic;
using System.Linq;
using FreakyFashionServices.Catalog.Data;
using FreakyFashionServices.Catalog.Data.Dtos;
using FreakyFashionServices.Catalog.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        private FreakyFashionCatalogDbContext _context;

        public CatalogController(FreakyFashionCatalogDbContext context)
        {
            _context = context;
        }

        [HttpGet("items")]
        public IEnumerable<ProductDto> GetItems()
        {
            return _context.Products.Select(p => ConvertToDto(p));
        }

        [HttpGet("items/{id}")]
        public ActionResult GetItem(Guid id)
        {
            var foundProduct = _context.Products.FirstOrDefault(p => p.Id.Equals(id));

            if (Object.Equals(foundProduct, null)) return NotFound();

            return Ok(ConvertToDto(foundProduct));
        }

        private static ProductDto ConvertToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                AvailableStock = product.AvailableStock
            };
        }
    }
}
