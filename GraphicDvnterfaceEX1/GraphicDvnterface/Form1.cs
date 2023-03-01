using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace GraphicDvnterface
{
    public partial class Form1 : Form
    {
        Point pos;
        Color circleColor;
        Color rectangleColor;
        int circleSize;

        // Use FormsTimer

        public Form1()
        {
            InitializeComponent();
            this.plMain.SetDoubleBuffered();

            circleColor = Color.Blue;
            rectangleColor = Color.Blue;
            pos.X = 100;
            pos.Y = 100;
            circleSize = 50;
        }

        private void plMain_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new SolidBrush(circleColor))
            {
                e.Graphics.FillEllipse(brush, pos.X, pos.Y, circleSize, circleSize);
            }
            using (var brushes = new SolidBrush(rectangleColor))
            {
                e.Graphics.FillRectangle(brushes, 10, 10, 150, 150);
            }
            //this.plMain.Focus();
        }

        private void plMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    this.pos.X = this.pos.X - 15;
                    break;
                case Keys.Right:
                    this.pos.X = this.pos.X + 15;
                    break;
                case Keys.Up:
                    this.pos.Y = this.pos.Y - 15;
                    break;
                case Keys.Down:
                    this.pos.Y = this.pos.Y + 15;
                    break;
                case Keys.L:
                    // Increase the size of the circle by 10 pixels
                    this.circleSize += 10;
                    break;
                case Keys.N:
                    // Increase the size of the circle by 10 pixels
                    this.circleSize -= 10;
                    break;
                case Keys.C:
                    using (var colorDialog = new ColorDialog())
                    {
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.circleColor = colorDialog.Color;
                            this.plMain.Refresh();
                        }
                    }
                    break;
                default:
                    break;
            }
            this.plMain.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}