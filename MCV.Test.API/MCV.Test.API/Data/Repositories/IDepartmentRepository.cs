using MCV.Test.API.Data.Dtos;
using MCV.Test.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCV.Test.API.Data.Repositores
{

    public interface IDepartmentRepository:IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllAsync();
        //List<Department> GetAllDepartmentAsync();
        //Department GetDepartment(int Id);
        bool UpdateDepartment(DepartmentResource updatedDepartment);
        //bool AddNewDepartment(DepartmentDto updatedDepar);

        //bool DeleteDepartment(int Id);
    }
}
