using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.ResizeHandles;
public class ResizeHandleNE : ResizeHandleBase
{
    public ResizeHandleNE(Rectangle bounds) : base(bounds)
    {
        HitResult = HitResult.ResizeNE;
    }

    public override Rectangle Resize(Point p, Rectangle parentBounds)
    {
        return new Rectangle(parentBounds.Left, p.Y, p.X - parentBounds.Left, parentBounds.Bottom - p.Y);
    }

    public override void SetLocation(Rectangle parentBounds)
    {
        var center = new Point(parentBounds.Right, parentBounds.Top);
        MoveTo(center);
    }
}
