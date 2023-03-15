using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
