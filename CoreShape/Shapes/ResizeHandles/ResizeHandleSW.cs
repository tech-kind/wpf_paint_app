using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.ResizeHandles;
public class ResizeHandleSW : ResizeHandleBase
{
    public ResizeHandleSW(Rectangle bounds) : base(bounds)
    {
        HitResult = HitResult.ResizeSW;
    }

    public override Rectangle Resize(Point p, Rectangle parentBounds)
    {
        return new Rectangle(p.X, parentBounds.Top, parentBounds.Right - p.X, p.Y - parentBounds.Top);
    }

    public override void SetLocation(Rectangle parentBounds)
    {
        var center = new Point(parentBounds.Left, parentBounds.Bottom);
        MoveTo(center);
    }
}
