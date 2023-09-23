using EmpowerID.Base.Services.Implementation;
using EmpowerID.Base.Services.Interface;
using EmpowerID.Data.Repository.Implementation;
using EmpowerID.Data.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Base.Extension
{
    public static class Registerer
    {
        public static void RegisterServiceComponents(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
