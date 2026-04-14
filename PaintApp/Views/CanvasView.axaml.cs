using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using Avalonia.VisualTree;
using SkiaSharp;

namespace PaintApp.Views;

public partial class CanvasView : UserControl
{
    private SKBitmap skBitmap;
    private bool isPointerPressed;
    
    public CanvasView()
    {
        skBitmap = new(width: 500, height: 500);
        InitializeComponent();
        UpdateBitmap();
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        
        Point pointOnImage = e.GetPosition(this.FindDescendantOfType<Image>());
        Point pointAsRatio = RelativePositionToPointAsRatio(pointOnImage);
        
        Point pointOnBitmap = PointAsRatioToPointOnBitmap(pointAsRatio);
        
        FlipPixelFromImagePoint(pointOnBitmap);
        isPointerPressed = true;
        
        UpdateBitmap();
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);
        
        Point pointOnImage = e.GetPosition(this.FindDescendantOfType<Image>());
        Point pointAsRatio = RelativePositionToPointAsRatio(pointOnImage);
        
        if (isPointerPressed)
        {
            Point pointOnBitmap = PointAsRatioToPointOnBitmap(pointAsRatio);
            FlipPixelFromImagePoint(pointOnBitmap);
        }
        
        UpdateBitmap();
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        
        isPointerPressed = false;
    }

    private Point RelativePositionToPointAsRatio(Point relativePosition)
    {
        Point pointAsRatio = new(relativePosition.X / this.FindDescendantOfType<Image>().Bounds.Size.Width,
            relativePosition.Y / this.FindDescendantOfType<Image>().Bounds.Size.Height);
        
        return pointAsRatio;
    }

    private Point PointAsRatioToPointOnBitmap(Point pointAsRatio)
    {
        Point pointOnBitmap = new(pointAsRatio.X * skBitmap.Width, pointAsRatio.Y * skBitmap.Height);
        return pointOnBitmap;
    }

    private void UpdateBitmap()
    {
        canvasImage.Source = SkBitmapToAvaloniaBitmap(skBitmap);
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
