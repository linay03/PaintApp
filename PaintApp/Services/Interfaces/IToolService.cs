using System.Collections.Generic;
using PaintApp.Models;

namespace PaintApp.Services;

public interface IToolService
{
    ToolBase CurrentTool { get; }
    
    List<ToolBase> ToolButtons { get; }
    
    void SetCurrentTool(ToolBase tool);
}