using CoreShape.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes;
public partial class OvalShape : RectangleShape
{
    public OvalShape(Rectangle bounds) : base(bounds)
    { }

    public OvalShape(Point location, Size size)
        : this(new Rectangle(location, size)) { }

    public OvalShape(float left, float top, float width, float height)
        : this(new Rectangle(left, top, width, height)) { }

    public override void Draw(IGraphics g)
    {
        if (Fill is not null)
        {
            g.FillOval(Bounds, Fill);
        }
        if (Stroke is not null)
        {
            g.DrawOval(Bounds, Stroke);
        }
    }

    public override bool HitTest(Point p)
    {
        static double Discriminant(float x, float y, float xr, float yr)
            => (x * x) / (xr * xr) + (y * y) / (yr * yr);

        var xr = Bounds.Size.Width / 2;
        var yr = Bounds.Size.Height / 2;
        var x = p.X - Bounds.Left - xr;
        var y = p.Y - Bounds.Top - yr;
        if (Stroke is not null)
        {
            if (Discriminant(x, y, xr + 2, yr + 2) <= 1
                && Discriminant(x, y, xr - 2, yr - 2) >= 1)
            {
                return true;
            }
        }
        if (Fill is not null)
        {
            return Discriminant(x, y, xr, yr) < 1;
        }
        return false;
    }
}
