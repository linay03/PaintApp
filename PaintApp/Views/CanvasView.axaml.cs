using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using Microsoft.Extensions.DependencyInjection;
using PaintApp.Services;
using PaintApp.Services.Interfaces;

namespace PaintApp.Views;

public partial class CanvasView : UserControl
{
    private readonly ICanvasService canvasService;
    private readonly IToolService toolService;
    
    public CanvasView()
    {
        canvasService = App.Services.GetRequiredService<ICanvasService>();
        toolService = App.Services.GetRequiredService<IToolService>();
        canvasService.CanvasChanged += UpdateBitmap;
        InitializeComponent();
        UpdateBitmap();
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        
        Point pointOnImage = e.GetPosition(this.FindDescendantOfType<Image>());
        Point pointAsRatio = RelativePositionToPointAsRatio(pointOnImage);
        Point pointOnBitmap = PointAsRatioToPointOnBitmap(pointAsRatio);
        
        toolService.CurrentTool.OnPointerPressed(pointOnBitmap);
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);
        
        Point pointOnImage = e.GetPosition(this.FindDescendantOfType<Image>());
        Point pointAsRatio = RelativePositionToPointAsRatio(pointOnImage);
        Point pointOnBitmap = PointAsRatioToPointOnBitmap(pointAsRatio);
        
        toolService.CurrentTool.OnPointerMoved(pointOnBitmap);
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        
        Point pointOnImage = e.GetPosition(this.FindDescendantOfType<Image>());
        Point pointAsRatio = RelativePositionToPointAsRatio(pointOnImage);
        Point pointOnBitmap = PointAsRatioToPointOnBitmap(pointAsRatio);
        
        toolService.CurrentTool.OnPointerReleased(pointOnBitmap);
    }

    private Point RelativePositionToPointAsRatio(Point relativePosition)
    {
        Point pointAsRatio = new(relativePosition.X / this.FindDescendantOfType<Image>().Bounds.Size.Width,
            relativePosition.Y / this.FindDescendantOfType<Image>().Bounds.Size.Height);
        
        return pointAsRatio;
    }

    private Point PointAsRatioToPointOnBitmap(Point pointAsRatio)
    {
        Point pointOnBitmap = new(pointAsRatio.X * canvasService.Width, pointAsRatio.Y * canvasService.Height);
        return pointOnBitmap;
    }

    private void UpdateBitmap(object? sender, EventArgs e)
        => UpdateBitmap();
    
    private void UpdateBitmap()
    {
        CanvasImage.Source = canvasService.AsBitmap();
    }
}
