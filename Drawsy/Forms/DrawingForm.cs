using Drawsy.Core;
using Drawsy.Core.Figures;
using Drawsy.Core.FiguresFactory;
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

        private Timer _timer = new Timer();

        public DrawingForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Fixed3D;

            controlsPanel.Layout += ControlsPanel_Layout;
            // TODO: вынести в конфиг
            _timer.Interval = 100;
            _timer.Tick += UpdateScreen;

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

        private void SelectFigureButtonClick(object sender, System.EventArgs e)
        {
            _figureToCreate = (sender as SelectFigureButton).Figure;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // TODO: size, color
            Figure fig = FigureFactoryManager.GetFactory(_figureToCreate)
                .Create(new Point(e.X, e.Y), new PointF(e.X + 40, e.Y + 40), Color.Black);
            DrawingContext.Instance.AddNewFigure(fig);
            UpdateScreen(this, System.EventArgs.Empty);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(DrawingContext.Instance.Image, 0, 0);
        }
    }
}
