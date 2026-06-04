using System;
using Avalonia;
using SkiaSharp;

namespace PaintApp.Services.Interfaces;

public interface ICanvasService
{
    event EventHandler CanvasChanged;

    void DrawLine(Point startPoint, Point endPoint, SKColor color);
}