using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserMgr.Domain.Entities;

namespace UserMgr.Infrastructure.Configs;

public class UserConfig: IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.ToTable("T_Users");
        builder.OwnsOne(x => x.PhoneNumber, nb => {
            nb.Property(b => b.Number).HasMaxLength(20).IsUnicode(false);
        });
        builder.HasOne(b => b.UserAccessFail).WithOne(f => f.User).HasForeignKey<UserAccessFail>(f => f.UserId);
        builder.Property("passwordHash").HasMaxLength(100).IsUnicode(false);
    }
}