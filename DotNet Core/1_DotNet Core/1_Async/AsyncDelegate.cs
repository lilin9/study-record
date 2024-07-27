namespace DotNet_Core._1_Async {
    public class AsyncDelegate {
        public void FuncAsync() {
            ThreadPool.QueueUserWorkItem(async (obj) => {
                while (true) {
                    await File.WriteAllTextAsync(@"D:\Programming\C#\C#Frame\DotNet Core\DotNet Core\1_Async\test_3.txt",
                        "Hello");
                    Console.WriteLine("hello");
                }
            });
            Console.Read();
        }
    }
}
