using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PaintApp.Views;

public partial class ColorPicker : UserControl
{   
    public ColorPicker()
    {
        InitializeComponent();
        CurrentColorPicker.Palette = new MaterialColorPalette();
    }
}