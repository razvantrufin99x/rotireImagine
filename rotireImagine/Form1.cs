using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rotireImagine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public bool isMouseDown = false;
        public int x1, x2, y1, y2, prevx, prevy;


        public float distantaintredouapuncte2dxy(float x1, float y1, float x2, float y2)
        {
            float c;
            c = (float)Math.Sqrt(Math.Abs(x1 - x2) * Math.Abs(x1 - x2) + Math.Abs(y1 - y2) * Math.Abs(y1 - y2));
            return c;
        }


        int rotating = 0;
        Image imageFile;
        public void rotate()
        {

            // Create image.
             imageFile = Image.FromFile("u.jpg");

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);

            //move rotation point to center of image.
            newGraphics.TranslateTransform((float)imageFile.Width / 2, (float)imageFile.Height / 2);
            newGraphics.RotateTransform(rotating);
            newGraphics.TranslateTransform(-(float)imageFile.Width / 2, -(float)imageFile.Height / 2);
            newGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

          

            // Draw image to screen.
            newGraphics.DrawImage(imageFile, new PointF(0.0F, 0.0F));

            panel1.BackgroundImage = imageFile;


        }
       

       

        private void button1_Click(object sender, EventArgs e)
        {
            rotating-=1;

            rotate();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            rotating+=1;
            rotate();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
           
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            x1 = e.X;
            y1 = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true) {
                x2 = e.X;
                y2 = e.Y;
                float r = distantaintredouapuncte2dxy(button1.Left, button1.Top, button2.Left, button2.Top);
                Text = r.ToString();
                if (prevx > x2) { rotating = rotating - (Math.Abs(prevx - x2)) / 10; }
                else if (prevx == x2) { }
                else { rotating = rotating + (Math.Abs(x2 - prevx)) / 10; }
                prevx = x2;
                prevy = y2;
               
            }
            rotate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown=false;
        }
    }
}
