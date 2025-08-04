using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_EF.Models;
using Newtonsoft.Json;
using System.Text;

namespace MVC_EF.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();
            using (var client = new HttpClient())
            {
                using (var result = await client.GetAsync("http://localhost:5267/api/Product"))
                {
                    string response = await result.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(response);
                }
            }
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var result = await client.PostAsJsonAsync("http://localhost:5267/api/Product", product))
                    {
                        string response = await result.Content.ReadAsStringAsync();
                        System.Console.WriteLine(response);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync($"http://localhost:5267/api/Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                System.Console.WriteLine("Product deleted successfully");
                return RedirectToAction("Index");  // Return 200 OK on success
            }
            else
            {
                System.Console.WriteLine($"Failed to delete. Status code: {response.StatusCode}");
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5267/api/Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                var productJson = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(productJson);

                return View(product);
            }
            else
            {
                // Handle error (e.g., product not found)
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var result = await client.PutAsJsonAsync($"http://localhost:5267/api/Product/{product.Id}", product))
                    {
                        string response = await result.Content.ReadAsStringAsync();
                        System.Console.WriteLine(response);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View(product);
            }
        }
    }
}
