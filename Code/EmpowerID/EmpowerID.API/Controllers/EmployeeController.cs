using AutoMapper;
using EmpowerID.Base.Services.Interface;
using EmpowerID.Base.ViewModel;
using EmpowerID.Data.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpowerID.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService _employeeService;
        public IDepartmentService _departmentService;
        public IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService,IMapper mapper, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get(string? search)
        {
            return Ok(await _employeeService.GetEmployees(search).ConfigureAwait(false));
        }

        [HttpGet("GetDepartment")]
        public async Task<IActionResult> GetDepartment()
        {
            return Ok(await _departmentService.GetDepartments().ConfigureAwait(false));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id).ConfigureAwait(false));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeVM employee)
        {
            return Ok(await _employeeService.AddUpdate(employee).ConfigureAwait(false));
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _employeeService.Delete(id).ConfigureAwait(false));
        }
    }
}
