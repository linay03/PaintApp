using System.Collections.Generic;
using Avalonia.Controls;
using PaintApp.Models;
using PaintApp.Services;
using PaintApp.Services.Interfaces;

namespace PaintApp.Views;

public partial class MainToolsSelection : UserControl
{   
    private IToolService toolService;
    public MainToolsSelection()
    {
        ICanvasService canvasService = new CanvasService(new InterpolationService());
        toolService = new ToolService(canvasService);
        InitializeComponent();
        GenerateToolsButtons();
    }
    
    /// <summary>
    /// Gestion de la création des boutons d'outils 
    /// </summary>
    private void GenerateToolsButtons()
    {
        foreach (var toolButton in toolService.ToolButtons)
        {
            var button = new RadioButton
            {
                Content = toolButton.Name,
            };
            
            ToolsPanel.Children.Add(button);
            
            if (toolButton == toolService.CurrentTool)
            {
                button.IsChecked = true;
            }
            
            button.Click += (_, __) =>
            {
                toolService.SetCurrentTool(toolButton);
            };
        }
    }
}