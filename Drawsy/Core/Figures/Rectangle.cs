using System.Drawing;

namespace Drawsy.Core.Figures
{
    internal class Rectangle : Figure
    {
        public Rectangle(PointF point1, PointF point2, Color color) : base(point1, point2, color)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(GetPen(), X1, Y1, Width, Height);
        }
    }
}
