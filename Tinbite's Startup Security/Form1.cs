using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.IO;

namespace Tinbite_s_Startup_Security
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            FilterInfoCollection fic;
            VideoCaptureDevice vcd;

            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo dev in fic)
            {
                comboBox1.Items.Add(dev.Name);
                comboBox1.SelectedIndex = 0;
                vcd = new VideoCaptureDevice();
                vcd = new VideoCaptureDevice(fic[comboBox1.SelectedIndex].MonikerString);
                vcd.NewFrame += FinalFrame_NewFrame;
                vcd.Start();
                
                //sv();
            }
            svAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public async Task svAsync () 
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            string path = "C:/Users/Public/Music/yoo/";
            bool exists = Directory.Exists(path);

            if (!exists)
                Directory.CreateDirectory(path);
            pictureBox1.Image.Save(path + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".jpg", ImageFormat.Jpeg);

            closeW();


        }


        public void closeW()
        {
            Environment.Exit(0);
            this.Close();
            Dispose();
        }


        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs e)
        {
            pictureBox1.Image = (Bitmap)e.Frame.Clone();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            svAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //For testing only ...
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //for testing only ...
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if active, allow user to choose file location manually
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = @"Save image";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog.FileName + ".jpg",
                System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show(@"Saved!");
            }
        }
    }
}