using MCV.Test.API.Data.Dtos;
using MCV.Test.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MCV.Test.API.Data.Repositores
{
    public class DepartmentRepository : Repository<Department>,IDepartmentRepository
    {

        public DepartmentRepository(MCVDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var data= await MCVDbContext.Departments.ToListAsync();
            return data;
        }

        public bool UpdateDepartment(DepartmentResource updatedDepartment)
        {
            throw new NotImplementedException();
        }
        private MCVDbContext MCVDbContext
        {
            get { return Context as MCVDbContext; }
        }
    }
}
