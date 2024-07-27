namespace UserMgr.WebAPI;

[AttributeUsage(AttributeTargets.Method)]
public class UnitOfWorkAttribute(Type[] dbContextTypes) : Attribute {
    internal readonly Type[] DbContextTypes = dbContextTypes;
}