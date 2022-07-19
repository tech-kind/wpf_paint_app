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

    public virtual bool HitTest(Point p)
    {
        if (Stroke is not null)
        {
            // 上辺との当たり判定
            if (p.X >= Bounds.Left && p.X <= Bounds.Right
                && p.Y >= Bounds.Top - 2 && p.Y <= Bounds.Top + 2)
            {
                return true;
            }
            // 下辺との当たり判定
            if (p.X >= Bounds.Left && p.X <= Bounds.Right
                && p.Y >= Bounds.Bottom - 2 && p.Y <= Bounds.Bottom + 2)
            {
                return true;
            }
            // 左辺との当たり判定
            if (p.Y >= Bounds.Top && p.Y <= Bounds.Bottom
                && p.X >= Bounds.Left - 2 && p.X <= Bounds.Left + 2)
            {
                return true;
            }
            // 右辺との当たり判定
            if (p.Y >= Bounds.Top && p.Y <= Bounds.Bottom
                && p.X >= Bounds.Right - 2 && p.X <= Bounds.Right + 2)
            {
                return true;
            }
        }
        if (Fill is not null)
        {
            // 図形内部の当たり判定
            if (Bounds.Left <= p.X && p.X <= Bounds.Right
                && Bounds.Top <= p.Y && p.Y <= Bounds.Bottom)
            {
                return true;
            }
        }
        return false;
    }

    public virtual void Drag(Point oldPointer, Point currentPointer)
    {
        var (dx, dy) = (currentPointer.X - oldPointer.X, currentPointer.Y - oldPointer.Y);
        Bounds = new Rectangle(Bounds.Left + dx, Bounds.Top + dy, Bounds.Size.Width, Bounds.Size.Height);
    }
}
