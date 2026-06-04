using System.Collections.Generic;
using PaintApp.Models;

namespace PaintApp.Services;

public interface IToolService
{
    ToolItem CurrentTool { get; }
    
    List<ToolItem> ToolButtons { get; }
    
    void SetCurrentTool(ToolItem tool);
}