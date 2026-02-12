using EmployeeApp.Models;
using EmployeeMiniApp.Data;
using EmployeeMiniApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMiniApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDTO empDTO)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee
                {
                    Name = empDTO.Name,
                    Email = empDTO.Email,
                    Department = empDTO.Department,
                    Salary = empDTO.Salary,
                    CreatedAt = DateTime.Now
                };
                _context.Employees.Add(emp);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            EmployeeDTO empDTO = new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                Salary = employee.Salary
            };
            ViewData["EmployeeId"] = id;
            return View(empDTO);
        }
        [HttpPost]
        public IActionResult Edit(int id, EmployeeDTO empDTO)
        {
            if (ModelState.IsValid)
            {
                var employee = _context.Employees.Find(id);
                if (employee == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (!ModelState.IsValid)
                {
                    ViewData["EmployeeId"] = employee.Id;
                    return View(empDTO);
                }

                employee.Name = empDTO.Name;
                employee.Email = empDTO.Email;
                employee.Department = empDTO.Department;
                employee.Salary = empDTO.Salary;
                
                _context.SaveChanges();
            }
            return View(empDTO);
        }
    }
}