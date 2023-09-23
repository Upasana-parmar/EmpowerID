using EmpowerID.Base.CustomModel;
using EmpowerID.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Test
{
    public class EmployeeMockData
    {
        public static async Task<Response> GetEmployeeData()
        {
            Response response = new Response();
            response.IsSuccess = true;
            
            response.Result = GetEmployees();
            return response;

            //context.Employees.AddRange(
            //    new Employee() { Id = 1, Name = "David N.", Email = "david@gmail.com", DepartmentId = 1, DateOfBirth = DateTime.Now },
            //    new Employee() { Id = 2, Name = "Andrew K.", Email = "andrew@gmail.com", DepartmentId = 1, DateOfBirth = DateTime.Now },
            //    new Employee() { Id = 3, Name = "Arcanglo F. ", Email = "arcanglo@gmail.com", DepartmentId = 1, DateOfBirth = DateTime.Now }
            //);
            //context.Departments.AddRange(
            //    new Department
            //    {
            //        Name = "Information Tech",
            //        Description = "Information Tech.",
            //        CreatedDate = DateTime.Now,
            //        IsDeleted = false
            //    },
            //    new Department
            //    {
            //        Name = "Human Resource",
            //        Description = "Human Resource",
            //        CreatedDate = DateTime.Now,
            //        IsDeleted = false
            //    }
            //);
        }

        public static List<EmployeeVM> GetEmployees()
        {
            List<EmployeeVM> _employees = new List<EmployeeVM> {
                new EmployeeVM() { Id=1,Name="David N.",Email = "david@gmail.com",DepartmentId=1,DateOfBirth = DateTime.Now.Date},
                new EmployeeVM() { Id=2,Name="Andrew K.",Email = "andrew@gmail.com",DepartmentId=1,DateOfBirth = DateTime.Now.Date},
                new EmployeeVM() { Id=3,Name="Arcanglo F. ",Email = "arcanglo@gmail.com",DepartmentId=1,DateOfBirth = DateTime.Now.Date}
            };
            return _employees;
        }

        public static async Task<Response> GetEmployeeById(int Id)
        {
            Response response = new Response();
            response.IsSuccess = true;
            response.Result = GetEmployees().FirstOrDefault(c => c.Id == Id);
            return response;
        }

        public static async Task<Response> AddEmployee(EmployeeVM employee)
        {
            Response response = new Response();
            response.IsSuccess = true;
            response.Result = employee;
            return response;
        }

        public static async Task<Response> Delete(int Id)
        {
            Response response = new Response();
            response.IsSuccess = true;
            response.Message = "Employee Deleted Successfully!!!";
            return response;
        }
    }
}
