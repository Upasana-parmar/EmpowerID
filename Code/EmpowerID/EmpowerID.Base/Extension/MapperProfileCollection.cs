using AutoMapper;
using EmpowerID.Base.ViewModel;
using EmpowerID.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Base.Extension
{
    public class MapperProfileCollection : Profile
    {
        public MapperProfileCollection()
        {
            CreateMap<Department, DepartmentVM>()
            .ReverseMap();

            CreateMap<Employee, EmployeeVM>()
           .ReverseMap();            
        }
    }
}
