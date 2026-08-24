namespace FileUtils;

public static class FileUtils
{
    public static void Save(string path, string content)
    {
        File.WriteAllText(path, content);
    }

    public static string Open(string path)
    {
        var fileText = File.ReadAllText(path);
        return fileText;
    }
}
