using System;
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
            textBox1.Text = calmipi.mipi_cal_framerate().ToString();
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
            textBox1.Text = mipiclasss.mipi_cal_bitrate(80, 80, 80, 2, 18, 8, 60, 4, 24).ToString();



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
            string[] mipi_error_name =
            {"SoT_Error",
            "SoT_sync_Error",
            "EoT_Sync_Error",
            "Escape_Mode_Entry_Command_Error",
            "LowPower_Transmit_Sync_Error",
            "Any_protocol_TimeOut",
            "Fale_Coontrol_Error",
            "Contention_is_Detected",
            "Single_ECC_Error",
            "Multi_ECC_Error",
            "CheckSum_Error",
            "Data_Type_Not_Recognized",
            "DSI_Vitrual_Channel_ID_Invalid",
            "Invalid_Transmission_Length",
            "Reserved",
            "Protocol_Violation"};

            //String input = "101h 87h 21h 90h 00h 18h";
            string input = "01h 87h 02h 00h 02h 39h";
            textBox2.Text = mipiclasss.error_report_check(input);
            //textBox2.Text = mipiclasss.MipiDphyhex_to_binary(textBox1.Text).ToString();
            for (int i = 0; i< mipiclasss.errorstring.Length; i++)
            {
                if (mipiclasss.errorstring[i] == '1')
                {
                    listBox1.Items.Add(mipi_error_name[i]);
                }
            }
            

        }

        private void Set_Porch_Textbox(int hsa , int hbp , int hfp , int vsa ,int vbp , int vfp)
        {
            mipiclasss.Settextbox(textBox_hsa, hsa.ToString());
            mipiclasss.Settextbox(textBox_hbp, hbp.ToString());
            mipiclasss.Settextbox(textBox_hfp, hfp.ToString());
            mipiclasss.Settextbox(textBox_vsa, vsa.ToString());
            mipiclasss.Settextbox(textBox_vbp, vbp.ToString());
            mipiclasss.Settextbox(textBox_vfp, vfp.ToString());
        }

        private void videomode_auto()
        {
            try
            {
                int init_hsa = Convert.ToInt32(textBox_hsa.Text);
                int init_hbp = Convert.ToInt32(textBox_hbp.Text);
                int init_hfp = Convert.ToInt32(textBox_hfp.Text);
                int init_vsa = Convert.ToInt32(textBox_vsa.Text);
                int init_vbp = Convert.ToInt32(textBox_vbp.Text);
                int init_vfp = Convert.ToInt32(textBox_vfp.Text);
                double goal_bitrate = Convert.ToDouble(textBox_videoauto_goal_bitrate.Text) * 1e6;
            }
            catch (FormatException)
            {
                MessageBox.Show("請確認輸入是否正確");
            }
            catch (OverflowException)
            {
                MessageBox.Show("請確認輸入是否正確");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("請確認輸入是否正確");
            }


        }

        private void videomode_run_btn_Click(object sender, EventArgs e)
        {
            videomode_auto();
        }
    }
}
