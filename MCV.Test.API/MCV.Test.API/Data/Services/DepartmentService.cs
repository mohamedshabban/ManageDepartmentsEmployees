using MCV.Test.API.Data.Entities;
using MCV.Test.API.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCV.Test.API.Data.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Department> CreateDepartment(Department newDepartment)
        {
            await _unitOfWork.Departments.AddAsync(newDepartment);
            await _unitOfWork.CommitAsync();
            return newDepartment;
        }

        public async Task DeleteDepartment(Department Department)
        {
            _unitOfWork.Departments.Remove(Department);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Department>> GetAllWithEmployee()
        {
            var data= await _unitOfWork.Departments
                .GetAllAsync();
            return data;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _unitOfWork.Departments
                .GetByIdAsync(id);
        }
       

        public async Task UpdateDepartment(Department DepartmentToBeUpdated, Department Department)
        {
            DepartmentToBeUpdated.Name = Department.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
