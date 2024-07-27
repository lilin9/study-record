using EF_Core.dbConfig;
using EF_Core.entity;
using Microsoft.EntityFrameworkCore;

namespace EF_Core._3_ViewSql;

public class ViewSql {
    public async Task Use() {
        await using var context = new MySqlDbContext();
        // var book = context.Books.Single(book => book.Title == "《三体》");
        // var sql = book.ToQueryString();
        // Console.WriteLine("title=" + book.Title + " author=" + book.Author + " price=" + book.Price);

        IQueryable<Book> book = context.Books.Where(book => book.Title == "《三体》");
        var sql = book.ToQueryString();
        Console.WriteLine(sql);
    }
}