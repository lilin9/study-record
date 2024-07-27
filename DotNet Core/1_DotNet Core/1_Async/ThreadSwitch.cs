using System.Text;

namespace DotNet_Core._1_Async {
    public class ThreadSwitch {
        public async Task FuncAsync() {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            var sb = new StringBuilder();
            for (int i = 0; i < 10000; i++) {
                sb.Append("hello world\n");
            }

            await File.WriteAllTextAsync("D:\\Programming\\C#\\C#Frame\\DotNet Core\\DotNet Core\\1_Async\\Temp\\test_3.txt",
                sb.ToString());

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

        }
    }
}
