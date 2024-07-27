namespace DotNet_Core._2_LINQ;

public class Employee {
    public long Id { get; set; }
    public string Name { get; set; }
    public long Age { get; set; }
    public bool Gender { get; set; }
    public int Salary { get; set; }

    public Employee(int id, string name, long age, bool gender, int salary) {
        Id = id;
        Name = name;
        Age = age;
        Gender = gender;
        Salary = salary;
    }

    public override string ToString() {
        return $"id = {Id},name = {Name},age = {Age},gender = {Gender},salary = {Salary}";
    }
}

public class CommonLinqFunc {
    private List<Employee> _employees;

    public CommonLinqFunc() {
        _employees = new List<Employee>();
        _employees.Add(new Employee(1, "tom", 12, true, 1000));
        _employees.Add(new Employee(2, "jerry", 14, true, 2000));
        _employees.Add(new Employee(3, "smith", 10, true, 100));
        _employees.Add(new Employee(4, "qq", 13, false, 3000));
        _employees.Add(new Employee(5, "hh", 11, false, 5000));
        _employees.Add(new Employee(6, "girl", 14, false, 8000));
        _employees.Add(new Employee(7, "boy", 12, true, 1000));
        _employees.Add(new Employee(8, "cute girl", 14, false, 10000));
    }

    public void UseWhere() {
        var result = _employees.Where(item => item.Age > 10);
        foreach (var item in result) {
            Console.WriteLine(item);
        }
    }

    public void UseCount() {
        Console.WriteLine(_employees.Count());
        Console.WriteLine(_employees.Count(item => item.Salary > 5000));
    }
    
    public void UseAny() {
        Console.WriteLine(_employees.Any());
        Console.WriteLine(_employees.Any(item => item.Salary == 5000));
    }
    
    public void UseSingle() {
        var result = _employees.Single(item => item.Name == "tom");
        Console.WriteLine(result);
        
        result = _employees.SingleOrDefault(item => item.Name == "xxx");
        Console.WriteLine(result);

        result = _employees.First(item => item.Age > 12);
        Console.WriteLine(result);
        
        result = _employees.FirstOrDefault(item => item.Age > 32);
        Console.WriteLine(result);
    }

    public void UseOrder() {
        var result1 = _employees.Where(item => item.Salary > 4000);
        
        result1 = result1.OrderBy(item => item.Age);
        foreach (var item in result1) {
            Console.WriteLine(item);
        }

        var result2 = _employees.OrderByDescending(item => item.Salary);
        Console.WriteLine("=================");
        foreach (var item in result2) {
            Console.WriteLine(item);
        }

        var result3 = _employees.OrderBy(item => Guid.NewGuid());
        Console.WriteLine("=================");
        foreach (var item in result3) {
            Console.WriteLine(item);
        }
        
        var result4 = _employees.OrderBy(item => item.Age > 10).ThenBy(item => item.Salary < 1000);
        Console.WriteLine("=================");
        foreach (var item in result4) {
            Console.WriteLine(item);
        }
    }

    public void UseSkipAndTake() {
        var result = _employees.Skip(2).Take(3);
        foreach (var item in result) {
            Console.WriteLine(item);
        }
    }

    public void UseSelect() {
        var ageList = _employees.Select(item => item.Age);
        foreach (var age in ageList) {
            Console.Write(age + " ");
        }
    }

    public void UseToListAndToArray() {
        var salarys = _employees.Where(item => item.Salary > 4000)
            .Select(item => item.Salary);
        var list = salarys.ToList();
        foreach (var item in list) {
            Console.WriteLine(item);
        }

        Console.WriteLine("=========");
        
        var array = salarys.ToArray();
        foreach (var item in array) {
            Console.WriteLine(item);
        }
    }

    public void QueryGrammar() {
        var result = _employees.Where(e => e.Salary > 4000)
            .OrderBy(e => e.Age)
            .Select(e => new { e.Name, e.Age, Gender = e.Gender ? "男" : "女" });
        foreach (var item in result) {
            Console.WriteLine(item);
        }
        
        Console.WriteLine("===========================");

        var result2 = from e in _employees
            where e.Salary > 4000
            select new { e.Name, e.Age, Gender = e.Gender ? "男" : "女" };
        foreach (var item in result2) {
            Console.WriteLine(item);
        }
    }
}