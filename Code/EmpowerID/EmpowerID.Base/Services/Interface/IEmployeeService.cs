using EmpowerID.Base.CustomModel;
using EmpowerID.Base.ViewModel;
using EmpowerID.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Base.Services.Interface
{
    public interface IEmployeeService
    {
        Task<Response> GetEmployeeById(int employeeId);
        Task<Response> GetEmployees(string SearchValue);
        Task<Response> AddUpdate(EmployeeVM employee);
        Task<Response> Delete(int employeeId);
    }
}
