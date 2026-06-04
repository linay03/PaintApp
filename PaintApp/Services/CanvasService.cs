using System;
using Avalonia;
using PaintApp.Services.Interfaces;
using SkiaSharp;

namespace PaintApp.Services;

public class CanvasService : ICanvasService
{
    public event EventHandler CanvasChanged;

    public void DrawLine(Point startPoint, Point endPoint, SKColor color)
    {
        throw new NotImplementedException();
    }
}