using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PaintApp.Views;

public partial class MainToolsSelection : UserControl
{
    private bool IsPencilSelected { get; set; }
    
    
    public MainToolsSelection()
    {
        InitializeComponent();
    }

    private void SelectToolButton_OnClick(object? sender, RoutedEventArgs e)
    {
        IsPencilSelected = true;
        SelectToolButton.Classes.Add("selected");
    }
}