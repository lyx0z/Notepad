using FileUtils;
using System.IO;
using System.Windows;
namespace Notepad;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string? currentFilePath;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void MenuItem_New_Click(object sender, RoutedEventArgs e)
    {
        Editor.Clear();
    }

    private void OnSaveAs_Clicked(object sender, RoutedEventArgs e)
    {
        if (TrySaveAsDialog() == true)
        {
            FileUtils.FileUtils.Write(currentFilePath, Editor.Text);
        }
    }

    private void OnOpenMenuItem_Clicked(object sender, RoutedEventArgs e)
    {
        if (TryOpenMenuItem() == true)
        {
            var x = FileUtils.FileUtils.Open(currentFilePath);
            Editor.Text = x;
        }
    }

    private void OnSave_Clicked(object sender, RoutedEventArgs e)
    {
        if (currentFilePath is null)
        {
            TrySaveAsDialog();
        }
        FileUtils.FileUtils.Write(currentFilePath, Editor.Text);
        MessageBox.Show("Successfully saved");
    }
    
    private void OnCloseButton_Clicked(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private bool TrySaveAsDialog()
    {
        var dialog = new Microsoft.Win32.SaveFileDialog()
        {
            FileName = "Document",
            DefaultExt = ".txt",
            Filter = "Text documents (.txt)|*.txt"
        };
        
        var result = dialog.ShowDialog();

        if (result != true)
        {
            return false;
        }
        currentFilePath = dialog.FileName;
        return true;

    }
    
    private bool TryOpenMenuItem()
    {
        var dialog = new Microsoft.Win32.OpenFileDialog()
        {
            FileName = "Document", DefaultExt = ".txt", Filter = "Text documents (.txt)|*.txt"
        };
        var result = dialog.ShowDialog();

        if (result != true)
        {
            return false;
        }
        currentFilePath = dialog.FileName;
        return true;
    }
}