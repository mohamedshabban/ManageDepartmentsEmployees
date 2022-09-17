using MCV.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Database
{
    public class MCVDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Engineering" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "IT" });

            modelBuilder.Entity<Employee>().HasData(new Employee { Id = new Guid(), Name = "Ahmed",DepartmentId=1 });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = new Guid(), Name = "Mohamed", DepartmentId = 1 });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = new Guid(), Name = "Sayed", DepartmentId = 2 });                       
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
