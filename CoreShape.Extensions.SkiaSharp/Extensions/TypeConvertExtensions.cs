using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Extensions.SkiaSharp.Extensions;
public static class TypeConvertExtensions
{
    public static SKPoint ToSk(this Point p) => new SKPoint(p.X, p.Y);
    public static SKSize ToSk(this Size s) => new SKSize(s.Width, s.Height);
    public static SKRect ToSk(this Rectangle rect) => new SKRect(rect.Left, rect.Top, rect.Right, rect.Bottom);
    public static SKColor ToSk(this Color color) => new SKColor(color.R, color.G, color.B, color.A);
}
