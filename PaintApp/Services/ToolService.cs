using System;
using System.Collections.Generic;
using PaintApp.Models;
using PaintApp.Services.Interfaces;

namespace PaintApp.Services;

public class ToolService : IToolService
{   
    public List<ToolBase> ToolButtons { get; set; }
    public ToolBase CurrentTool { get; private set; }
    public ToolService()
    {
        // TODO: Better handle dependencies, this will not work because it is not linked to CanvasView
        ICanvasService canvasService = new CanvasService();
        
        ToolButtons =
        [
            new EmptyTool(canvasService),
            new EmptyTool(canvasService),
            new EmptyTool(canvasService),
        ];    
        
        CurrentTool = ToolButtons[0];
    }
    public void SetCurrentTool(ToolBase tool)
    {
        CurrentTool = tool;
        Console.WriteLine($"Current tool set to: {tool.Name}");
    }
}