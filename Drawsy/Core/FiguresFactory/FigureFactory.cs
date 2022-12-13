using Drawsy.Core.Figures;
using System.Drawing;

namespace Drawsy.Core.FiguresFactory
{
    /// <summary>
    /// Базовый класс фабрики фигур
    /// </summary>
    internal abstract class FigureFactory
    {
        /// <summary>
        /// Создаёт фигуру
        /// </summary>
        /// <param name="point">Верхний левый угол фигуры</param>
        /// <param name="size">Размер фигуры</param>
        /// <param name="color">Цвет фигуры</param>
        /// <returns></returns>
        public abstract Figure Create(PointF point1, PointF point2, Color color);
    }
}
