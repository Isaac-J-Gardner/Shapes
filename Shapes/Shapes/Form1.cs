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

        public void circle(int dif, int radius)
        {
            //creating a bitmap of same width and height as the picture box
            int width = pictureBox1.Width, height = pictureBox1.Height;

            Bitmap bmp = new Bitmap(width, height);

            radius += dif;

            textBox2.Text = Convert.ToString(radius);

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
                else if (radius * 2 <= height * -1)
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

        public void square(int dif, int radius)
        {
            //creating a bitmap of same width and height as the picture box
            int width = pictureBox1.Width, height = pictureBox1.Height;

            Bitmap bmp = new Bitmap(width, height);

            radius += dif;

            textBox3.Text = Convert.ToString(radius);

            //checking to see if drawing the square would go outside the picture box and cause an error
            if (radius * 2 >= height)
            {
                radius = height / 2 - 1;
                textBox3.Text = Convert.ToString(radius);
            }
            else if (radius * 2 <= height * -1)
            {
                radius = height / 2 - 1;
                textBox2.Text = Convert.ToString(radius);
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
            for (int y = height / 2 - radius; y <= height / 2 + radius; y++)
            {
                bmp.SetPixel(width / 2 + radius, y, colour);
                bmp.SetPixel(width / 2 - radius, y, colour);
            }
            pictureBox2.Image = bmp;
        }

        public void fractal(double difa, double difb, double a2, double b2)
        {
            int width = pictureBox3.Width, height = pictureBox3.Height;

            Bitmap bmp = new Bitmap(width, height);

            //unsure if its the nicest way to get the increase and decrease but it is the only thing i thought of
            a2 += difa;
            b2 += difb;

            textBox4.Text = Convert.ToString(a2);
            textBox5.Text = Convert.ToString(b2);

            //checking if they checked the mandelbrot box as the mandelbrot set requires a different calculation
            if (checkBox2.Checked == true)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        /* setting real numbers to the x axis and the imaginary to the y axis
                         * i added width over 2 as to centre the fractal around the centre of the picturebox
                         * i also devided it by 4 as to have the fractal have magnitude of 2 on the x and y axis
                        */
                        double a = (double)(x - width / 2) / (width / 4);
                        double b = (double)(y - height / 2) / (height / 4);

                        //creating 2 complex numbers, for the mandelbrot set, z is 0 and we keep adding c
                        Complex z = new Complex(0, 0);
                        Complex c = new Complex(a, b);

                        int iter = 0;
                        do
                        {
                            //squaring z then adding c then squaring that
                            iter++;
                            z.square();
                            z.Add(c);
                            //if the number goes beyond 2, then it will reach infinity and there is no longer any point iterating it.
                            if (z.magnitude() > 2) break;
                        }
                        while (iter < 100);

                        /*had trouble trying to get the colours to look nice but if it does break early, then it asigns a colour depending on how many iterations it took
                         * please, if you can, try to make the colours look better, like the ones you see from videos, if you can, send it to me :)
                         */
                        bmp.SetPixel(x, y, iter < 100 ? Color.FromArgb(255, 255 - iter, 255 / (iter + 1), iter) : Color.Black);
                    }
                }
            }
            else
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        double a = (double)(x - width / 2) / (width / 4);
                        double b = (double)(y - height / 2) / (height / 4);
                        //z is set to the x and y axis, unlike with mandelbrot set where z starts at 0. c is set to the numbers the user has assigned
                        Complex z = new Complex(a, b);
                        Complex c = new Complex(a2, b2);

                        int iter = 0;
                        do
                        {
                            iter++;
                            z.square();
                            z.Add(c);
                            if (z.magnitude() > 2) break;
                        }
                        while (iter < 100);

                        bmp.SetPixel(x, y, iter < 100 ? Color.FromArgb(255, 255 - iter, 255 / (iter + 1), iter) : Color.Black);
                    }
                }
            }

            pictureBox3.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainmenu.Visible = true;
            circlemaker.Visible = false;
            squaremaker.Visible = false;
            fractalmaker.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainmenu.Visible = false;
            circlemaker.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                circle(1, Convert.ToInt32(textBox2.Text));
            }
            catch (FormatException)
            {
                circle(0, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                circle(-1, Convert.ToInt32(textBox2.Text));
            }
            catch (FormatException)
            {
                circle(0, 0);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                circle(0, Convert.ToInt32(textBox2.Text));
            }
            catch (FormatException)
            {
                textBox2.Text = "";
            }
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
            try
            {
                square(1, Convert.ToInt32(textBox3.Text));
            }
            catch (FormatException)
            {
                square(0, 0);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                square(-1, Convert.ToInt32(textBox3.Text));
            }
            catch (FormatException)
            {
                square(0, 0);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                square(0, Convert.ToInt32(textBox3.Text));
            }
            catch (FormatException)
            {
                textBox3.Text = "";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            mainmenu.Visible = false;
            fractalmaker.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fractalmaker.Visible = false;
            mainmenu.Visible = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fractal(0, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
            catch (FormatException)
            {
                textBox4.Text = "0";
                textBox5.Text = "0";
                fractal(0, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                fractal(0.01, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
            catch (FormatException)
            {
                textBox4.Text = "0";
                textBox5.Text = "0";
                fractal(0, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                fractal(-0.01, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
            catch (FormatException)
            {
                textBox4.Text = "0";
                textBox5.Text = "0";
                fractal(0, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                fractal(0, 0.01, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
            catch (FormatException)
            {
                textBox4.Text = "0";
                textBox5.Text = "0";
                fractal(0, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                fractal(0, -0.01, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
            catch (FormatException)
            {
                textBox4.Text = "0";
                textBox5.Text = "0";
                fractal(0, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                fractal(0.1, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
            catch (FormatException)
            {
                textBox4.Text = "0";
                textBox5.Text = "0";
                fractal(0, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                fractal(-0.1, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
            catch (FormatException)
            {
                textBox4.Text = "0";
                textBox5.Text = "0";
                fractal(0, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                fractal(0, -0.1, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
            catch (FormatException)
            {
                textBox4.Text = "0";
                textBox5.Text = "0";
                fractal(0, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                fractal(0, 0.1, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
            catch (FormatException)
            {
                textBox4.Text = "0";
                textBox5.Text = "0";
                fractal(0, 0, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //i tried adding the ability to type but i cant be bothered trying to prevent it from disallowing decimals points
        }
    }
}
/* wow, congrats! you made it to the bottom of my code. im reletively new to coding in c# and so recommendations and support will be greatly appreciated. 
 * either way, thank you for checking this out and feel free to mess about with it, i would love to see what you do with it!
 */