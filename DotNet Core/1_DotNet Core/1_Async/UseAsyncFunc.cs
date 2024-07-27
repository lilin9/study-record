namespace DotNet_Core._1_Async {
    public class UseAsyncFunc {
        public async Task WriteAsync() {
            string fileName = @"D:\Programming\C#\C#Frame\DotNet Core\DotNet Core\1_Async\test_1.txt";
            await File.WriteAllTextAsync(fileName, "hello");
            string text = await File.ReadAllTextAsync(fileName);
            Console.WriteLine(text);
        }
    }
}
