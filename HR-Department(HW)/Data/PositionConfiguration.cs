
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HR_Department_HW_.Models;

namespace HR_Department_HW_.Data
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            // Table-Config:
            builder.ToTable("Positions");
            builder.HasKey(c => c.PositionId);
            builder.Property(c => c.PositionId).HasColumnType("int");

            // Column-2:
            builder.HasIndex(c => c.PositionName).IsUnique();
            builder.Property(c => c.PositionName).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(c => c.PositionSalary).IsRequired().HasColumnType("money");
        }
    }
}
