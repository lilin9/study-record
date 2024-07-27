using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserMgr.Domain.Entities;

namespace UserMgr.Infrastructure.Configs;

public class UserAccessFailConfig: IEntityTypeConfiguration<UserAccessFail> {
    public void Configure(EntityTypeBuilder<UserAccessFail> builder) {
        builder.ToTable("T_UserAccessFails");
        builder.Property("isLockOut");
    }
}