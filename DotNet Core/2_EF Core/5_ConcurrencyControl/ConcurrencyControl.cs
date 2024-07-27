using EF_Core.dbConfig;
using EF_Core.entity;
using Microsoft.EntityFrameworkCore;

namespace EF_Core._5_ConcurrencyControl._1_Pessimism;

public class ConcurrencyControl {
    public void Insert() {
        var h1 = new House { Name = "a-215" };
        var h2 = new House { Name = "b-314" };

        var ctx = new MySqlDbContext();
        ctx.Houses.Add(h1);
        ctx.Houses.Add(h2);
        ctx.SaveChanges();
    }

    //悲观锁
    public void PessimismLock() {
        Console.WriteLine("请输出你的名字: ");
        var name = Console.ReadLine();

        using var ctx = new MySqlDbContext();
        using var tx = ctx.Database.BeginTransaction();
        Console.WriteLine(DateTime.Now + "准备 select for update");
        var h = ctx.Houses.FromSqlInterpolated(
            $"select * from db_Houses where Id=1 for update"
        ).Single();
        if (!string.IsNullOrEmpty(h.Owner)) {
            if (h.Name == name) {
                Console.WriteLine("房子已经被你抢到了");
            } else {
                Console.WriteLine($"房子已经被{h.Owner}抢了");
            }

            Console.ReadKey();
        }

        h.Owner = name;
        Thread.Sleep(5000);
        Console.WriteLine("恭喜你，抢到了");
        ctx.SaveChanges();
        Console.WriteLine(DateTime.Now + "保存完成");
        tx.Commit();
        Console.ReadKey();
    }
    
    //乐观锁
    public void OptimisticLock() {
        Console.WriteLine("请输出你的名字: ");
        var name = Console.ReadLine();

        using var ctx = new MySqlDbContext();
        Console.WriteLine(DateTime.Now + "准备 select for update");
        var h = ctx.Houses.FromSqlInterpolated(
            $"select * from db_Houses where Id=1"
        ).Single();
        if (!string.IsNullOrEmpty(h.Owner)) {
            if (h.Name == name) {
                Console.WriteLine("房子已经被你抢到了");
            } else {
                Console.WriteLine($"房子已经被{h.Owner}抢了");
            }

            Console.ReadKey();
        }

        h.Owner = name;
        try {
            ctx.SaveChanges();
        } catch (DbUpdateConcurrencyException e) {
            Console.WriteLine("并发访问冲突");
            var entry1 = e.Entries.First();
            string newValue = entry1.GetDatabaseValues().GetValue<string>("Owner");
            Console.WriteLine($"被{newValue}抢先了");
            throw;
        }
    }
}