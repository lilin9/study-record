namespace DotNet_Core._2_LINQ; 

public class MyLinq {
    public IEnumerable<int> MyWhere(IEnumerable<int> items, Func<int, bool> method) {
        var result = new List<int>();
        foreach (var item in items) {
            if (method(item)) {
                result.Add(item);
            }
        }

        return result;
    }
    public IEnumerable<int> MyWhere2(IEnumerable<int> items, Func<int, bool> method) {
        foreach (var item in items) {
            if (method(item)) {
                yield return item;
            }
        }
    }
}