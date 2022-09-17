using MCV.Test.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace MCV.Test.API.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            // Seed Roles
            #region Seeding Departments Data
            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Engineering" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "IT" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "CS" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 4, Name = "AI" });
            #endregion
            #region Seeding Employees Data
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name = "Ahmed",
                Title = "Software Engineer",
                BirthDate = new DateTime(1998, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                HiringDate = new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                DepartmentId = 1
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                Name = "Mohamed",
                Title = "Architect",
                BirthDate = new DateTime(1998, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                HiringDate = new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                DepartmentId = 1
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                Name = "Sayed",
                Title = "Doctor",
                BirthDate = new DateTime(1998, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                HiringDate = new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                DepartmentId = 2
            });
            #endregion

        }

    }
}
