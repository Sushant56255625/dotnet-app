using Microsoft.AspNetCore.Mvc;
using TestingApplication.Data;
using TestingApplication.Models;

namespace TestingApplication.Controllers
{
    [ApiController] // 👈 MUST
    [Route("api/[controller]")] // 👈 MUST
    public class EmployeeController : ControllerBase // 👈 MUST (not Controller)
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet] // 👈 MUST
        public IActionResult GetEmployees()
        {
            var employees = _context.EmployeeDetails.ToList();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            _context.EmployeeDetails.Add(emp);
            _context.SaveChanges();
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = _context.EmployeeDetails.Find(id);

            if (emp == null)
                return NotFound();

            _context.EmployeeDetails.Remove(emp);
            _context.SaveChanges();

            return Ok();
        }
    }
}