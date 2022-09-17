using AutoMapper;
using MCV.Test.API.Data.Dtos;
using MCV.Test.API.Data.Entities;

namespace MCV.Test.API.Data.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Department, DepartmentResource>();
            CreateMap<Employee, EmployeeResource>();

            // Resource to Domain
            CreateMap<DepartmentResource, Department>();
            CreateMap<EmployeeResource, Employee>();

            CreateMap<SaveDepartmentResource, Department>();
            CreateMap<SaveEmployeeResource, Employee>();
        }
    }
}
