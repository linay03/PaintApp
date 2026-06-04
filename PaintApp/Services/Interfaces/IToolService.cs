using PaintApp.Models;

namespace PaintApp.Services;

public interface IToolService
{
    void SetCurrentTool(ToolItem tool);
}