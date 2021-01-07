using FreakyFashionServices.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FreakyFashionServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private string _basketServiceAddress;

        public BasketController(IConfiguration configuration)
        {
            _basketServiceAddress = configuration.GetConnectionString("BasketService");        
        }

        [HttpPut("{customerIdentifier}")]
        public async Task<IActionResult> AddProductInBasketAsync(string customerIdentifier, [FromBody]Basket basket)
        {
            using var client = new HttpClient();

            var serializedBasket = JsonConvert.SerializeObject(basket);
            var data = new StringContent(serializedBasket, Encoding.UTF8, "application/json");

            await client.PutAsync(_basketServiceAddress + customerIdentifier, data);

            return NoContent();
        }
    }
}
