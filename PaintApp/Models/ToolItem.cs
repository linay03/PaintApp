using System;
using Avalonia.Interactivity;

namespace PaintApp.Models;

public class ToolItem
{   
    public string Name { get; set; }
    
    public bool IsSelected { get; set; }
    
    public string IconPath { get; set; }

    public void ActivateTool(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}