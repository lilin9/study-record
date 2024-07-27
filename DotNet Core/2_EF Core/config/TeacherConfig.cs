using EF_Core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.config; 

public class TeacherConfig: IEntityTypeConfiguration<Teacher> {
    public void Configure(EntityTypeBuilder<Teacher> builder) {
        builder.ToTable("T_Teachers");
    }
}