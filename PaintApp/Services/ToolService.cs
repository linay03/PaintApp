using System;
using System.Collections.Generic;
using PaintApp.Models;
using PaintApp.Services.Interfaces;

namespace PaintApp.Services;

public class ToolService : IToolService
{   
    public List<ToolBase> ToolButtons { get; set; }
    public ToolBase CurrentTool { get; private set; }
    public ToolService(ICanvasService canvasService)
    {
        ToolButtons =
        [
            new PencilTool(canvasService),
            new EmptyTool(),
            new EmptyTool(),
        ];    
        
        CurrentTool = ToolButtons[0];
    }
    public void SetCurrentTool(ToolBase tool)
    {
        CurrentTool = tool;
        Console.WriteLine($"Current tool set to: {tool.Name}");
    }
}