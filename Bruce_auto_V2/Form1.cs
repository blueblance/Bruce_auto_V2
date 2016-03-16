﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Threading;
using PGRemoteRPC;

namespace Bruce_auto_V2
{
    
    public delegate void Image_Display(Bitmap Image);
    public partial class Form1 : Form
    {
        MIPI mipiclasss = new MIPI();
        
        

        public Form1()
        {
            InitializeComponent();
        }
        public FilterInfoCollection USB_Webcams = null;
        public VideoCaptureDevice Cam = null;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Cam != null)
            {
                if (Cam.IsRunning)  // When Form1 closes itself, WebCam must stop, too.
                {
                    Cam.Stop();   // WebCam stops capturing images.
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (button1.Text == "Start")
            {
                button1.Text = "Stop";
                Cam.Start();   // WebCam starts capturing images.
            }
            else
            {
                button1.Text = "Start";
                Cam.Stop();  // WebCam stops capturing images.
            }
            */
            MIPI calmipi = new MIPI();
            calmipi.set_porch(120, 30, 80, 2, 18, 8);
            textBox1.Text = calmipi.mipi_cal_function().ToString();
            //textBox1.Text = calmipi.mipi_cal_function(80, 80, 80, 8, 8, 8, 1000 , 4).ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            start_getcam();

        }



        private void Cam_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            //pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            MIPI mipicam = new MIPI();
            mipicam.DisplayOnPictureBox(pictureBox1, (Bitmap)eventArgs.Frame.Clone());
            //DisplayOnPictureBox(pictureBox1, (Bitmap)eventArgs.Frame.Clone());

        }
        private void start_getcam()
        {
            USB_Webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (USB_Webcams.Count > 0)  // The quantity of WebCam must be more than 0.
            {
                
                Cam = new VideoCaptureDevice(USB_Webcams[0].MonikerString);
                Cam.NewFrame += new AForge.Video.NewFrameEventHandler(Cam_NewFrame);
                Cam.Start();
            }
            else
            {
                
                MessageBox.Show("No video input device is connected.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MIPI mipical = new MIPI();
            //string A = "3";
            //byte A = Convert.ToByte("0A", 16);
            Thread T = new Thread(Video_Auto_Text);
            Thread T2 = new Thread(Test_Dectect);

                T.Start();
            T2.Start();
            
                
 

            
            //T2.Start();
        }

        private void 儲存設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "儲存設定";
        }

        private void 讀取設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "讀取設定";
        }

        private void Video_Auto_Text()
        {
            MIPI controltext = new MIPI();

            for(int i = 1; i<100; i++)
            {
                controltext.Settextbox(textBox1, i.ToString());
                Thread.Sleep(500);
            }
        }

        private void Test_Dectect()
        {
            MIPI controltext = new MIPI();

            for (int i = 1; i < 100; i++)
            {
                controltext.Settextbox(textBox2, i.ToString());
                Thread.Sleep(100);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;
        }

        private void p338ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p344ToolStripMenuItem.Checked = (p338ToolStripMenuItem.Checked) ? false : true;
        }

        private void p344ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p338ToolStripMenuItem.Checked = (p344ToolStripMenuItem.Checked) ? false : true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //String input = "101h 87h 21h 90h 00h 18h";
            string input = "01h 87h 02h 00h 02h 39h";
            textBox2.Text = mipiclasss.error_report_check(input);
            

        }
    }
}
