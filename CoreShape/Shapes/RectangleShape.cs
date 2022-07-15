using CoreShape.Graphics;
using CoreShape.Shapes.Interfaces;

namespace CoreShape.Shapes;
public class RectangleShape : IShape
{
    public Rectangle Bounds { get; protected set; }
    public Stroke? Stroke { get; set; }
    public Fill? Fill { get; set; }

    public RectangleShape()
            : this(new Rectangle())
    {
    }

    public RectangleShape(Rectangle bounds)
    {
        Bounds = bounds;
    }

    public RectangleShape(Point location, Size size)
        : this(new Rectangle(location, size)) { }

    public RectangleShape(float left, float top, float width, float height)
        : this(new Rectangle(left, top, width, height)) { }

    public virtual void Draw(IGraphics g)
    {
        if (Fill is not null)
        {
            g.FillRectangle(Bounds, Fill);
        }
        if (Stroke is not null)
        {
            g.DrawRectangle(Bounds, Stroke);
        }
    }
}
