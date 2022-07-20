using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.ResizeHandles;
public class ResizeHandleW : ResizeHandleBase
{
    public ResizeHandleW(Rectangle bounds) : base(bounds)
    {
        HitResult = HitResult.ResizeW;
    }

    public override Rectangle Resize(Point p, Rectangle parentBounds)
    {
        return new Rectangle(p.X, parentBounds.Top, parentBounds.Right - p.X, parentBounds.Size.Height);
    }

    public override void SetLocation(Rectangle parentBounds)
    {
        var center = new Point(parentBounds.Left, parentBounds.Top + parentBounds.Size.Height / 2);
        MoveTo(center);
    }
}
