using System;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PaintApp.ViewModels;

public partial class CanvasViewModel : ViewModelBase
{
    [ObservableProperty] private Bitmap _sourceBitmap;
    
    [RelayCommand]
    private void PointerPressedHandler(PointerPressedEventArgs e)
    {
        Console.WriteLine("Pointer Pressed!");
    }

    [RelayCommand]
    private void PointerMovedHandler(PointerEventArgs e)
    {
        Console.WriteLine("Pointer Moved!");
    }
}