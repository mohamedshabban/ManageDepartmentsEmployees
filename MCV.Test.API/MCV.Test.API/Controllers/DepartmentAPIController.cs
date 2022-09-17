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
using System.Linq;
using System.Threading.Tasks;

namespace MCV.Test.API.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentAPIController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        private readonly IMapper _mapper;

        public DepartmentAPIController(IDepartmentService DepartmentService, IMapper mapper)
        {
            this._DepartmentService = DepartmentService;
            this._mapper = mapper;
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            try
            {
                var Departments = await _DepartmentService.GetAllWithEmployee();
                if (Departments == null)
                    return NotFound();
                var DepartmentResources = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(Departments);
                return Ok(DepartmentResources);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<DepartmentResource>> CreateDepartment([FromBody] SaveDepartmentResource saveDepartmentResource)
        {
            try
            {
                var validator = new SaveDepartmentResourceValidator();
                var validationResult = await validator.ValidateAsync(saveDepartmentResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok
                Department newDepartment=new Department() { Id=saveDepartmentResource.Id,Name=saveDepartmentResource.Name};
                var addedDepartment = await _DepartmentService.CreateDepartment(newDepartment);
                return Ok(addedDepartment);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentResource>> UpdateDepartment(int id, [FromBody] SaveDepartmentResource saveDepartmentResource)
        {
            var validator = new SaveDepartmentResourceValidator();
            var validationResult = await validator.ValidateAsync(saveDepartmentResource);
            if (id == 0 || !validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var DepartmentToBeUpdate = await _DepartmentService.GetDepartmentById(id);
            if (DepartmentToBeUpdate == null)
                return NotFound();
            var Department = _mapper.Map<SaveDepartmentResource, Department>(saveDepartmentResource);

            if (DepartmentToBeUpdate == null)
                return NotFound();

            await _DepartmentService.UpdateDepartment(DepartmentToBeUpdate,Department);

            var updatedDepartment = await _DepartmentService.GetDepartmentById(id);
            var updatedDepartmentResource = _mapper.Map<Department, DepartmentResource>(updatedDepartment);

            return Ok(updatedDepartmentResource);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            if (id == 0)
                return BadRequest();

            var Department = await _DepartmentService.GetDepartmentById(id);

            if (Department == null)
                return NotFound();

            await _DepartmentService.DeleteDepartment(Department);

            return NoContent();
        }
    }
}
