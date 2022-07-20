using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.ResizeHandles;
public class ResizeHandleNW : ResizeHandleBase
{
    public ResizeHandleNW(Rectangle bounds) : base(bounds)
    {
        HitResult = HitResult.ResizeNW;
    }

    public override Rectangle Resize(Point p, Rectangle parentBounds)
    {
        return new Rectangle(p.X, p.Y, parentBounds.Right - p.X, parentBounds.Bottom - p.Y);
    }

    public override void SetLocation(Rectangle parentBounds)
    {
        var center = new Point(parentBounds.Left, parentBounds.Top);
        MoveTo(center);
    }
}
