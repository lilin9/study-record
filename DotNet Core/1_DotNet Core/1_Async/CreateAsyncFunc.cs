using static System.IO.File;

namespace DotNet_Core._1_Async {
    public class CreateAsyncFunc {
        // public async Task DownloadHtmlAsync(string url, string filename) {
        //     using (HttpClient httpClient = new HttpClient()) {
        //         var html = await httpClient.GetStringAsync(url);
        //         await WriteAllTextAsync(filename, html);
        //     }
        // }
        public async Task<int> DownloadHtmlAsync(string url, string filename) {
            using var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            await WriteAllTextAsync(filename, html);
            return html.Length;
        }
    }
}
