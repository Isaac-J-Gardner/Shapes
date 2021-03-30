using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainmenu.Visible = true;
            circlemaker.Visible = false;
            squaremaker.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainmenu.Visible = false;
            circlemaker.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //creating a bitmap of same width and height as the picture box
            int width = 800, height = 400;

            Bitmap bmp = new Bitmap(width, height);

            //checking to see if the text box is in an incorrect format and setting radius
            int radius = 0;

            try
            {
                radius = Convert.ToInt32(textBox2.Text);
                radius++;
                textBox2.Text = Convert.ToString(radius);
            }
            catch (FormatException)
            {
                radius = 0;
                textBox2.Text = "0";
            }

            //creating the colour black
            Color colour = new Color();
            colour = Color.FromArgb(255, 0, 0, 0);

            //drawing the circle by incrementing the angle of theta between 0 and 2 PI
            for (double theta = 0; theta <= Math.PI * 2; theta += 0.001)
            {
                //checking to see if the diametre of the circle is going to go outside the bitmap
                if (radius * 2 >= height)
                {
                    radius = height / 2 - 1;
                    textBox2.Text = Convert.ToString(radius);
                }

                //getting the x and y coordinates of the point on the circle
                double x = radius * Math.Cos(theta);
                double y = radius * Math.Sin(theta);

                //rounding the result so it can be made a coordinate
                int ix = Convert.ToInt32(x) + width / 2;
                int iy = Convert.ToInt32(y) + height / 2;
                bmp.SetPixel(ix, iy, colour);
            }
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //everything the same as above except "--" after radius
            int width = 800, height = 400;

            Bitmap bmp = new Bitmap(width, height);

            int radius = 0;

            try
            {
                radius = Convert.ToInt32(textBox2.Text);
                radius--;
                textBox2.Text = Convert.ToString(radius);
            }
            catch (FormatException)
            {
                radius = 0;
                textBox2.Text = "0";
            }

            Color colour = new Color();
            colour = Color.FromArgb(255, 0, 0, 0);

            for (double theta = 0; theta <= Math.PI * 2; theta += 0.001)
            {
                if (radius * 2 >= height)
                {
                    radius = height / 2 - 1;
                    textBox2.Text = Convert.ToString(radius);
                }

                double x = radius * Math.Cos(theta);
                double y = radius * Math.Sin(theta);
                int ix = Convert.ToInt32(x) + width / 2;
                int iy = Convert.ToInt32(y) + height / 2;
                bmp.SetPixel(ix, iy, colour);
            }
            pictureBox1.Image = bmp;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //everything the same except for checking the users input
            int width = 800, height = 400;

            Bitmap bmp = new Bitmap(width, height);

            int radius = 0;

            //checking if the input is in a convertable format
            try
            {
                radius = Convert.ToInt32(textBox2.Text);
            }
            catch(FormatException)
            {
                radius = 0;
            }

            Color colour = new Color();
            colour = Color.FromArgb(255, 0, 0, 0);

            for (double theta = 0; theta <= Math.PI * 2; theta += 0.001)
            {
                if (radius * 2 >= height)
                {
                    radius = height / 2 - 1;
                    textBox2.Text = Convert.ToString(radius);
                }

                double x = radius * Math.Cos(theta);
                double y = radius * Math.Sin(theta);
                int ix = Convert.ToInt32(x) + width / 2;
                int iy = Convert.ToInt32(y) + height / 2;
                bmp.SetPixel(ix, iy, colour);
            }
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            circlemaker.Visible = false;
            mainmenu.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mainmenu.Visible = false;
            squaremaker.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            squaremaker.Visible = false;
            mainmenu.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //creating a bitmap of same width and height as the picture box
            int width = 800, height = 400;

            Bitmap bmp = new Bitmap(width, height);

            //checking to see if the text box is in the correct format and setting radius
            int radius = 0;

            try
            {
                radius = Convert.ToInt32(textBox3.Text);
                radius++;
                textBox3.Text = Convert.ToString(radius);
            }
            catch (FormatException)
            {
                radius = 0;
                textBox3.Text = "0";
            }

            //checking to see if drawing the square would go outside the picture box and cause an error
            if (radius * 2 >= height)
            {
                radius = height / 2 - 1;
                textBox3.Text = Convert.ToString(radius);
            }

            //creating the colour
            Color colour = new Color();
            colour = Color.FromArgb(255, 0, 0, 0);

            //creating 2 lines of length 2 radius above and below the centre at distance radius
            for (int x = width / 2 - radius; x <= width / 2 + radius; x++)
            {
                bmp.SetPixel(x, height / 2 + radius, colour);
                bmp.SetPixel(x, height / 2 - radius, colour);
            }

            //creating 2 lines of length 2 radius to the left and right of the centre at distance radius
            for (int y = height / 2 - radius; y <= height/2 + radius; y++)
            {
                bmp.SetPixel(width / 2 + radius, y, colour);
                bmp.SetPixel(width / 2 - radius, y, colour);
            }
            pictureBox2.Image = bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //everything the same except radius--
            int width = 800, height = 400;

            Bitmap bmp = new Bitmap(width, height);

            int radius = 0;

            try
            {
                radius = Convert.ToInt32(textBox3.Text);
                radius--;
                textBox3.Text = Convert.ToString(radius);
            }
            catch (FormatException)
            {
                radius = 0;
                textBox3.Text = "0";
            }

            if (radius * 2 >= height)
            {
                radius = height / 2 - 1;
                textBox3.Text = Convert.ToString(radius);
            }

            Color colour = new Color();
            colour = Color.FromArgb(255, 0, 0, 0);

            for (int x = width / 2 - radius; x <= width / 2 + radius; x++)
            {
                bmp.SetPixel(x, height / 2 + radius, colour);
                bmp.SetPixel(x, height / 2 - radius, colour);
            }

            for (int y = height / 2 - radius; y <= height / 2 + radius; y++)
            {
                bmp.SetPixel(width / 2 + radius, y, colour);
                bmp.SetPixel(width / 2 - radius, y, colour);
            }
            pictureBox2.Image = bmp;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //everything the same except for checking the format
            int width = 800, height = 400;

            Bitmap bmp = new Bitmap(width, height);

            int radius = 0;

            try
            {
                radius = Convert.ToInt32(textBox3.Text);
            }
            catch (FormatException)
            {
                radius = 0;
            }

            if (radius * 2 >= height)
            {
                radius = height / 2 - 1;
                textBox3.Text = Convert.ToString(radius);
            }

            Color colour = new Color();
            colour = Color.FromArgb(255, 0, 0, 0);

            for (int x = width / 2 - radius; x <= width / 2 + radius; x++)
            {
                bmp.SetPixel(x, height / 2 + radius, colour);
                bmp.SetPixel(x, height / 2 - radius, colour);
            }

            for (int y = height / 2 - radius; y <= height / 2 + radius; y++)
            {
                bmp.SetPixel(width / 2 + radius, y, colour);
                bmp.SetPixel(width / 2 - radius, y, colour);
            }
            pictureBox2.Image = bmp;
        }
    }
}
