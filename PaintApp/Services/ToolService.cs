using PaintApp.Models;

namespace PaintApp.Services;

public class ToolService : IToolService
{
    public ToolItem CurrentTool { get; private set; } = new();
    
    public void SetCurrentTool(ToolItem tool)
    {
        CurrentTool = tool;
    }
}