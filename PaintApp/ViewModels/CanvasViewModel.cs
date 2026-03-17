using System.IO;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SkiaSharp;

namespace PaintApp.ViewModels;

public partial class CanvasViewModel : ViewModelBase
{
    [ObservableProperty] private Bitmap sourceBitmap;

    private SKBitmap skBitmap;
    private bool isPointerPressed;
    
    public CanvasViewModel()
    {
        skBitmap = new(width: 500, height: 500);
        UpdateBitmap();
    }
    
    [RelayCommand]
    private void PointerPressedHandler(Point pointAsRatio)
    {
        Point pointOnBitmap = PointAsRatioToPointOnBitmap(pointAsRatio);
        
        FlipPixelFromImagePoint(pointOnBitmap);
        isPointerPressed = true;
        
        UpdateBitmap();
    }

    [RelayCommand]
    private void PointerMovedHandler(Point pointAsRatio)
    {
        if (isPointerPressed)
        {
            Point pointOnBitmap = PointAsRatioToPointOnBitmap(pointAsRatio);
            FlipPixelFromImagePoint(pointOnBitmap);
        }
        
        UpdateBitmap();
    }

    [RelayCommand]
    private void PointerReleasedHandler()
    {
        isPointerPressed = false;
    }

    private Point PointAsRatioToPointOnBitmap(Point pointAsRatio)
    {
        Point pointOnBitmap = new(pointAsRatio.X * skBitmap.Width, pointAsRatio.Y * skBitmap.Height);
        return pointOnBitmap;
    }

    private void UpdateBitmap()
    {
        SourceBitmap = SkBitmapToAvaloniaBitmap(skBitmap);
    }
    
    private static Bitmap SkBitmapToAvaloniaBitmap(SKBitmap skBitmap)
    {
        SKData data = skBitmap.Encode(SKEncodedImageFormat.Png, 100);
        using Stream stream = data.AsStream();
        return new Bitmap(stream);
    }
    
    private void FlipPixelFromImagePoint(Point point)
    {
        FlipPixel((int)point.X, (int)point.Y);
    }
    
    private void FlipPixel(int x, int y)
    {
        if (x >= skBitmap.Width || y >= skBitmap.Height || x < 0 || y < 0)
            return;

        skBitmap.SetPixel(x, y, SKColors.Red);
    }
}