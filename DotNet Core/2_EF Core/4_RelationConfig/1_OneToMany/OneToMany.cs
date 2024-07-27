using EF_Core.dbConfig;
using EF_Core.entity;
using Microsoft.EntityFrameworkCore;

namespace EF_Core._4_RelationConfig._1_OneToMany;

public class OneToMany {
    public void Insert() {
        using var context = new MySqlDbContext();

        var article = new Article {
            Title = "逍遥游",
            Content = "北冥有鱼，其名为鲲。鲲之大，不知其几千里也。化而为鸟，其名为鹏。鹏之背，不知其几千里也。"
        };

        var comment1 = new Comment {
            Message = "鲲之大，一锅炖不下",
            Article = article
        };
        var comment2 = new Comment {
            Message = "鹏之大，背上盖高楼",
            Article = article
        };
        
        article.Comments.Add(comment1);
        article.Comments.Add(comment2);

        context.Add(article);
        context.SaveChanges();
    }

    public void Select() {
        using var context = new MySqlDbContext();

        var article = context.Articles
            .Include(art => art.Comments)
            .Single(art => art.Id == 1);

        Console.WriteLine(article.Id + ", " + article.Content);
        foreach (var comment in article.Comments) {
            Console.WriteLine(comment.Id + ", " + comment.Message);
        }
    }

    public void SelectFixedColumn() {
        using var context = new MySqlDbContext();
        var result = context.Articles
            .Select(art => new { art.Id, art.Title })
            .First();
        Console.WriteLine(result.Id + ", ", result.Title);
    }
}