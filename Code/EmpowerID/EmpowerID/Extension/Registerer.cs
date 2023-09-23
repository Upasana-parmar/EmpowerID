using EmpowerID.Service.Implementation;
using EmpowerID.Service.Interface;

namespace EmpowerID.Extension
{
    public static class Registerer
    {
        public static void RegisterServiceComponents(this IServiceCollection services)
        {
            services.AddScoped<IAPIService, APIService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
