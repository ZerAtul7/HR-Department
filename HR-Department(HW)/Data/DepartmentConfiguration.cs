using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HR_Department_HW_.Models;


namespace HR_Department_HW_.Data
{
    public class DepartmentConfiguration :  IEntityTypeConfiguration<Department>
    {

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Table-Config:
            builder.ToTable("Departments");
            builder.HasKey(c => c.DepartmentId);
            builder.Property(c => c.DepartmentId).HasColumnType("int");

            // Column-2:
            builder.HasIndex(c => c.DepartmentName).IsUnique();
            builder.Property(c => c.DepartmentName).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);

            
        }
    }
}
