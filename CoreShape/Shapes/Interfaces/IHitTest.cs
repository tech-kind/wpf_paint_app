using CoreShape.Shapes.ResizeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.Interfaces;
public interface IHitTest
{
    HitResult HitTest(Point p);
}
