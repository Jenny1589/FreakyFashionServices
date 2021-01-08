using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FreakyFashionServices.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FreakyFashionServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly string _orderServiceAddress;

        public OrderController(IConfiguration configuration)
        {
            _orderServiceAddress = configuration.GetConnectionString("OrderService");
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]Customer customer)
        {
            using var client = new HttpClient();

            var serializedCustomer = JsonConvert.SerializeObject(customer);
            var data = new StringContent(serializedCustomer, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_orderServiceAddress, data);

            if (!response.IsSuccessStatusCode) return NotFound();

            return Accepted();
        }
    }
}
