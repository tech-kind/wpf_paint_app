using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShape.Shapes.Strategy;
public class RectangleHitTestStrategy : IHitTestStrategy<RectangleShape>
{
    public bool HitTest(Point p, RectangleShape shape)
    {
        if (shape.Stroke is not null)
        {
            // 上辺との当たり判定
            if (p.X >= shape.Bounds.Left && p.X <= shape.Bounds.Right
                && p.Y >= shape.Bounds.Top - 2 && p.Y <= shape.Bounds.Top + 2)
            {
                return true;
            }
            // 下辺との当たり判定
            if (p.X >= shape.Bounds.Left && p.X <= shape.Bounds.Right
                && p.Y >= shape.Bounds.Bottom - 2 && p.Y <= shape.Bounds.Bottom + 2)
            {
                return true;
            }
            // 左辺との当たり判定
            if (p.Y >= shape.Bounds.Top && p.Y <= shape.Bounds.Bottom
                && p.X >= shape.Bounds.Left - 2 && p.X <= shape.Bounds.Left + 2)
            {
                return true;
            }
            // 右辺との当たり判定
            if (p.Y >= shape.Bounds.Top && p.Y <= shape.Bounds.Bottom
                && p.X >= shape.Bounds.Right - 2 && p.X <= shape.Bounds.Right + 2)
            {
                return true;
            }
        }
        if (shape.Fill is not null)
        {
            // 図形内部の当たり判定
            if (shape.Bounds.Left <= p.X && p.X <= shape.Bounds.Right
                && shape.Bounds.Top <= p.Y && p.Y <= shape.Bounds.Bottom)
            {
                return true;
            }
        }
        return false;
    }
}
