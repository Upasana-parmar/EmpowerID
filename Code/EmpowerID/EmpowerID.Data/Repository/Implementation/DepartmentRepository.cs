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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDataContext context) : base(context)
        {
            if (context.Departments != null && !context.Departments.Any())
            {
                List<Department> Departments = new List<Department>();

                Departments.Add(new Department
                {
                    Name = "Information Tech",
                    Description = "Information Tech.",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                });

                Departments.Add(new Department
                {
                    Name = "Human Resource",
                    Description = "Human Resource",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                });

                context.Departments.AddRange(Departments);
                context.SaveChanges();
            }
        }
        public AppDataContext _applicationDBContext { 
            get { return Context as AppDataContext; } 
        }
    }
}
