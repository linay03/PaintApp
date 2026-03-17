using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using PaintApp.ViewModels;

namespace PaintApp.Views;

public partial class CanvasView : UserControl
{
    public CanvasView()
    {
        InitializeComponent();
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        
        Point pointOnImage = e.GetPosition(this.FindDescendantOfType<Image>());
        Point pointAsRatio = RelativePositionToPointAsRatio(pointOnImage);
        
        CanvasViewModel? viewModel = (CanvasViewModel?)DataContext;
        if (viewModel != null && viewModel.PointerPressedHandlerCommand.CanExecute(pointAsRatio))
            viewModel.PointerPressedHandlerCommand.Execute(pointAsRatio);
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);
        
        Point pointOnImage = e.GetPosition(this.FindDescendantOfType<Image>());
        Point pointAsRatio = RelativePositionToPointAsRatio(pointOnImage);
        
        CanvasViewModel? viewModel = (CanvasViewModel?)DataContext;
        if (viewModel != null && viewModel.PointerMovedHandlerCommand.CanExecute(pointAsRatio))
            viewModel.PointerMovedHandlerCommand.Execute(pointAsRatio);
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        
        CanvasViewModel? viewModel = (CanvasViewModel?)DataContext;
        if (viewModel != null && viewModel.PointerReleasedHandlerCommand.CanExecute(null))
            viewModel.PointerReleasedHandlerCommand.Execute(null);
    }

    private Point RelativePositionToPointAsRatio(Point relativePosition)
    {
        Point pointAsRatio = new(relativePosition.X / 500,
            relativePosition.Y / 500);
        
        return pointAsRatio;
    }
}
