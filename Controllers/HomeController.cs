using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingApplication.Data;
using TestingApplication.Models;

namespace TestingApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.EmployeeDetails.ToListAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            _context.EmployeeDetails.Add(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _context.EmployeeDetails.FindAsync(id);
            if (emp != null)
            {
                _context.EmployeeDetails.Remove(emp);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
