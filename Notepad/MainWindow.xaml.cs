using System.Diagnostics;
using System.IO;
using System.Windows;
namespace Notepad;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string currentFilePath;
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
        SaveAs();
    }

    private void OnSave_Clicked(object sender, RoutedEventArgs e)
    {
        if (currentFilePath is null)
        {
            SaveAs();
        }
        File.WriteAllText(currentFilePath, Editor.Text);
        MessageBox.Show("Successfully saved");
    }

    private void OnOpenMenuItem_Clicked(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        dlg.DefaultExt = ".txt";
        dlg.Filter = "Text documents (.txt)|*.txt";
        bool? result = dlg.ShowDialog();
        if (result == true)
        {
            currentFilePath = dlg.FileName;
            string openFilePath = dlg.FileName;
            Editor.Text = File.ReadAllText(currentFilePath);
        }
    }

    private void OnCloseButton_Clicked(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private void SaveAs()
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
            currentFilePath = filePath;     
        }
    }
}