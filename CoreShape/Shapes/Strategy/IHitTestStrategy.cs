using CoreShape.Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.Strategy;
public interface IHitTestStrategy
{
    bool HitTest(Point p, IShape shape);
}
