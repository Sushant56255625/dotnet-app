using Microsoft.AspNetCore.Mvc;
using TestingApplication.Models;

namespace TestingApplication.Controllers
{
    public class HomeController : Controller
    {
        private string GetBaseUrl()
        {
            return $"{Request.Scheme}://{Request.Host}";
        }

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();

            var baseUrl = GetBaseUrl();

            var employees = await client.GetFromJsonAsync<List<Employee>>(
                $"{baseUrl}/api/employee");

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

            var baseUrl = GetBaseUrl();

            var response = await client.PostAsJsonAsync(
                $"{baseUrl}/api/employee", emp);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = new HttpClient();

            var baseUrl = GetBaseUrl();

            await client.DeleteAsync($"{baseUrl}/api/employee/{id}");

            return RedirectToAction("Index");
        }
    }
}