using System.Windows.Media;

namespace Notepad;

public class Theme
{
    public required Brush StackPanelBackground { get; init; }
    public required Brush DockPanelBackground { get; init; }
    public required Brush MenuBackground { get; init; }
    public required Brush HeaderFileForeground { get; init; }
    public required Brush HeaderSettingsForeground { get; init; }
    public required Brush EditorBackground { get; init; }
    public required Brush EditorForeground { get; init; }

    public static readonly Theme Light = new Theme
    {
        StackPanelBackground = Brushes.OldLace,
        DockPanelBackground = Brushes.BurlyWood,
        MenuBackground = Brushes.BurlyWood,
        HeaderFileForeground = Brushes.Black,
        HeaderSettingsForeground = Brushes.Black,
        EditorBackground = Brushes.OldLace,
        EditorForeground = Brushes.Black,
    };

    public static readonly Theme Dark = new Theme
    {
        StackPanelBackground = (Brush)(new BrushConverter().ConvertFrom("#3e3e42")!),
        DockPanelBackground = (Brush)(new BrushConverter().ConvertFrom("#3e3e42")!),
        MenuBackground = (Brush)(new BrushConverter().ConvertFrom("#1e1e1e")!),
        HeaderFileForeground = Brushes.White,
        HeaderSettingsForeground = Brushes.White,
        EditorBackground = (Brush)(new BrushConverter().ConvertFrom("#3e3e42")!),
        EditorForeground = Brushes.White,
    };
}
