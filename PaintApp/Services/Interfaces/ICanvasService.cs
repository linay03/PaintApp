using System;
using Avalonia;
using Avalonia.Media.Imaging;
using SkiaSharp;

namespace PaintApp.Services.Interfaces;

public interface ICanvasService
{
    event EventHandler CanvasChanged;
    int Width { get; }
    int Height { get; }
    Bitmap AsBitmap();
    void FlipPixel(Point point, SKColor color);
    void DrawLine(Point startPoint, Point endPoint, SKColor color);
}