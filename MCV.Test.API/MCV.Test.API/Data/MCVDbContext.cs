using MCV.Test.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace MCV.Test.API.Data
{

    public class MCVDbContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        public MCVDbContext(DbContextOptions<MCVDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .ApplyConfiguration(new DepartmentConfiguration());

            builder
                .ApplyConfiguration(new EmployeeConfiguration());

            ModelBuilderExtensions.Seed(builder);
        }
    }
}
