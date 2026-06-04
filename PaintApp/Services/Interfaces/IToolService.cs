using PaintApp.Models;

namespace PaintApp.Services;

public interface IToolService
{
    ToolItem CurrentTool { get; }
    
    void SetCurrentTool(ToolItem tool);
}