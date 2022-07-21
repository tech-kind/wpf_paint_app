using CoreShape.Graphics;
using CoreShape.Shapes.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes;
public partial class OvalShape : RectangleShape
{
    public OvalShape(Rectangle bounds) : base(bounds, new OvalHitTestStrategy())
    { }

    public OvalShape(Rectangle bounds, IHitTestStrategy hitTestStrategy)
            : base(bounds, hitTestStrategy)
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
        if (IsSelected)
        {
            g.DrawRectangle(Bounds, new Stroke(Color.Black, 1));
            // リサイズハンドルをまとめて描画
            ResizeHandles.Draw(g);
        }
    }
}
