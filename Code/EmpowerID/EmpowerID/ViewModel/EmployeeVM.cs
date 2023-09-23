using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpowerID.ViewModel
{
    public class EmployeeVM
    {
        public EmployeeVM() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentVM Department { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public SelectList Departments { get; set; }
    }
}
