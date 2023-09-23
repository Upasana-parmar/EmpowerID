using EmpowerID.Models;
using EmpowerID.Service.Interface;
using EmpowerID.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmpowerID.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IEmployeeService _employeeService;

        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }
        [Route("/")]
        [Route("Home/{search?}")]
        public async Task<IActionResult> Index(string search)
        {
            List<EmployeeVM> employees = await _employeeService.GetEmployees(search).ConfigureAwait(false);
            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}