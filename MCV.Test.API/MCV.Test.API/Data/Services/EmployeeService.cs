using MCV.Test.API.Data.Entities;
using MCV.Test.API.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCV.Test.API.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            await _unitOfWork.Employees.AddAsync(newEmployee);
            await _unitOfWork.CommitAsync();
            return newEmployee;
        }

        public async Task DeleteEmployee(Employee Employee)
        {
            _unitOfWork.Employees.Remove(Employee);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _unitOfWork.Employees.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _unitOfWork.Employees.GetByIdAsync(id);
        }

        public async Task UpdateEmployee(Employee EmployeeToBeUpdated, Employee Employee)
        {
            EmployeeToBeUpdated.Name = Employee.Name;
            EmployeeToBeUpdated.BirthDate = Employee.BirthDate;
            EmployeeToBeUpdated.HiringDate = Employee.HiringDate;
            EmployeeToBeUpdated.Title = Employee.Title;
            await _unitOfWork.CommitAsync();
        }
    }
}
