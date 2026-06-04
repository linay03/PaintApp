using Avalonia;
using PaintApp.Services.Interfaces;

namespace PaintApp.Models;

public abstract class ToolBase(ICanvasService canvasService, string name, string iconPath = "")
{   
    public string Name { get; set; } = name;

    public string IconPath { get; set; } = iconPath;

    protected ICanvasService CanvasService { get; } = canvasService;

    public virtual void OnPointerPressed(Point position)
    { }
    public virtual void OnPointerMoved(Point position)
    { }
    public virtual void OnPointerReleased(Point position)
    { }
}