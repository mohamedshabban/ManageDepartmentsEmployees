using MCV.Test.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCV.Test.API.Data
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.HiringDate)
                .IsRequired();
            builder
                .Property(m => m.BirthDate)
                .IsRequired();
            builder
                .HasOne(m => m.Department)
                .WithMany(a => a.Employees)
                .HasForeignKey(m => m.DepartmentId);
            builder
                .ToTable("Employees");
        }
    }
}
