using EntityFrameworkProject.Data;
using EntityFrameworkProject.Helpers;
using EntityFrameworkProject.Models;
using EntityFrameworkProject.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1, int take = 2)
        {
            List<Employee> employees = await _context.Employees
                .Where(m => !m.IsDeleted)
                .Skip((page * take) - take)
                .Take(take)
                .ToListAsync();

            List<EmployeeListVM> mapDatas = GetMapDatas(employees);

            int count = await GetPageCount(take);
            ViewBag.Take = take;
            Paginate<EmployeeListVM> result = new Paginate<EmployeeListVM>(mapDatas, page, count);

            return View(result);
        }

        private async Task<int> GetPageCount(int take)
        {
            int employeeCount = await _context.Employees.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)employeeCount / take);
        }


        private List<EmployeeListVM> GetMapDatas(List<Employee> employees)
        {
            List<EmployeeListVM> employeeList = new List<EmployeeListVM>();

            foreach (var emp in employees)
            {
                EmployeeListVM newEmployee = new EmployeeListVM
                {
                    Id = emp.Id,
                    FullName = emp.FullName,
                    Age = emp.Age,
                    Position = emp.Position,
                    IsActive = emp.IsActive
                };

                employeeList.Add(newEmployee);
            }

            return employeeList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetStatus(int id)
        {
            Employee employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

            if (employee is null) return NotFound();

            if (employee.IsActive)
            {
                employee.IsActive = false;
            }
            else
            {
                employee.IsActive = true;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
