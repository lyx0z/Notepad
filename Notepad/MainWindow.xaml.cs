using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        if (ShowSaveAsDialog())
        {
            if (currentFilePath != null)
            {
                FileUtils.FileUtils.Save(currentFilePath, Editor.Text);
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
            if (currentFilePath != null)
            {
                var openReadFile = FileUtils.FileUtils.Open(currentFilePath);
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
        if (currentFilePath is null)
        {
            OnSaveAs_Clicked(sender, e);
            return;
        }
        FileUtils.FileUtils.Save(currentFilePath, Editor.Text);
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
        currentFilePath = dialog.FileName;
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
        currentFilePath = dialog.FileName;
        return true;
    }

    private void MenuItemModeLight_OnClick(object sender, RoutedEventArgs e)
    {
        StackPanel.Background = Brushes.OldLace;
        DockPanel.Background = Brushes.BurlyWood;
        Menu.Background = Brushes.BurlyWood;
        HeaderFile.Foreground = Brushes.Black;
        HeaderSettings.Foreground = Brushes.Black;
        Editor.Background = Brushes.OldLace;
        Editor.Foreground = Brushes.Black;
    }

    private void MenuItemModeDark_OnClick(object sender, RoutedEventArgs e)
    {
        StackPanel.Background = (Brush)(new BrushConverter().ConvertFrom("#3e3e42")!);
        DockPanel.Background = (Brush)(new BrushConverter().ConvertFrom("#3e3e42")!);
        Menu.Background = (Brush)(new BrushConverter().ConvertFrom("#1e1e1e")!);
        HeaderFile.Foreground = Brushes.White;
        HeaderSettings.Foreground = Brushes.White;
        Editor.Background = (Brush)(new BrushConverter().ConvertFrom("#3e3e42")!);
        Editor.Foreground = Brushes.White;
    }
}