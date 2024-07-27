using EF_Core.dbConfig;

namespace EF_Core._4_RelationConfig._4_Paging; 

public class Paging {
    public void Page(int pageIndex, int pageSize) {
        var ctx = new MySqlDbContext();
        var queryBooks = ctx.Books.Where(book => !book.Author.Contains("刘慈欣"));
        var books = queryBooks.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        foreach (var book in books) {
            Console.WriteLine(book.Title + ", " + book.Author);
        }
        
        //计算总的页数
        long count = queryBooks.Count();
        long countPage = (long) Math.Ceiling(count * 1.0 / pageSize);
        Console.WriteLine("总的页数: " + countPage);
    }
}