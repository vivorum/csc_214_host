using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Communication_App.Properties
{
    public partial class Form1 : Form
    {
        private ushort[] image;
        private int picType = 0;
        private string fileName = "";
        private int imageNum = 0;
        private int temp = 10; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 20;
            numericUpDown2.Value = 10;

            
            pictureBox1.ImageLocation = "../defaultImage.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            picType = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            picType = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            picType = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (picType == 0)
            {
                image = Program.getLightFrameImage();
            }
            else if (picType == 1)
            {
                image = Program.getDarkFrameImage(temp);
            }
            else if (picType == 2)
            {
                image = Program.getFlatFrameImage();
            }
            displayImage();
        }
        private void displayImage()
        {
            {
                var bytes = (from value in image
                             select (byte)value).ToArray();

                using (var stream = new MemoryStream(bytes))
                {
                    var bitmap = new Bitmap(stream);
                    try
                    {
                        int x, y;
                        for (x = 0; x < bitmap.Width; x++)
                        {
                            for (y = 0; y < bitmap.Height; y++)
                            {
                                Color pixelColor = bitmap.GetPixel(x, y);
                                Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                                bitmap.SetPixel(x, y, newColor);
                            }
                        }

                        // Set the PictureBox to display the image.
                        pictureBox1.Image = bitmap;
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("There was an error.");
                    }
                }
            }
        }

        ///save
        private void button2_Click(object sender, EventArgs e) 
        {
            /*if (!fileName.Equals("")) { 
            Program.saveFITS(image, fileName);
            } 
            else
            {
                Program.saveFITS(image, ("New_Image_"+ imageNum++));
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fileName = textBox1.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (picType == 1)
            {
                temp = Convert.ToInt32(Math.Round(numericUpDown2.Value, 0));
            }
        }
    }
}
