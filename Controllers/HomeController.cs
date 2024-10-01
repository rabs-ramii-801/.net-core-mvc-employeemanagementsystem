using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EmployeeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeesDbContext _EmployeeDb;

        public HomeController(EmployeesDbContext employeesDbContext)
        {
            this._EmployeeDb = employeesDbContext;
        }
        public IActionResult Index()
        {
            var EmpData=_EmployeeDb.Employees.ToList();
            return View(EmpData);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employees emp)
        {
            if (ModelState.IsValid)
            {
               await  _EmployeeDb.Employees.AddAsync(emp);
               await  _EmployeeDb.SaveChangesAsync();
                TempData["success"] = "Employee Added Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                // Handle the case where 'id' is null (e.g., redirect or return an error)
                return RedirectToAction("Index");
            }
            var empData = await _EmployeeDb.Employees.FindAsync(id);

            if (empData == null)
            {

                return RedirectToAction("Index");
            }
            return View(empData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employees emp)
        {
            _EmployeeDb.Employees.Update(emp);
            await _EmployeeDb.SaveChangesAsync();
            TempData["success"] = "Employee Updated Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                // Handle the case where 'id' is null (e.g., redirect or return an error)
                return RedirectToAction("Index");
            }
            var empData =await  _EmployeeDb.Employees.FindAsync(id);
            
            if (empData == null)
            {
              
                return RedirectToAction("Index");
            }
            return View(empData);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                // Handle the case where 'id' is null (e.g., redirect or return an error)
                return RedirectToAction("Index");
            }
            var empData = await _EmployeeDb.Employees.FindAsync(id);

            if (empData == null)
            {

                return RedirectToAction("Index");
            }
            return View(empData);
        }

        [HttpPost,ActionName("Delete")]

        public async Task<IActionResult>DeleteConfirm(int? id)
        {
            var empData = await _EmployeeDb.Employees.FindAsync(id);
            if (empData != null)
            {
                _EmployeeDb.Employees.Remove(empData);
                await _EmployeeDb.SaveChangesAsync();
                TempData["danger"] = "Employee Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View(empData);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
