using System.Windows;

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
        Editor.Clear();
    }

    private void OnSaveAs_Clicked(object sender, RoutedEventArgs e)
    {
        if (ShowSaveAsDialog())
        {
            if (_currentFilePath != null)
            {
                FileUtils.FileUtils.WriteSaveFile(_currentFilePath, Editor.Text);
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }

    private void OnOpenMenuItem_Clicked(object sender, RoutedEventArgs e)
    {
        if (ShowOpenDialog())
        {
            if (_currentFilePath != null)
            {
                var openReadFile = FileUtils.FileUtils.Open(_currentFilePath);
                Editor.Text = openReadFile;
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }

    private void OnSave_Clicked(object sender, RoutedEventArgs e)
    {
        if (_currentFilePath is null)
        {
            OnSaveAs_Clicked(sender, e);
            return;
        }
        FileUtils.FileUtils.WriteSaveFile(_currentFilePath, Editor.Text);
        MessageBox.Show("Successfully saved");
    }
    
    private void OnCloseButton_Clicked(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private bool ShowSaveAsDialog()
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
        _currentFilePath = dialog.FileName;
        return true;

    }
    
    private bool ShowOpenDialog()
    {
        var dialog = new Microsoft.Win32.OpenFileDialog()
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
        _currentFilePath = dialog.FileName;
        return true;
    }
}