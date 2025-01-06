using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HR_Department_HW_.Models;

namespace HR_Department_HW_.Data
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {

        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            // Table-Config:
            builder.ToTable("Workers");
            builder.HasKey(c => c.WorkerId);
            builder.Property(c => c.WorkerId).HasColumnType("int");

            // Column-2:
            builder.Property(c => c.WorkerName).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);

            // Column-3:
            builder.Property(c => c.WorkerSurname).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);

            // Column-4:
            builder.Property(c => c.WorkerAge).IsRequired().HasColumnType("int").HasMaxLength(2);

            // Column-5:

            builder.Property(c => c.MillitaryDocument).IsRequired().HasColumnType("bit");

            // Column-6:

            builder.Property(c => c.RKNOPP).IsRequired().HasColumnType("int").HasMaxLength(10);

            // Column-7:

            builder.Property(c => c.PasportSerial).IsRequired().HasColumnType("int").HasMaxLength(9);

            // Column-8:

            builder.Property(c => c.BachelorGrade).IsRequired().HasColumnType("bit");

            // Column-9:

            builder.Property(c => c.TotalECTS).IsRequired().HasColumnType("int");

            // Column-10:

            builder.Property(c => c.PositionId).IsRequired().HasColumnType("int");
            builder.HasOne(mt => mt.Position).WithMany(c => c.Workers).HasForeignKey(mt => mt.PositionId);

            // Column-11:

            builder.Property(c => c.DepartmentId).IsRequired().HasColumnType("int");
            builder.HasOne(mt => mt.Department).WithMany(c => c.Workers).HasForeignKey(mt => mt.DepartmentId);

        }
    }
}
