using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.Interfaces;
public interface IShapePen : IDraggable, IDrawable, ILocatable
{
    IShape Template { get; set; }
    IShape? CreateShape();
}
