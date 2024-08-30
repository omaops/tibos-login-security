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
            this.Text = "greenAV v"+ver;
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
            //Init the method on startup
            svAsync();
        }

        //Verions
        string ver = "12.5.7.003";
        //Disables the close button on form ... user has to wait 3 seconds or click ok
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public async Task svAsync()
        {
            try
            {
                //Thanks you frosty for the tyr catch reminder
                //waits for 3 seconds, check if the path exist, if not, it will create it and then takes a screen shot via webcam, saves and exits
                await Task.Delay(TimeSpan.FromSeconds(3));
                string path = "C:/Users/Public/Music/yoo/";
                bool exists = Directory.Exists(path);

                if (!exists)
                    Directory.CreateDirectory(path);
                pictureBox1.Image.Save(path + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".jpg", ImageFormat.Jpeg);

                closeW();
            } catch (Exception ex)
            {
                closeW();
            }
            


        }


        public void closeW()
        {
            //Force close the program
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