using System;

namespace MCV.Test.API.Data.Dtos
{
    public class SaveEmployeeResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Title { get; set; }
        public DateTime HiringDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
