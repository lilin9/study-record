using EF_Core.dbConfig;
using EF_Core.entity;

namespace EF_Core._4_RelationConfig._1_OneToMany;

public class SelfReferenceStruct {
    public async Task CreateStruct() {
        var gxOrgUnit = new OrgUnit { Name = "广西省" };

        var glOrgUnit = new OrgUnit { Name = "桂林市" };
        glOrgUnit.Parent = gxOrgUnit;

        var qzOrgUnit = new OrgUnit { Name = "钦州市" };
        qzOrgUnit.Parent = gxOrgUnit;

        var lcOrgUnit = new OrgUnit { Name = "灵川县" };
        lcOrgUnit.Parent = glOrgUnit;

        var zyOrgUnit = new OrgUnit { Name = "资源县" };
        zyOrgUnit.Parent = glOrgUnit;

        var qnOrgUnit = new OrgUnit { Name = "钦南区" };
        qnOrgUnit.Parent = qzOrgUnit;

        var qbOrgUnit = new OrgUnit { Name = "钦北区" };
        qbOrgUnit.Parent = qzOrgUnit;

        await using var ctx = new MySqlDbContext();
        ctx.OrgUnits.Add(gxOrgUnit);
        ctx.OrgUnits.Add(glOrgUnit);
        ctx.OrgUnits.Add(qzOrgUnit);
        ctx.OrgUnits.Add(lcOrgUnit);
        ctx.OrgUnits.Add(zyOrgUnit);
        ctx.OrgUnits.Add(qnOrgUnit);
        ctx.OrgUnits.Add(qbOrgUnit);
        await ctx.SaveChangesAsync();
    }

    public void Print() {
        using var ctx = new MySqlDbContext();
        var rootOrgUnit = ctx.OrgUnits.Single(org => org.Parent == null);
        Console.WriteLine(rootOrgUnit.Name);
        PrintStruct(1, ctx, rootOrgUnit);
    }

    static void PrintStruct(int identLevel, MySqlDbContext ctx, OrgUnit parent) {
        var children = ctx.OrgUnits.Where(org => org.Parent == parent).ToList();
        foreach (var child in children) {
            Console.WriteLine(new string(' ', identLevel) + child.Name);
            //打印以我（child）为父节点的子节点
            PrintStruct(identLevel + 1, ctx, child);
        }
    }
}