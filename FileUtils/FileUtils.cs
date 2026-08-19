namespace FileUtils;
 public static class FileUtils
 {
     public static void WriteSaveFile(string path, string content)
     {
         File.WriteAllText(path, content);
     }

     public static string Open(string path)
     {
         var readAllText = File.ReadAllText(path);
         return readAllText;
     }
 }