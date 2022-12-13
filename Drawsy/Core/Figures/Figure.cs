using System;
using System.Drawing;

namespace Drawsy.Core.Figures
{
    /// <summary>
    /// Базовый класс, представляющий фигуру
    /// </summary>
    internal abstract class Figure
    {
        /// <summary>
        /// Координаты верхневого левого угла фигуры
        /// </summary>
        public PointF Point1 => _point1;
        /// <summary>
        /// X координата левого верхнего угла фигуры
        /// </summary>
        public float X1 => _point1.X;
        /// <summary>
        /// Y координата левого верхнего угла фигуры
        /// </summary>
        public float Y1 => _point1.Y;

        /// <summary>
        /// Координаты правого нижнего угла фигуры
        /// </summary>
        public PointF Point2 => _point2;
        /// <summary>
        /// X координата правого нижнего угла фигуры
        /// </summary>
        public float X2 => _point2.X;
        /// <summary>
        /// Y координата правого нижнего угла фигуры
        /// </summary>
        public float Y2 => _point2.Y;

        /// <summary>
        /// Размер фигуры
        /// </summary>
        public SizeF Size => new SizeF(Math.Abs(X2 - X1), Math.Abs(Y2 - Y1));
        /// <summary>
        /// Ширина фигуры
        /// </summary>
        public float Width => Size.Width;
        /// <summary>
        /// Высота фигуры
        /// </summary>
        public float Height => Size.Height;

        protected PointF _point1, _point2;
        protected Color _color;

        // TODO: set this value somewhere from config
        protected float _strokeWidth = 2f;

        /// <summary>
        /// Создаёт фигуру с указанными координатой, размером и цветом
        /// </summary>
        /// <param name="point">Координаты левого верхнего угла фигруы</param>
        /// <param name="size">Размер фигуры</param>
        /// <param name="color">Цвет фигуры</param>
        public Figure(PointF point1, PointF point2, Color color)
        {
            _point1 = point1;
            _point2 = point2;
            _color = color;
        }

        /// <summary>
        /// Рисует фигуру
        /// </summary>
        /// <param name="g">Объект <c>Graphics</c> для рисования фигуры</param>
        public abstract void Draw(Graphics g);

        protected Pen GetPen()
        {
            return new Pen(_color, _strokeWidth);
        }
    }
}
