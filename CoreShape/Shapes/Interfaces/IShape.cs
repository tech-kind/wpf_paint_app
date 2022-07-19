using CoreShape.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.Interfaces;
public interface IShape
{
    void Draw(IGraphics g);
    bool HitTest(Point p);
    void Drag(Point oldPointer, Point currentPointer);
}
