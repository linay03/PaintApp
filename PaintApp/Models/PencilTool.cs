using System.Collections.Generic;
using Avalonia;
using PaintApp.Services;
using PaintApp.Services.Interfaces;
using SkiaSharp;

namespace PaintApp.Models;

public class PencilTool(ICanvasService canvasService) : ToolBase("Pencil")
{
    private bool isPointerPressed;
    private Point? previousStrockPoint;
    
    public override void OnPointerPressed(Point position)
    {
        canvasService.FlipPixel(position, SKColors.DeepPink);
        isPointerPressed = true;
    }

    public override void OnPointerMoved(Point position)
    {
        if (isPointerPressed)
        {
            if (previousStrockPoint == null)
            {
                canvasService.FlipPixel(position, SKColors.DeepPink);
                previousStrockPoint = position;
            }
            else
            {
                canvasService.DrawLine(previousStrockPoint.Value, position, SKColors.DeepPink);
                previousStrockPoint = position;
            }
        }
    }

    public override void OnPointerReleased(Point position)
    {
        isPointerPressed = false;
        previousStrockPoint = null;
    }
}