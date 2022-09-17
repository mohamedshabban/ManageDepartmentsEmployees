using AutoMapper;
using MCV.Test.API.Data;
using MCV.Test.API.Data.Dtos;
using MCV.Test.API.Data.Entities;
using MCV.Test.API.Data.Repositores;
using MCV.Test.API.Data.Services;
using MCV.Test.API.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCV.Test.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeAPIController(IEmployeeService employeeService, IMapper mapper)
        {
            this._employeeService = employeeService;
            this._mapper = mapper;
        }
        [HttpGet("list")]
        [Produces("application/json")]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployees();

                if (employees == null)
                    return NotFound();
                var employeesResources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employees);

                return Ok(employeesResources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<EmployeeResource>> CreateEmployee(SaveEmployeeResource saveEmployeeResource)
        {
            try
            {
                var validator = new SaveEmployeeResourceValidator();
                var validationResult = await validator.ValidateAsync(saveEmployeeResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); 

                var EmployeeToCreate = _mapper.Map<SaveEmployeeResource, Employee>(saveEmployeeResource);

                var newEmployee = await _employeeService.CreateEmployee(EmployeeToCreate);

                var Employee = await _employeeService.GetEmployeeById(newEmployee.Id);

                var EmployeeResource = _mapper.Map<Employee, EmployeeResource>(Employee);

                return Ok(EmployeeResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] SaveEmployeeResource saveEmployeeResource)
        {
            try
            {
                var validator = new SaveEmployeeResourceValidator();
                var validationResult = await validator.ValidateAsync(saveEmployeeResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var EmployeeToBeUpdated = await _employeeService.GetEmployeeById(id);

                if (EmployeeToBeUpdated == null)
                    return NotFound();

                var Employee = _mapper.Map<SaveEmployeeResource, Employee>(saveEmployeeResource);               
                await _employeeService.UpdateEmployee(EmployeeToBeUpdated, Employee);

                var updatedEmployee = await _employeeService.GetEmployeeById(id);

                var updatedEmployeeResource = _mapper.Map<Employee, EmployeeResource>(updatedEmployee);

                return Ok(updatedEmployeeResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var Employee = await _employeeService.GetEmployeeById(id);
            if (Employee == null)
                return NotFound();

            await _employeeService.DeleteEmployee(Employee);

            return NoContent();
        }
    }
}
