using AutoMapper;
using EmpowerID.Base.CustomModel;
using EmpowerID.Base.Services.Interface;
using EmpowerID.Base.ViewModel;
using EmpowerID.Data.Model;
using EmpowerID.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmpowerID.Base.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        public IDepartmentRepository _departmentRepo;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepo, IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }
        public async Task<Response> GetDepartmentById(int id)
        {
            Response res = new Response();
            try
            {
                res.IsSuccess = true;
                res.Result = _mapper.Map<DepartmentVM>(await _departmentRepo.FindAsync(id));
            }
            catch (Exception ex)
            {
                res.Message = "No Records Found !";
            }
            return res;
        }
        public async Task<Response> GetDepartments()
        {
            Response res = new Response();
            try
            {
                res.IsSuccess = true;
                res.Result = _mapper.Map<List<DepartmentVM>>(await _departmentRepo.GetAllQuerable().ToListAsync().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                res.Message = "No Records Found !";
                //logs
            }
            return res;
        }
    }
}
