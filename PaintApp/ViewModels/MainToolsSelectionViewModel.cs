using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PaintApp.Models;

namespace PaintApp.ViewModels;

public partial class MainToolsSelectionViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool isPencilSelected;
    
    [RelayCommand]
    private void OnSelectTool()
    {
        IsPencilSelected = true;
    }
}