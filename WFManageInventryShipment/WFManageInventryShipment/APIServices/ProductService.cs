using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WFManageInventryShipment.DataModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WFManageInventryShipment.APIServices
{
    public class ProductService
    {
        private static List<Product> listProduct;
        public static HttpClient client { get; set; }

        public ProductService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7028/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"
                    ));
        }


        public async Task<List<Product>> GetAllProductsAsync()
        {
            var response = await client.GetStringAsync("Product");
            return JsonConvert.DeserializeObject<List<Product>>(response);
        }

        public async Task<bool> AddProductAsync1(Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Product", content);
            return response.IsSuccessStatusCode;
            //return JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Product", content);
            return JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
        }


        public async Task<bool> DeleteProductAsync(int id)
        {
            var responseMessage = await client.DeleteAsync("Product/" + id);
            return responseMessage.IsSuccessStatusCode;
        }
        
        public async Task<bool> GetProductAsync(int id)
        {
            var response = await client.DeleteAsync("Product/" + id);
            return response.IsSuccessStatusCode;
        }
        public async Task<Product> UpdateProductAsync(Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"Product/{product.ProductId}", content);
            return JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
        }

    }
}
