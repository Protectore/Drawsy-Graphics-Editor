using Drawsy.Core;
using Drawsy.Core.Figures;
using Drawsy.Core.FiguresFactory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawsy.Forms
{
    public partial class DrawingForm : Form
    {
        // TODO: это тоже куда-нибудь в конфиг
        private List<FiguresEnum> _topPanelButtons = new List<FiguresEnum>() {
                FiguresEnum.Rectangle,
                FiguresEnum.Ellipse
            };

        private FiguresEnum _figureToCreate = FiguresEnum.None;
        private Figure _tmpFigure;
        private PointF _tmpPoint;

        private Timer _timer = new Timer();

        public DrawingForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Fixed3D;

            controlsPanel.Layout += ControlsPanel_Layout;
            // TODO: вынести в конфиг
            _timer.Interval = 10;
            _timer.Tick += UpdateScreen;
            _timer.Start();

            AddControlButtons();
        }

        private void UpdateScreen(object sender, System.EventArgs e)
        {
            DrawingContext.Instance.DrawFigures();
            pictureBox.Invalidate();
        }

        private void ControlsPanel_Layout(object sender, LayoutEventArgs e)
        {
            int dx = 0;
            foreach (Control control in (sender as Panel).Controls)
            {
                control.Location = new System.Drawing.Point(dx, 0);
                dx += control.Width;
            }
        }

        private void AddControlButtons()
        {
            foreach (FiguresEnum figure in _topPanelButtons)
            {
                AddControlButton(figure);
            }
        }

        private void AddControlButton(FiguresEnum figure)
        {
            var button = new SelectFigureButton(figure);
            button.Click += SelectFigureButtonClick;
            controlsPanel.Controls.Add(button);
            controlsPanel.PerformLayout();
        }

        private void SelectFigureButtonClick(object sender, EventArgs e)
        {
            _figureToCreate = (sender as SelectFigureButton).Figure;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _tmpPoint = e.Location;

            // TODO: color
            _tmpFigure = FigureFactoryManager.GetFactory(_figureToCreate)
                .Create(_tmpPoint, _tmpPoint, Color.Black);
            
            UpdateScreen(this, EventArgs.Empty);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_tmpFigure is null)
                return;

            _tmpFigure.Point1 = new PointF(
                Math.Min(_tmpPoint.X, e.Location.X),
                Math.Min(_tmpPoint.Y, e.Location.Y)
                );

            _tmpFigure.Point2 = new PointF(
                Math.Max(_tmpPoint.X, e.Location.X),
                Math.Max(_tmpPoint.Y, e.Location.Y)
                );
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            DrawingContext.Instance.AddNewFigure(_tmpFigure);
            _tmpFigure = null;
            _tmpPoint = PointF.Empty;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(DrawingContext.Instance.Image, 0, 0);
            if (_tmpFigure != null)
                _tmpFigure.Draw(e.Graphics);
        }
    }
}
