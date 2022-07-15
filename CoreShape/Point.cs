using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape;
public record struct Point
{
    public float X { get; init; }
    public float Y { get; init; }

    public Point(float x, float y) => (X, Y) = (x, y);
}
