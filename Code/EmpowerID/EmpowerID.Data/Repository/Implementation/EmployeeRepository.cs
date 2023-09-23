using EmpowerID.Data.Data;
using EmpowerID.Data.Model;
using EmpowerID.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Data.Repository.Implementation
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDataContext context) : base(context)
        {

        }
        public AppDataContext _applicationDBContext
        {
            get { return Context as AppDataContext; }
        }
    }
}
