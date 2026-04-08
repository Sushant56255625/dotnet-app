using Microsoft.AspNetCore.Mvc;
using TestingApplication.Models;
using System.Text.Json;

namespace TestingApplication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();

            var employees = await client.GetFromJsonAsync<List<Employee>>("https://localhost:7282/api/employee");

            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            var client = new HttpClient();

            var response = await client.PostAsJsonAsync("https://localhost:7282/api/employee", emp);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = new HttpClient();

            await client.DeleteAsync($"https://localhost:7282/api/employee/{id}");

            return RedirectToAction("Index");
        }
    }
}

