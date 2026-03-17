namespace PaintApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainToolsSelectionViewModel MainToolsSelectionViewModel { get; } = new MainToolsSelectionViewModel();
}