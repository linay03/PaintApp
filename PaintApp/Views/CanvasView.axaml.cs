using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
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
        
        CanvasViewModel? viewModel = (CanvasViewModel?)DataContext;
        if (viewModel != null && viewModel.PointerPressedHandlerCommand.CanExecute(e))
            viewModel.PointerPressedHandlerCommand.Execute(e);
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);
        
        CanvasViewModel? viewModel = (CanvasViewModel?)DataContext;
        if (viewModel != null && viewModel.PointerMovedHandlerCommand.CanExecute(e))
            viewModel.PointerMovedHandlerCommand.Execute(e);
    }
}