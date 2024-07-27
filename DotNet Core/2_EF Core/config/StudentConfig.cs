using EF_Core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.config; 

public class StudentConfig: IEntityTypeConfiguration<Student> {
    public void Configure(EntityTypeBuilder<Student> builder) {
        builder.ToTable("T_Students");
        builder.HasMany<Teacher>(s => s.Teachers)
            .WithMany(t => t.Students)
            .UsingEntity(entity => entity.ToTable("T_Students_Teachers"));
    }
}