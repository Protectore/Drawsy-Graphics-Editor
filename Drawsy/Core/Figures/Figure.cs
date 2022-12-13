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
        public PointF Point1 { get; set; }
        /// <summary>
        /// X координата левого верхнего угла фигуры
        /// </summary>
        public float X1 => Point1.X;
        /// <summary>
        /// Y координата левого верхнего угла фигуры
        /// </summary>
        public float Y1 => Point1.Y;

        /// <summary>
        /// Координаты правого нижнего угла фигуры
        /// </summary>
        public PointF Point2 { get; set; }
        /// <summary>
        /// X координата правого нижнего угла фигуры
        /// </summary>
        public float X2 => Point2.X;
        /// <summary>
        /// Y координата правого нижнего угла фигуры
        /// </summary>
        public float Y2 => Point2.Y;

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
            Point1 = point1;
            Point2 = point2;
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
