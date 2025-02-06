using EmployeeManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings;

public class EmployeeMapping : IEntityTypeConfiguration<Employee>
{
    public void Configure(
        EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");

        builder.HasKey(x => x.Id);

        //public string Password { get; set; } = string.Empty;

        builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(300);

        builder.Property(x => x.LastName)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(300);

        builder.Property(x => x.Email)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(300);

        builder.Property(x => x.DocumentId)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(300);

        builder.Property(x => x.DateOfBirth)
            .IsRequired(true)
            .HasColumnType("DATE");

        builder.Property(x => x.EEmployeeType)
            .IsRequired(true)
            .HasColumnType("INTEGER");

        builder.Property(x => x.Password)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(300);

        builder.Property(x => x.UserId)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        builder.HasMany(e => e.PhoneNumbers)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired();
    }
}