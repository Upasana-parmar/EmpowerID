using EmpowerID.Service.Implementation;
using EmpowerID.Service.Interface;
using EmpowerID.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpowerID.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var departments = await _employeeService.GetDepartments().ConfigureAwait(false);
            EmployeeVM employeeVM = new EmployeeVM();
            if(id > 0)
            {
                employeeVM = await _employeeService.GetEmployeeById(id).ConfigureAwait(false); 
            }

            employeeVM.Departments = new SelectList(departments,"Id","Name");
            return View(employeeVM);
        }


        [HttpPost]
        public async Task<IActionResult> Index(EmployeeVM employee)
        {
            ResponseVM response = new ResponseVM();
            response = await _employeeService.AddUpdateEmployee(employee).ConfigureAwait(false);
            if (response.IsSuccess)
                response.URL = Url.Action("index", "Home");
            return Json(response);
        }

        public async Task<IActionResult> Delete(int id)
        {           
            var employeeVM = await _employeeService.DeleteEmployee(id).ConfigureAwait(false);
           
            return Json(employeeVM);
        }
    }
}
