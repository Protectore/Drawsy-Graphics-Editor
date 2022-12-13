using System.Drawing;

namespace Drawsy.Core.Figures
{
    internal class Ellipse : Figure
    {
        public Ellipse(PointF point1, PointF point2, Color color) : base(point1, point2, color)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(GetPen(), X1, Y1, Width, Height);
        }
    }
}
