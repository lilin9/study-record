namespace DotNet_Core._2_LINQ; 

public class UseLinq {
    public void Func() {
        int[] nums = { 10, 40, 3, 20, 1, 33, 60 };
        var nums2 = nums.Where(item => item > 10);
        foreach (var item in nums2) {
            Console.WriteLine(item);
        }
    }

    public void Func2() {
        int[] nums = { 10, 40, 3, 20, 1, 33, 60 };
        var myLinq = new MyLinq();
        var result = myLinq.MyWhere(nums, item => item > 10);
        
        foreach (var item in result) {
            Console.Write(item + " ");
        }
    }
    public void Func3() {
        int[] nums = { 10, 40, 3, 20, 1, 33, 60 };
        var myLinq = new MyLinq();
        var result = myLinq.MyWhere2(nums, item => item > 10);
        
        foreach (var item in result) {
            Console.Write(item + " ");
        }
    }
}