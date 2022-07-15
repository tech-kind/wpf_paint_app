using CoreShape.Extensions.SkiaSharp.Extensions;
using CoreShape.Graphics;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Extensions.SkiaSharp;
public class SkiaGraphics : IGraphics
{
    protected virtual SKCanvas Canvas { get; set; }

    public SkiaGraphics(SKCanvas canvas)
    {
        Canvas = canvas;
    }

    public virtual void ClearCanvas(Color color)
    {
        throw new NotImplementedException();
    }

    public virtual void DrawRectangle(Rectangle rectangle, Stroke stroke)
    {
        using var paint = new SKPaint().SetStroke(stroke);
        Canvas.DrawRect(rectangle.ToSk(), paint);
    }

    public virtual void FillRectangle(Rectangle rectangle, Fill fill)
    {
        using var paint = new SKPaint().SetFill(fill);
        Canvas.DrawRect(rectangle.ToSk(), paint);
    }

    public virtual void DrawOval(Rectangle rectangle, Stroke stroke)
    {
        using var paint = new SKPaint().SetStroke(stroke);
        Canvas.DrawOval(rectangle.ToSk(), paint);
    }

    public virtual void FillOval(Rectangle rectangle, Fill fill)
    {
        using var paint = new SKPaint().SetFill(fill);
        Canvas.DrawOval(rectangle.ToSk(), paint);
    }
}
