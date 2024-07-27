using EF_Core.dbConfig;
using EF_Core.entity;

namespace EF_Core._2_Keys; 

public class Keys {
    /**
     * 自增主键
     */
    public async Task AutoChangeKey() {
        await using var context = new MySqlDbContext();

        var person = new Person {
            Name = "tom",
            Age = 14
        };
        Console.WriteLine(person.Id);
        
        //EF Core会自动把数据 ID 更新到实体中
        context.Persons.Add(person);
        await context.SaveChangesAsync();

        Console.WriteLine(person.Id);
    }

    /**
     * Guid 类型主键
     */
    public async Task GuidKey() {
        await using var context = new MySqlDbContext();

        var cat = new Cat {
            Name = "mimi"
        };

        Console.WriteLine(cat.Id);
        
        context.Cats.Add(cat);
        await context.SaveChangesAsync();

        Console.WriteLine(cat.Id);
        
    }
}