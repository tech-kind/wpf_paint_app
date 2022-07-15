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
}
