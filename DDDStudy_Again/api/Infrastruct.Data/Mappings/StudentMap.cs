using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings {
    public class StudentMap: IEntityTypeConfiguration<Student> {
        /// <summary>
        /// 配置实体属性
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Student> builder) {
            builder.Property(s => s.Id)
                .HasColumnName("Id");

            builder.Property(s => s.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(s => s.Phone)
                .HasColumnType("varchar(100)")
                .HasMaxLength(20)
                .IsRequired();

            builder.OwnsOne(s => s.Address);
        }
    }
}
