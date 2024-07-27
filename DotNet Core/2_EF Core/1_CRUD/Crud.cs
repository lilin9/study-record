using EF_Core.dbConfig;
using EF_Core.entity;

namespace EF_Core._1_CRUD; 

public class Crud {
    public async Task Insert() {
        await using var context = new MySqlDbContext();
        
        var person = new Person {
            Name = "tom",
            Age = 12
        };

        context.Persons.Add(person);
        await context.SaveChangesAsync();
    }

    public async Task Select() {
        await using var context = new MySqlDbContext();
        var books = context.Books.Where(book => book.Price <= 400);
        foreach (var book in books) {
            Console.WriteLine(book.Title + ", " + book.Author + ", " + book.PubTime + ", " + book.Price);
        }

        Console.WriteLine();

        var singleBook = context.Books.Single(book => book.Title == "《三国演义》");
        Console.WriteLine(singleBook.Title + ", " + singleBook.Author + ", " + singleBook.PubTime + ", " + singleBook.Price + "\n");

        var orderBooks = context.Books.Where(book => book.Price > 400).OrderBy(book => book.Price);
        foreach (var book in orderBooks) {
            Console.WriteLine(book.Title + ", " + book.Author + ", " + book.PubTime + ", " + book.Price);
        }
    }

    public async Task UpdateAndDelet() {
        await using var context = new MySqlDbContext();

        var book = context.Books.Single(book => book.Title == "《带上她的眼睛》");
        book.Author = "Mr.Liu";

        var singleBook = context.Books.Single(book => book.Id == 6);
        context.Books.Remove(singleBook);

        await context.SaveChangesAsync();
    }
}




