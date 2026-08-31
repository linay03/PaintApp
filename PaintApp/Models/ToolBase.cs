using Avalonia;
using PaintApp.Services.Interfaces;

namespace PaintApp.Models;

public abstract class ToolBase(string name, string iconPath = "")
{   
    public string Name { get; set; } = name;

    public string IconPath { get; set; } = iconPath;
    
    public virtual void OnPointerPressed(Point position)
    { }
    public virtual void OnPointerMoved(Point position)
    { }
    public virtual void OnPointerReleased(Point position)
    { }
}