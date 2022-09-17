using MCV.Test.API.Data.Repositores;
using System.Threading.Tasks;

namespace MCV.Test.API.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MCVDbContext _context;
        private DepartmentRepository _DepartmentRepository;
        private EmployeeRepository _EmployeeRepository;

        public UnitOfWork(MCVDbContext context)
        {
            this._context = context;
        }

        public IDepartmentRepository Departments => _DepartmentRepository = _DepartmentRepository ?? new DepartmentRepository(_context);

        public IEmployeeRepository Employees => _EmployeeRepository = _EmployeeRepository ?? new EmployeeRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
