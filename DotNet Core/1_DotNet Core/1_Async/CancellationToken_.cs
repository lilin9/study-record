namespace DotNet_Core._1_Async {
    public class CancellationToken_ {
        public async Task DownloadNoneAsync(string url, int n) {
            using var httpClien = new HttpClient();
            for (int i = 0; i < n; i++) {
                var html = await httpClien.GetStringAsync(url);
                Console.WriteLine($"{DateTime.Now}: {html}");
            }
        }
        public async Task DownloadAsync(string url, int n, CancellationToken cancellationToken) {
            using var httpClien = new HttpClient();
            for (int i = 0; i < n; i++) {
                var html = await httpClien.GetStringAsync(url);
                Console.WriteLine($"{DateTime.Now}: {html}");

                if (cancellationToken.IsCancellationRequested) {
                    Console.WriteLine("下载被取消");
                    break;
                }
            }
        }
    }
}
