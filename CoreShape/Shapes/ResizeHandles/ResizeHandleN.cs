using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.ResizeHandles;
public class ResizeHandleN : ResizeHandleBase
{
    public ResizeHandleN(Rectangle bounds) : base(bounds)
    {
        HitResult = HitResult.ResizeN;
    }

    public override Rectangle Resize(Point p, Rectangle parentBounds)
    {
        return new Rectangle(parentBounds.Left, p.Y, parentBounds.Size.Width, parentBounds.Bottom - p.Y);
    }

    public override void SetLocation(Rectangle parentBounds)
    {
        var center = new Point(parentBounds.Left + parentBounds.Size.Width / 2, parentBounds.Top);
        MoveTo(center);
    }
}
