using Drawsy.Core.Figures;
using System.Drawing;

namespace Drawsy.Core.FiguresFactory
{
    /// <summary>
    /// Фабрика эллипосв
    /// </summary>
    internal class EllipseFactory : FigureFactory
    {
        public override Figure Create(PointF point1, PointF point2, Color color)
        {
            return new Ellipse(point1, point2, color);
        }
    }
}
