using Drawsy.Core.Figures;
using Drawsy.Core.FiguresFactory;
using System.Collections.Generic;
using System.Drawing;

namespace Drawsy.Core
{
    /// <summary>
    /// Класс синглтон, представляющий собой графический контекст редактора
    /// </summary>
    internal class DrawingContext
    {
        private static DrawingContext s_instance;

        private List<Figure> _figures = new List<Figure>();
        private Bitmap _image;

        /// <summary>
        /// Изображение, на котором рисуются фигуры
        /// </summary>
        public Bitmap Image => _image;

        /// <summary>
        /// Экземпляр контекста
        /// </summary>
        public static DrawingContext Instance { get
            {
                if (s_instance is null)
                    s_instance = new DrawingContext();
                return s_instance;
            } 
        }

        private DrawingContext()
        {
            // TODO: вынести
            _image = new Bitmap(1920, 1080);
        }

        /// <summary>
        /// Рисует все фигуры контекста на изображении
        /// </summary>
        public void DrawFigures()
        {
            Graphics g = Graphics.FromImage(_image);
            foreach (Figure figure in _figures)
                figure.Draw(g);
        }

        /// <summary>
        /// Добавляет новую фигуру в контекст
        /// </summary>
        /// <param name="figure">Фигура, добавляемая в контекст</param>
        public void AddNewFigure(Figure figure)
        {
            _figures.Add(figure);
        }
    }
}
