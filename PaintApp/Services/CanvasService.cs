using System;
using System.Collections.Generic;
using System.IO;
using Avalonia;
using Avalonia.Media.Imaging;
using PaintApp.Services.Interfaces;
using SkiaSharp;

namespace PaintApp.Services;

public class CanvasService : ICanvasService
{
    private readonly IInterpolationService interpolationService;
    public event EventHandler CanvasChanged;
    public int Width => skBitmap.Width;
    public int Height => skBitmap.Height;

    private SKBitmap skBitmap;

    public CanvasService(IInterpolationService interpolationService)
    {
        this.interpolationService = interpolationService;
        skBitmap = new(width: 1500, height: 800);

        for (var i = 0; i < skBitmap.Width; i++)
        {
            for (var j = 0; j < skBitmap.Height; j++)
            {
                skBitmap.SetPixel(i, j, SKColors.White);
            }
        }
    }

    public Bitmap AsBitmap()
    {
        SKData data = skBitmap.Encode(SKEncodedImageFormat.Png, 100);
        using Stream stream = data.AsStream();
        return new Bitmap(stream);
    }
    
    public void DrawLine(Point startPoint, Point endPoint, SKColor color)
    {
        IEnumerable<Point> interpolationPoints = interpolationService.LinearInterpolationOnGrid(startPoint, endPoint);
                    
        foreach (Point point in interpolationPoints)
        {
            FlipPixel(point, color);
        }
    }
    
    public void FlipPixel(Point point, SKColor color)
    {
        if (point.X >= skBitmap.Width || point.Y >= skBitmap.Height || point.X < 0 || point.Y < 0)
            return;
        
        skBitmap.SetPixel((int)point.X, (int)point.Y, color);
        CanvasChanged.Invoke(this, EventArgs.Empty);
    }
}