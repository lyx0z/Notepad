using System.IO;
using System.Windows;
namespace Notepad;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
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
        Microsoft.Win32.OpenFolderDialog dialog = new();

        dialog.Multiselect = false;
        dialog.Title = "Select a folder";
        
        bool? result = dialog.ShowDialog();
        
        if (result == true)
        {
            string fullPathToFolder = dialog.FolderName;
            string folderNameOnly = dialog.SafeFolderName;
            // File.WriteAllLines(Editor);
        }
    }

    private void OnSave_Clicked(object sender, RoutedEventArgs e)
    {
        
    }
}