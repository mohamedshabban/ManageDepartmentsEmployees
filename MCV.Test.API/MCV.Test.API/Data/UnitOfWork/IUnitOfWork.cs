using MCV.Test.API.Data.Repositores;
using System;
using System.Threading.Tasks;

namespace MCV.Test.API.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Departments { get; }
        IEmployeeRepository Employees { get; }
        Task<int> CommitAsync();
    }
}
