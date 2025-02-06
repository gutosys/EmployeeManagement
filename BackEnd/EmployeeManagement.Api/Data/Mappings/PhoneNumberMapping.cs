using EmployeeManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Api.Data.Mappings
{
    public class PhoneNumberMapping : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(
            EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumber");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                    .IsRequired(true)
                    .HasColumnType("NVARCHAR")
            .HasMaxLength(30);
        }
    }
}