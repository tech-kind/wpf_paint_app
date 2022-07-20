using CoreShape.Graphics;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Extensions.SkiaSharp.Extensions;
public static class SkPaintExtensions
{
    public static SKPaint SetStroke(this SKPaint paint, Stroke stroke)
    {
        if (stroke is null)
        {
            return paint;
        }
        paint.Style = SKPaintStyle.Stroke;
        paint.Color = stroke.Color.ToSk();
        paint.StrokeWidth = stroke.Width;
        return paint;
    }

    public static SKPaint SetFill(this SKPaint paint, Fill fill)
    {
        if (fill is null)
        {
            return paint;
        }
        paint.Style = SKPaintStyle.Fill;
        paint.Color = fill.Color.ToSk();
        return paint;
    }

    public static SKPaint SetPaintStyle(this SKPaint paint, Stroke? stroke, Fill? fill)
    {
        if (stroke is null && fill is null)
        {
            return paint;
        }
        if (stroke is null)
        {
            paint.Style = SKPaintStyle.Fill;
        }
        else if (fill is null)
        {
            paint.Style = SKPaintStyle.Stroke;
        }
        else
        {
            paint.Style = SKPaintStyle.StrokeAndFill;
        }
        return paint;
    }
}
