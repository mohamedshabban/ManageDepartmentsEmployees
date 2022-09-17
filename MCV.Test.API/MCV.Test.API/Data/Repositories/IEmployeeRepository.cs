using MCV.Test.API.Data.Dtos;
using MCV.Test.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCV.Test.API.Data.Repositores
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllAsync();

    }
}
