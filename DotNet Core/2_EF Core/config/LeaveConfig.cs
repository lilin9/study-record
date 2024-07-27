using EF_Core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.config; 

public class LeaveConfig: IEntityTypeConfiguration<Leave> {
    public void Configure(EntityTypeBuilder<Leave> builder) {
        builder.ToTable("T_Leaves");
        builder.HasOne<User>(u => u.Requester)
            .WithMany()
            .IsRequired();
        builder.HasOne<User>(u => u.Approver)
            .WithMany();
    }
}