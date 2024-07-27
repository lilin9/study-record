using EF_Core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.config; 

public class BookConfig: IEntityTypeConfiguration<Book> {
    public void Configure(EntityTypeBuilder<Book> builder) {
        //配置表名
        builder.ToTable("Db_Books");
        //设置约束条件：字段长度为 20，不能为空
        builder.Property(book => book.Title)
            .HasMaxLength(20)
            .IsRequired();
        builder.Property(book => book.Author)
            .HasMaxLength(20)
            .IsRequired();
    }
}