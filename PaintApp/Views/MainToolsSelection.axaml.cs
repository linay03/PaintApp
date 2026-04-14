using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using PaintApp.Models;

namespace PaintApp.Views;

public partial class MainToolsSelection : UserControl
{   
    private ItemButtons SelectedTool { get; set; }
    private struct ItemButtons
    {
        public ToolItem Item { get; set; }
        public Button Button { get; set; }

        public void SetEnable(object? sender, RoutedEventArgs routedEventArgs)
        {
            Button.IsEnabled = true;
        }
    }
    
    private List<ItemButtons> ToolButtons { get; set; }
    
    public MainToolsSelection()
    {
        InitializeComponent();
        GenerateToolsButtons();
    }

    private void GenerateToolsButtons()
    {
        ToolButtons =
        [
            // TODO : rajouter les button
            new ItemButtons { Item = new ToolItem { Name = "Brush 1" } },
            new ItemButtons { Item = new ToolItem { Name = "Brush 2" } },
            new ItemButtons { Item = new ToolItem { Name = "Brush 3" } },
            new ItemButtons { Item = new ToolItem { Name = "Eraser" } }
        ];

        foreach (var toolButton in ToolButtons)
        {
            var button = new Button
            {
                Content = toolButton.Item.Name,
            };
                
            ToolsPanel.Children.Add(button);
            SelectedTool = toolButton;
            button.Click += toolButton.SetEnable;
        }
    }
}