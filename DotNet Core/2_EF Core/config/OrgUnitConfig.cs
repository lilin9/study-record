using EF_Core.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.config; 

public class OrgUnitConfig: IEntityTypeConfiguration<OrgUnit> {
    public void Configure(EntityTypeBuilder<OrgUnit> builder) {
        builder.ToTable("T_OrgUnits");
        //自引用结构中，根节点没有 parent，因此这个关系不可修饰为 不可为空
        builder.HasOne<OrgUnit>(ou => ou.Parent)
            .WithMany(ou => ou.Children);
    }
}