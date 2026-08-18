using System.IO;
using System.IO.Enumeration;
using System.Windows;
using System.Windows.Controls;

namespace Notepad;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string? _currentFilePath;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void MenuItem_New_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFolderDialog dialog = new();

        dialog.Multiselect = false;
        dialog.Title = "Select a folder";
        
        bool? result = dialog.ShowDialog();
        
        if (result == true)
        {
            string fullPathToFolder = dialog.FolderName;
            string folderNameOnly = dialog.SafeFolderName;
            // File.Create(fullPathToFolder);
        }
    }

    private void OnSaveAs_Clicked(object sender, RoutedEventArgs e)
    {

        var dialog = new Microsoft.Win32.SaveFileDialog()
        {
            FileName = "Document", DefaultExt = ".txt", Filter = "Text documents (.txt)|*.txt"
        };
        bool? result = dialog.ShowDialog();
        
        if (result == true)
        {
            string filePath = dialog.FileName;
            File.WriteAllText(filePath, Editor.Text);
            _currentFilePath = filePath;    
        }
        
    }

    private void OnSave_Clicked(object sender, RoutedEventArgs e)
    {
        
    }
}