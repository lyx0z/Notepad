using System.IO;
using System.Windows;
using MainWindow.Notepad;
namespace FileUtils;

public class FileUtils
{
    private void SaveAs()
    {
        var dialog = new Microsoft.Win32.SaveFileDialog()
        {
            FileName = "Document", DefaultExt = ".txt", Filter = "Text documents (.txt)|*.txt"
        };
        var result = dialog.ShowDialog();
        
        if (result == true)
        {
            var filePath = dialog.FileName;
            File.WriteAllText(filePath, Editor.Text);
            currentFilePath = filePath;     
        }
    }
}