using EmpowerID.Service.Interface;
using EmpowerID.ViewModel;
using Newtonsoft.Json;

namespace EmpowerID.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IAPIService _service; 
        private readonly IConfiguration _configuration;
        public EmployeeService(IConfiguration configuration, IAPIService service)
        {
            _configuration = configuration;
            _service = service;
        }

        public async Task<ResponseVM> AddUpdateEmployee(EmployeeVM employee)
        {
            var response = await _service.Post<ResponseVM>($"/api/Employee/",employee).ConfigureAwait(false);

            return response;
        }

        public async Task<ResponseVM> DeleteEmployee(int Id)
        {
            var response = await _service.Delete<ResponseVM>($"/api/Employee/" + Id).ConfigureAwait(false);

            return response;
        }

        public async Task<List<DepartmentVM>> GetDepartments()
        {
            var response = await _service.Get<ResponseVM>($"/api/Employee/GetDepartment/").ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<DepartmentVM>>(response.Result.ToString());
        }

        public async Task<EmployeeVM> GetEmployeeById(int Id)
        {
            var response = await _service.Get<ResponseVM>($"/api/Employee/"+Id).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<EmployeeVM>(response.Result.ToString());
        }

        public async Task<List<EmployeeVM>> GetEmployees(string search)
        {
            var response = await _service.Get<ResponseVM>($"/api/Employee?search="+search).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<EmployeeVM>>(response.Result.ToString());
        }
    }
}
