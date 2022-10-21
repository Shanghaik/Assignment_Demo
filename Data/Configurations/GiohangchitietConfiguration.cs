using Data.ModelsClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    internal class GiohangchitietConfiguration : IEntityTypeConfiguration<Giohangchitiet>
    {
        public void Configure(EntityTypeBuilder<Giohangchitiet> builder)
        {
            builder.ToTable("GiohangChitiet");
            builder.HasKey(o => new { o.IDGiohang, o.IDSanpham });
            builder.Property(c => c.Soluong).HasColumnName("Soluong").
                HasColumnType("Decimal").IsRequired();
            builder.Property(c => c.Gia).HasColumnName("Giatien").
                HasColumnType("decimal").IsRequired();
            // Khóa ngoại
            builder.HasOne<Giohang>(e => e.Giohang)
                .WithMany(c => c.Giohangchitiets)
                .HasForeignKey(c => c.IDGiohang)
                .HasConstraintName("FK_Giohang")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<Sanpham>(e => e.Sanpham)
                .WithMany(c => c.Giohangchitiets)
                .HasForeignKey(c => c.IDSanpham)
                .HasConstraintName("FK_Sanpham")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
