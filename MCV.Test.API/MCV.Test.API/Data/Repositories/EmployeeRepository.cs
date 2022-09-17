using MCV.Test.API.Data.Dtos;
using MCV.Test.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCV.Test.API.Data.Repositores
{
    public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(MCVDbContext dbContext):base(dbContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var data = await Task.FromResult( MCVDbContext.Employees.Include(c=>c.Department));
             
            return data;
        }
        private MCVDbContext MCVDbContext
        {
            get { return Context as MCVDbContext; }
        }
    }
}
