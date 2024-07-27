namespace EF_Core.entity;

public class OrgUnit {
    public long Id { get; set; }
    public string Name { get; set; }
    public OrgUnit? Parent { get; set; }
    public List<OrgUnit> Children { get; set; } = new List<OrgUnit>();
}