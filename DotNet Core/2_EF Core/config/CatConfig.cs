using EF_Core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.config; 

public class CatConfig: IEntityTypeConfiguration<Cat> {
    public void Configure(EntityTypeBuilder<Cat> builder) {
        //配置表名
        builder.ToTable("Db_Cats");
    }
}