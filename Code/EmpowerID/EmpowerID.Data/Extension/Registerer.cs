using EmpowerID.Data.Repository.Implementation;
using EmpowerID.Data.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Data.Extension
{
    public static class Registerer
    {
        public static void RegisterComponents(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
