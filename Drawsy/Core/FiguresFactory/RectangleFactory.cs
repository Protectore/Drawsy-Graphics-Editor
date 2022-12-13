using Drawsy.Core.Figures;
using System.Drawing;
using Rectangle = Drawsy.Core.Figures.Rectangle;

namespace Drawsy.Core.FiguresFactory
{
    /// <summary>
    /// Фабрика прямоугольников
    /// </summary>
    internal class RectangleFactory : FigureFactory
    {
        public override Figure Create(PointF point1, PointF point2, Color color)
        {
            return new Rectangle(point1, point2, color);
        }
    }
}
