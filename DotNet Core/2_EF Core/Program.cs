// See https://aka.ms/new-console-template for more information

string? UploadFiles(string filePath) {
    string path = "D:\\wwwroot\\U8File";
    if (string.IsNullOrEmpty(filePath)) {
        return null;
    }

    //取得文件名
    var arr = filePath.Split('\\');
    var fileName = arr[arr.Length - 1];
    fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss_") + fileName;
    //文件保存路径
    var savePath = path + "\\" + fileName;

    if (!Directory.Exists(path)) {
        Directory.CreateDirectory(path);
    }

    try {
        //读取图片二进制流
        byte[] imageBytes;
        using (var fsReader = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
            var binaryReader = new BinaryReader(fsReader);
            imageBytes = binaryReader.ReadBytes((int)fsReader.Length);
        }

        //写入二进制流
        using (var fsWrite = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite)) {
            var binaryWriter = new BinaryWriter(fsWrite);
            binaryWriter.Write(imageBytes);
        }

        return savePath;
    } catch (Exception e) {
        Console.WriteLine("藏品图片上传失败\n" + e.Message);
        return null;
    }
}

var result = UploadFiles("D:\\lilin\\Desktop\\OIP-C.jpg");
if (!string.IsNullOrEmpty(result)) {
    Console.WriteLine("图片上传成功");
    Console.WriteLine(result);
}