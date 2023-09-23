using EmpowerID.ViewModel;

namespace EmpowerID.Service.Interface
{
    public interface IEmployeeService
    {
        Task<List<DepartmentVM>> GetDepartments();
        Task<List<EmployeeVM>> GetEmployees(string search);
        Task<EmployeeVM> GetEmployeeById(int Id);
        Task<ResponseVM> AddUpdateEmployee(EmployeeVM employee);
        Task<ResponseVM> DeleteEmployee(int Id);

    }
}
