using AutoMapper;
using EmpowerID.Base.CustomModel;
using EmpowerID.Base.Enum;
using EmpowerID.Base.Services.Interface;
using EmpowerID.Base.ViewModel;
using EmpowerID.Data.Model;
using EmpowerID.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmpowerID.Base.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Response> AddUpdate(EmployeeVM employee)
        {
            Response res = new Response();
            try
            {
                var Data = await ValidateData(employee).ConfigureAwait(false);
                if (!Data.IsSuccess)
                    return Data;

                if (employee.Id > 0)
                {
                    var emp = await _employeeRepository.GetQueryable(c => c.Id == employee.Id && c.IsDeleted == false).FirstOrDefaultAsync().ConfigureAwait(false);
                    emp.Name = employee.Name;
                    emp.DepartmentId = employee.DepartmentId;
                    emp.Email = employee.Email;
                    emp.DateOfBirth = employee.DateOfBirth;
                    emp.UpdatedDate =  DateTime.Now;
                    await _employeeRepository.UpdateAsync(emp).ConfigureAwait(false);
                    res.IsSuccess = true;
                    res.color = NotificationColor.Success.ToColorName();
                    res.Message = "Employee Updated Successfully!!!";
                    res.Result = emp;
                }
                else
                {
                    var emp = _mapper.Map<Employee>(employee);
                    emp.CreatedDate  = DateTime.Now;
                    await _employeeRepository.AddAsync(emp).ConfigureAwait(false);
                    res.IsSuccess = true;
                    res.color = NotificationColor.Success.ToColorName();
                    res.Message = "Employee Added Successfully!!!";
                    res.Result = emp;
                }
            }
            catch (Exception ex)
            {
                //logs
                res.color = NotificationColor.Error.ToColorName();
                res.Message = "Something Went Wrong! Please try again later.";
            }
            return res;
        }

        public async Task<Response> Delete(int employeeId)
        {
            Response res = new Response();
            try
            {
                var employee = await _employeeRepository.GetQueryable(c => c.Id == employeeId && c.IsDeleted == false).FirstOrDefaultAsync().ConfigureAwait(false);
                if (employee != null)
                {
                    employee.IsDeleted = true;
                    employee.UpdatedDate = DateTime.Now;
                    await _employeeRepository.UpdateAsync(employee).ConfigureAwait(false);
                    res.IsSuccess = true;
                    res.color = NotificationColor.Success.ToColorName();
                    res.Message = "Employee Deleted Successfully!!!";
                }
                else
                {
                    res.color = NotificationColor.Success.ToColorName();
                    res.Message = "Employee Not Found !!!";
                }
            }
            catch (Exception ex)
            {
                //logs
                res.color = NotificationColor.Error.ToColorName();
                res.Message = "Something Went Wrong! Please try again later.";
            }
            return res;
        }

        public async Task<Response> GetEmployeeById(int employeeId)
        {
            Response res = new Response();

            try
            {
                var employee = await _employeeRepository.GetQueryable(c => c.Id == employeeId && c.IsDeleted == false).FirstOrDefaultAsync().ConfigureAwait(false);
                if (employee != null)
                {
                    res.IsSuccess = true;
                    res.color = NotificationColor.Success.ToColorName();
                    res.Result = _mapper.Map<EmployeeVM>(employee);
                }
                else
                {
                    res.IsSuccess = false;
                    res.color = NotificationColor.Error.ToColorName();
                    res.Message = "Employee Not Found !!!";
                }
            }
            catch (Exception ex)
            {
                //logs
                res.color = NotificationColor.Error.ToColorName();
                res.Message = "Something Went Wrong! Please try again later.";
            }
            return res;

        }

        public async Task<Response> GetEmployees(string SearchValue)
        {
            Response res = new Response();

            try
            {
                res.IsSuccess = true;
                res.color = NotificationColor.Success.ToColorName();
                var list = await _employeeRepository.GetQueryable(c => c.IsDeleted == false).Include(c => c.Department).ToListAsync();
                if(!string.IsNullOrWhiteSpace(SearchValue))
                {
                    list = list.Where(c => c.Name.Contains(SearchValue) || c.Email.Contains(SearchValue) || c.Department.Name.Contains(SearchValue)).ToList();
                }
                res.Result =  _mapper.Map<List<EmployeeVM>>(list);
            }
            catch (Exception ex)
            {
                //logs
                res.Message = "Something Went Wrong! Please try again later.";
            }
            return res;
        }

        public async Task<Response> ValidateData(EmployeeVM employee)
        {
            Response res = new Response();
            res.IsSuccess = true;
            if (string.IsNullOrWhiteSpace(employee.Name))
            {
                res.IsSuccess = false;
                res.color = NotificationColor.Error.ToColorName();
                res.Message = "Please Enter Valid Name";
                return res;
            }
            if (string.IsNullOrWhiteSpace(employee.Email))
            {
                res.IsSuccess = false;
                res.color = NotificationColor.Error.ToColorName();
                res.Message = "Please Enter Valid email";
                return res;
            }
            if (employee.DateOfBirth == DateTime.MinValue || employee.DateOfBirth == DateTime.MaxValue)
            {
                res.IsSuccess = false;
                res.color = NotificationColor.Error.ToColorName();
                res.Message = "Please Enter Valid Date of Birth";
                return res;
            }
            if (employee.DepartmentId <= 0)
            {
                res.IsSuccess = false;
                res.color = NotificationColor.Error.ToColorName();
                res.Message = "Please select valid Department";
                return res;
            }
            return res;
        }
    }
}
