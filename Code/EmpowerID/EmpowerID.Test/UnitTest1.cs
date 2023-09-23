using AutoMapper;
using Castle.Core.Configuration;
using EmpowerID.API.Controllers;
using EmpowerID.Base.CustomModel;
using EmpowerID.Base.Services.Interface;
using EmpowerID.Base.ViewModel;
using EmpowerID.Data.Data;
using EmpowerID.Data.Model;
using EmpowerID.Data.Repository.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;

namespace EmpowerID.Test
{
    public class UnitTest
    {
        private readonly Mock<IEmployeeService> _EmployeeService;
        private readonly Mock<IDepartmentService> _departmentService;
        private readonly Mock<IMapper> _mapper;
        protected readonly Mock<Microsoft.Extensions.Configuration.IConfiguration> _configuration;
        public static AppDataContext context;


        public UnitTest()
        {
            _EmployeeService = new Mock<IEmployeeService>();
            _departmentService = new Mock<IDepartmentService>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {

            var empController = new EmployeeController(_EmployeeService.Object, _mapper.Object, _departmentService.Object);
            // Act
            var okResult = empController.Get("");
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result as OkObjectResult);
        }

        [Fact]
        public void GetEmployeeList_EmployeeList()  
        {
            //arrange
            var employeeList = EmployeeMockData.GetEmployeeData();
            _EmployeeService.Setup(x => x.GetEmployees(""))
                .Returns(employeeList);
            var empController = new EmployeeController(_EmployeeService.Object,_mapper.Object, _departmentService.Object);
            //act
            var empResult = empController.Get("");
            var okResult = empResult.Result as OkObjectResult;
            //assert
            Assert.NotNull(okResult);
            var response = okResult.Value as Response;
            var empolyeelist = response.Result as List<EmployeeVM>;
            Assert.Equal(((List<EmployeeVM>)EmployeeMockData.GetEmployeeData().Result.Result).Count(), empolyeelist.Count());
            Assert.Equal(EmployeeMockData.GetEmployeeData().Result.ToString(), response.ToString());
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void GetEmployeeList_GetEmpByID()
        {
            //arrange
            var employee = EmployeeMockData.GetEmployeeById(1);
            _EmployeeService.Setup(x => x.GetEmployeeById(1))
                .Returns(employee);
            var empController = new EmployeeController(_EmployeeService.Object, _mapper.Object, _departmentService.Object);

            //act
            var empResult = empController.Get(1);
            var okResult = empResult.Result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            var response = okResult.Value as Response;
            var empolyeelist = response.Result as EmployeeVM;
            Assert.Equal(employee.Result.ToString(), response.ToString());
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void Save_AddNewEmployee()
        {
            //arrange.
           var emp =  new EmployeeVM
            {
                Id = 0,
                Name = "Raj F. ",
                Email = "Raj@gmail.com",
                DepartmentId = 1,
                DateOfBirth = DateTime.Now
            };
            var employee = EmployeeMockData.AddEmployee(emp);
            _EmployeeService.Setup(x => x.AddUpdate(emp))
                .Returns(employee);
            var empController = new EmployeeController(_EmployeeService.Object, _mapper.Object, _departmentService.Object);

            //act
            var empResult = empController.Post(emp);
            var okResult = empResult.Result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            var response = okResult.Value as Response;
            var empolyeelist = response.Result as EmployeeVM;
            Assert.Equal(employee.Result.ToString(), response.ToString());
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void Delete_Employee()
        {
            //arrange
            var employee = EmployeeMockData.Delete(1);
            _EmployeeService.Setup(x => x.Delete(1))
                .Returns(employee);
            var empController = new EmployeeController(_EmployeeService.Object, _mapper.Object, _departmentService.Object);

            //act
            var empResult = empController.Delete(1);
            var okResult = empResult.Result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            var response = okResult.Value as Response;
            var empolyeelist = response.Result as EmployeeVM;
            Assert.Equal(employee.Result.ToString(), response.ToString());
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}