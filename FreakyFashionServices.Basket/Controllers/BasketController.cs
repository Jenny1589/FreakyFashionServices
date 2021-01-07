using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using FreakyFashionServices.Basket.Extensions;
using FreakyFashionServices.Basket.Models;

namespace FreakyFashionServices.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IDistributedCache _cache;

        public BasketController(IDistributedCache cache)
        {
            _cache = cache;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBasketAsync(string id, [FromBody]ShoppingBasket basket)
        {
            await _cache.SetRecordAsync(id, basket);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBasketAsync(string id)
        {
            var basket = await _cache.GetRecordAsync<ShoppingBasket>(id);

            if (basket is null) return NotFound();

            return Ok(basket);
        }
    }
}
