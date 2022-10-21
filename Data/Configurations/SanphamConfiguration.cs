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
    internal class SanphamConfiguration : IEntityTypeConfiguration<Sanpham>
    {
        public void Configure(EntityTypeBuilder<Sanpham> builder)
        {
            builder.ToTable("Sanpham");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).HasDefaultValueSql("NEWID()");
            builder.Property(c => c.Trangthai).HasColumnName("Trangthai").
                HasColumnType("bit").IsRequired();
            builder.Property(c => c.Ten).HasColumnName("Ten").
                HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(c => c.Soluong).HasColumnName("Soluong").
                HasColumnType("int").IsRequired();
            builder.Property(c => c.Gia).HasColumnName("Giatien").
                HasColumnType("decimal").IsRequired();
        }
    }
}
