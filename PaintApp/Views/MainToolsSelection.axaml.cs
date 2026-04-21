using System.Collections.Generic;
using Avalonia.Controls;
using PaintApp.Models;

namespace PaintApp.Views;

public partial class MainToolsSelection : UserControl
{   
    private List<ToolItem> ToolButtons { get; set; }
    
    public MainToolsSelection()
    {
        InitializeComponent();
        GenerateToolsButtons();
    }
    
    /// <summary>
    /// Gestion de la création des boutons d'outils 
    /// </summary>
    private void GenerateToolsButtons()
    {
        ToolButtons =
        [
            new ToolItem { Name = "Brush 1" },
            new ToolItem { Name = "Brush 2" },
            new ToolItem { Name = "Brush 3" },
            new ToolItem { Name = "Eraser" }
        ];

        foreach (var toolButton in ToolButtons)
        {
            var button = new RadioButton
            {
                Content = toolButton.Name,
            };
            
            ToolsPanel.Children.Add(button);
            button.Click += toolButton.ActivateTool;
        }
    }
}