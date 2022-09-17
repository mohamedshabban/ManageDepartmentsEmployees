using MCV.Test.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCV.Test.API.Data.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> CreateEmployee(Employee newEmployee);
        Task UpdateEmployee(Employee EmployeeToBeUpdated, Employee Employee);
        Task DeleteEmployee(Employee Employee);
    }
}
