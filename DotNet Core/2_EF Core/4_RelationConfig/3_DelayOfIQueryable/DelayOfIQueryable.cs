using EF_Core.dbConfig;

namespace EF_Core._4_RelationConfig._3_DelayOfIQueryable; 

public class DelayOfIQueryable {
    public void Use() {
        var ctx = new MySqlDbContext();
        Console.WriteLine("准备执行 Where");
        var books = ctx.Books.Where(book => book.Title == "《三体》");
        Console.WriteLine("准备执行 foreach");
        foreach (var book in books) {
            Console.WriteLine(book.Title);
        }
    }
}