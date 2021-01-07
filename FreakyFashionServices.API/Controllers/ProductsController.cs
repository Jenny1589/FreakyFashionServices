using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FreakyFashionServices.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FreakyFashionServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private string _catalogServiceAddress;
        private string _priceServiceAddress;

        public ProductsController(IConfiguration configuration)
        {
            _catalogServiceAddress = configuration.GetConnectionString("CatalogService");
            _priceServiceAddress = configuration.GetConnectionString("PriceService");
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await GetAsync<IEnumerable<Product>>(_catalogServiceAddress);

            var articleNumbers = string.Join(',', products.Select(p => p.Id));
            var priceInfo = await GetAsync<IEnumerable<PriceInfo>>(_priceServiceAddress + articleNumbers);

            return products.Select(p => {
                var productPriceInfo = priceInfo.FirstOrDefault(priceInfo => priceInfo.ArticleNumber == p.Id);
                p.Price = productPriceInfo?.Price ?? 0;

                return p;
            });            
        }

        private async Task<T> GetAsync<T>(string url)
        {
            using var client = new HttpClient();

            var response = await client.GetStringAsync(url);
            var responseObj = JsonConvert.DeserializeObject<T>(response);

            return responseObj;
        }
    }
}
