using EF_Core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.config; 

public class CommentConfig: IEntityTypeConfiguration<Comment> {
    public void Configure(EntityTypeBuilder<Comment> builder) {
        builder.ToTable("T_Comments");
        builder.Property(comment => comment.Message).IsRequired().IsRequired();

        builder.HasOne<Article>(article => article.Article)
            .WithMany(comment => comment.Comments)
            .IsRequired();
    }
}