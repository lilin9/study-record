namespace DotNet_Core._1_Async {
    public class WhenAll_ {
        public async Task Func() {
            var test1 = File.ReadAllTextAsync("D:\\Programming\\C#\\C#Frame\\DotNet Core\\DotNet Core\\1_Async\\Temp\\test_1.txt");
            var test2 = File.ReadAllTextAsync("D:\\Programming\\C#\\C#Frame\\DotNet Core\\DotNet Core\\1_Async\\Temp\\test_2.txt");
            var test3 = File.ReadAllTextAsync("D:\\Programming\\C#\\C#Frame\\DotNet Core\\DotNet Core\\1_Async\\Temp\\test_3.txt");

            var testArr = await Task.WhenAll(test1, test2, test3);
            for (int i = 0; i < testArr.Length; i++) {
                Console.WriteLine(testArr[i]);
            }
        }
    }
}
