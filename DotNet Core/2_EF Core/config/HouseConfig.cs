using EF_Core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.config; 

public class HouseConfig: IEntityTypeConfiguration<House> {
    public void Configure(EntityTypeBuilder<House> builder) {
        builder.ToTable("Db_Houses");
        builder.Property(h => h.Owner).IsConcurrencyToken();
    }
}