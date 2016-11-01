using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Airbase
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics grscreen;
        Graphics grbitmap;
        Rectangle rect;
        public int height, width;
        System.Timers.Timer update;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            GoFullscreen();
            grscreen = this.CreateGraphics();
            bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            grbitmap = Graphics.FromImage(bitmap);
            rect = ClientRectangle;
            width = rect.Width;
            height = rect.Height;
            update = new System.Timers.Timer(100);
            update.Elapsed += RefreshScreen;
            update.AutoReset = true;
            update.Start();
            Airfield.GenerateRunways();
        }


        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }
        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void RefreshScreen(object source, ElapsedEventArgs e)
        {
            try
            {
                Airfield.Draw(grbitmap);
                grscreen.DrawImage(bitmap, rect);
            }
            catch { };
            
        }
    }
}
