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
        paint.Style = SKPaintStyle.Stroke;
        paint.Color = stroke.Color.ToSk();
        paint.StrokeWidth = stroke.Width;
        return paint;
    }

    public static SKPaint SetFill(this SKPaint paint, Fill fill)
    {
        paint.Style = SKPaintStyle.Fill;
        paint.Color = fill.Color.ToSk();
        return paint;
    }
}
