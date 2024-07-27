using EF_Core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.config; 

public class PersonConfig: IEntityTypeConfiguration<Person> {
    public void Configure(EntityTypeBuilder<Person> builder) {
        //配置表名
        builder.ToTable("Db_Persons");
    }
}