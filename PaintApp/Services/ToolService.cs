using System;
using System.Collections.Generic;
using PaintApp.Models;

namespace PaintApp.Services;

public class ToolService : IToolService
{   
    public List<ToolItem> ToolButtons { get; set; }
    public ToolItem CurrentTool { get; private set; }
    public ToolService()
    {
        ToolButtons =
        [
            new ToolItem { Name = "Brush 1" },
            new ToolItem { Name = "Brush 2" },
            new ToolItem { Name = "Brush 3" },
            new ToolItem { Name = "Eraser" }
        ];    
        
        CurrentTool = ToolButtons[0];
    }
    public void SetCurrentTool(ToolItem tool)
    {
        CurrentTool = tool;
        Console.WriteLine($"Current tool set to: {tool.Name}");
    }
}