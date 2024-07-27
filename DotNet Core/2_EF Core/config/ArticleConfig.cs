using EF_Core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.config; 

public class ArticleConfig: IEntityTypeConfiguration<Article> {
    public void Configure(EntityTypeBuilder<Article> builder) {
        builder.ToTable("T_Articles");
        builder.Property(article => article.Title).HasMaxLength(100).IsUnicode().IsRequired();
        builder.Property(article => article.Content).IsUnicode().IsRequired();
    }
}