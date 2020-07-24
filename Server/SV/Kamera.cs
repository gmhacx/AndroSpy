using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV
{
    public partial class Kamera : Form
    {
        Socket soketimiz;
        public string ID = "";
        public Kamera(Socket s, string aydi)
        {
            soketimiz = s;
            ID = aydi;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            try {
                string cam = "";
                cam = radioButton1.Checked ? "1" : "0";
           Gonderici.Send(soketimiz,Encoding.UTF8.GetBytes("CAM|" + cam),0, Encoding.UTF8.GetBytes("CAM|" + cam).Length,59999);
                label2.Visible = true;
            }
            catch (Exception ) {}


        }
        public Image RotateImage(Image img)
        {
            Bitmap bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return bmp;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = RotateImage(pictureBox1.Image);
            }
        }
    }
}