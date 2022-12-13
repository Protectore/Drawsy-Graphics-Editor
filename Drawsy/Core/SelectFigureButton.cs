using Drawsy.Core.Figures;
using Drawsy.Core.FiguresFactory;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Drawsy.Core
{
    internal class SelectFigureButton: Button
    {
        private FiguresEnum _figure;
        /// <summary>
        /// Фигура, за выбор которой отвечает кнопка
        /// </summary>
        public FiguresEnum Figure => _figure;

        /// <summary>
        /// Создаёт кнопку, отвечающую за выбор фигуры с указаным идентификатором
        /// </summary>
        /// <param name="figure">Идентификатор выбираемой фигуры</param>
        public SelectFigureButton(FiguresEnum figure)
        {
            _figure = figure;
            // TODO: посмотреть хардкодинг
            Size = new Size(40, 30);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            GetIconFigure().Draw(pevent.Graphics);
        }

        private Figure GetIconFigure()
        {
            // TODO: посмотреть хардкодинг
            int padding = 8;
            SizeF size = new SizeF(Width - padding * 2, Height - padding * 2);
            PointF location = new PointF(padding, padding);
            return FigureFactoryManager.GetFactory(_figure).Create(location, location + size, Color.Black);
        }
    }
}
