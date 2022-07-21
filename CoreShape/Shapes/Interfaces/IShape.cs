using CoreShape.Graphics;
using CoreShape.Shapes.ResizeHandles;
using CoreShape.Shapes.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.Interfaces;
public interface IShape : IDrawable, IDraggable, IHitTest, ILocatable
{
    Rectangle Bounds { get; }
    Stroke? Stroke { get; set; }
    Fill? Fill { get; set; }
    bool IsSelected { get; set; }
    IHitTestStrategy HitTestStrategy { get; set; }
    void SetBounds(Rectangle bounds);
}
