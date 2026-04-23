using System.Collections.Generic;
using Avalonia;

namespace PaintApp.Services;

public interface IInterpolationService
{
    IEnumerable<Point> LinearInterpolationOnGrid(Point startPoint, Point endPoint);
    Point Lerp(Point startPoint, Point endPoint, double interpolationFactor);
}