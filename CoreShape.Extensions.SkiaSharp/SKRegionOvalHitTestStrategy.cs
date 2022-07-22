using CoreShape.Extensions.SkiaSharp.Extensions;
using CoreShape.Shapes;
using CoreShape.Shapes.Interfaces;
using CoreShape.Shapes.Strategy;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Extensions.SkiaSharp;
public class SKRegionOvalHitTestStrategy : IHitTestStrategy
{
    public bool HitTest(Point p, IShape shape)
    {
        var stroke = shape.Stroke;
        if (stroke is not null && stroke.Width < 4)
        {
            stroke = new Graphics.Stroke(color: stroke.Color, width: 4);
        }
        using var path = new SKPath();
        path.AddOval(shape.Bounds.ToSk());

        using var paint = new SKPaint()
            .SetStroke(stroke)
            .SetFill(shape.Fill)
            .SetPaintStyle(stroke, shape.Fill);

        using var fillPath = paint.GetFillPath(path);
        using var region = new SKRegion(fillPath);
        return region.Contains((int)p.X, (int)p.Y);
    }
}
