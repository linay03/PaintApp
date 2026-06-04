using PaintApp.Services.Interfaces;

namespace PaintApp.Models;

public class EmptyTool(ICanvasService canvasService) : ToolBase(canvasService, "Empty tool");