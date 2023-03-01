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
using FormsTimer = System.Windows.Forms.Timer;

// Use FormsTimer
namespace GraphicDvInterface2
{
    public partial class Form1 : Form
    {
        Point pos;
        SolidBrush myBrush;
        Color myColor;
        FormsTimer myTime = new FormsTimer();
        bool moveRight = true;
        int circleSize;

        public Form1()
        {
            InitializeComponent();
            this.plMain.SetDoubleBuffered();
            myColor = Color.Blue;
            myBrush= new SolidBrush(myColor);
            pos.X = 100;
            pos.Y = 100;
            circleSize = 50;

            myTime.Interval = 500;
            myTime.Tick += new EventHandler(myTime_Tick);
            myTime.Start();
        }

        private void plMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(myBrush, pos.X, pos.Y, circleSize, circleSize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void myTime_Tick(object sender, EventArgs e)
        {
            if (moveRight)
            {
                // move the circle to the right
                this.pos.X = Math.Min(this.pos.X + 10, this.plMain.Width - circleSize);
                if (this.pos.X >= this.plMain.Width - circleSize)
                {
                    // if circle reaches right edge, start moving left
                    moveRight = false;
                }
            }
            else
            {
                // move the circle to the left
                this.pos.X = Math.Max(this.pos.X - 10, 0);
                if (this.pos.X <= 0)
                {
                    // if circle reaches left edge, start moving right
                    moveRight = true;
                }
            }
            this.plMain.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.pos.Y = Math.Max(this.pos.Y - 10, 0);
            }
            // Move circle down when the down arrow key is pressed
            else if (e.KeyCode == Keys.Down)
            {
                this.pos.Y = Math.Min(this.pos.Y + 10, this.plMain.Height - circleSize);
            }
        }
    }
}
