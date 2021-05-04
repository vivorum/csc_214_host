using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                image = Program.getDarkFrameImage(10);
            }
            else if (picType == 2)
            {
                image = Program.getFlatFrameImage();
            }
        }

        ///save
        private void button2_Click(object sender, EventArgs e) 
        {
            if (!fileName.Equals("")) { 
            Program.saveFITS(image, fileName);
            } 
            else
            {
                Program.saveFITS(image, ("New_Image_"+ imageNum++));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fileName = textBox1.Text;
        }
    }
}
