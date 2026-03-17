namespace PaintApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public CanvasViewModel CanvasViewModel { get; } = new CanvasViewModel();
}