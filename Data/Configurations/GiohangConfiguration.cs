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
    internal class GiohangConfiguration : IEntityTypeConfiguration<Giohang>
    {
        public void Configure(EntityTypeBuilder<Giohang> builder)
        {
            builder.ToTable("Giohang");
            builder.HasKey(x => x.ID);
            builder.Property(c => c.ID).HasDefaultValueSql("NEWID()");
            builder.Property(c => c.TrangThai).HasColumnName("Trangthai").
                HasColumnType("bit").IsRequired();
            builder.Property(c => c.IDKhach).HasColumnName("IDKhach").IsRequired();
        }
    }
}
