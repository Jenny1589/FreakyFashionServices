using FreakyFashionServices.Order.Extensions;
using FreakyFashionServices.Order.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private string _basketServiceAddress;
        private string _rabbitMqHost;

        public OrderController(IConfiguration configuration)
        {
            _basketServiceAddress = configuration.GetConnectionString("BasketService");
            _rabbitMqHost = configuration.GetConnectionString("RabbitMqHost");
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]Customer customer)
        {
            var basket = await GetBasket(customer.CustomerIdentifier);

            if (basket is null) return NotFound();

            var order = CreateOrder(customer.CustomerIdentifier, basket);
            order.Send(_rabbitMqHost);

            return Accepted();
        }

        private async Task<Basket> GetBasket(string customerIdentifier)
        {
            using var client = new HttpClient();

            var response = await client.GetAsync(_basketServiceAddress + customerIdentifier);

            if (!response.IsSuccessStatusCode) return null;

            var serializedBasket = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Basket>(serializedBasket);
        }

        private CustomerOrder CreateOrder(string customerIdentifier, Basket basket)
        {
            return new CustomerOrder
            {
                CustomerIdentifier = customerIdentifier,
                Items = basket.Items.Select(i => new CustomerOrder.OrderItem
                {
                    Id = i.Id,
                    ProductName = i.ProductName,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity
                })
            };
        }
    }
}
