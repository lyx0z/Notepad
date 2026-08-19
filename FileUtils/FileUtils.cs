namespace FileUtils;
 public static class FileUtils
 {
     public static void Write(string path, string content)
     {
         File.WriteAllText(path, content);
     }

     public static string Open(string path)
     {
         var x = File.ReadAllText(path);
         return x;
     }
 }