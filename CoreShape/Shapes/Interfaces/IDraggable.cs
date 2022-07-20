using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.Interfaces;
public interface IDraggable
{
    void Drag(Point oldPointer, Point currentPointer);
    void Drop();
}
