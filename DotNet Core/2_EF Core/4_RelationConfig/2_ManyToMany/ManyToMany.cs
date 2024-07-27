using EF_Core.dbConfig;
using EF_Core.entity;
using Microsoft.EntityFrameworkCore;

namespace EF_Core._4_RelationConfig._2_ManyToMany; 

public class ManyToMany {
    public async Task Insert() {
        var s1 = new Student { Name = "张三" };
        var s2 = new Student { Name = "李四" };
        var s3 = new Student { Name = "王五" };

        var t1 = new Teacher { Name = "李耳" };
        var t2 = new Teacher { Name = "孔丘" };
        var t3 = new Teacher { Name = "释迦牟尼" };
        
        s1.Teachers.Add(t1);
        s1.Teachers.Add(t2);
        
        s2.Teachers.Add(t2);
        s2.Teachers.Add(t3);
        
        s3.Teachers.Add(t1);
        s3.Teachers.Add(t2);
        s3.Teachers.Add(t3);

        await using (var ctx = new MySqlDbContext()) {
            ctx.Teachers.Add(t1);
            ctx.Teachers.Add(t2);
            ctx.Teachers.Add(t3);

            ctx.Students.Add(s1);
            ctx.Students.Add(s2);
            ctx.Students.Add(s3);

            await ctx.SaveChangesAsync();
        }
    }

    public async Task Select() {
        var ctx = new MySqlDbContext();

        var teachers = ctx.Teachers.Include(tea => tea.Students);
        foreach (var teacher in teachers) {
            Console.WriteLine(teacher.Name);
            foreach (var student in teacher.Students) {
                Console.WriteLine("\t" + student.Name);
            }
        }
    }
}