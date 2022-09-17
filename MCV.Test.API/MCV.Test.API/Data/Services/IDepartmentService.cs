using MCV.Test.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCV.Test.API.Data.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllWithEmployee();
        Task<Department> GetDepartmentById(int id);
        Task<Department> CreateDepartment(Department newDepartment);
        Task UpdateDepartment(Department DepartmentToBeUpdated, Department Department);
        Task DeleteDepartment(Department Department);
    }
}
