using System;
using System.Collections.Generic;
using Avalonia;

namespace PaintApp.Services;

public class InterpolationService : IInterpolationService
{
    public IEnumerable<Point> LinearInterpolationOnGrid(Point startPoint, Point endPoint)
    {
        int deltaX = (int)Math.Round(endPoint.X - startPoint.X);
        int deltaY = (int)Math.Round(endPoint.Y - startPoint.Y);
        int biggestDelta = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
        
        if (biggestDelta == 0)
            return [startPoint, endPoint];
        
        double xStep = deltaX / (double)biggestDelta;
        double yStep = deltaY / (double)biggestDelta;
        
        List<Point> points = [];
        
        for (int i = 0; i < biggestDelta + 1; i++)
        {
            double x = startPoint.X + xStep * i;
            double y = startPoint.Y + yStep * i;
            points.Add(new Point(x, y));
        }
        
        return points;
    }

    public Point Lerp(Point startPoint, Point endPoint, double interpolationFactor)
    {
        double x = (1 - interpolationFactor) * startPoint.X + interpolationFactor * endPoint.X;
        double y = (1 - interpolationFactor) * startPoint.Y + interpolationFactor * endPoint.Y;
        return new Point(x, y);
    }
}