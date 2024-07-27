using EF_Core.dbConfig;
using Microsoft.EntityFrameworkCore;

namespace EF_Core._4_RelationConfig._5_ExecuteSql; 

public class ExecuteSql {
    public async Task Insert() {
        var title = "《心经》";
        var author = "唐玄奘";
        var pubTime = DateTime.Now.ToString("yy-MM-dd");
        var price = 123.4;
        
        var ctx = new MySqlDbContext();
        await ctx.Database.ExecuteSqlInterpolatedAsync(
            @$"INSERT INTO db_books(Title, Author, PubTime, Price) 
            VALUES({title}, {author}, {pubTime}, {price});"
        );
    }

    public void Select() {
        var author = "%刘%";
        
        var ctx = new MySqlDbContext();
        var books = ctx.Books.FromSqlInterpolated(
            $"SELECT * FROM db_books WHERE Author LIKE {author};"
        );
        
        foreach (var book in books) {
            Console.WriteLine(book.Title);
        }
    }
}