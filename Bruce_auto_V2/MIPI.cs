using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using PGRemoteRPC;

namespace Bruce_auto_V2
{

    class MIPI
    {
        //MIPI_error_report record_error = new MIPI_error_report(0);
        private int hactive = 1080;
        private int vactive = 1920;
        private int hsa, hbp, hfp = 80;
        private int vsa, vbp, vfp = 8;
        private int bitrate = 1000;
        private int lane = 4;
        private int pixelformat = 24;
        private double fr = 60;
        private double hsbitrate = 1e9;
        public char[] error_record_array = new char[16];
        public string errorstring = "0000000000000000";

        public delegate void Settextboxcallback(TextBox tb, String data);
        public void Settextbox(TextBox tb, String data)
        {
            if (tb.InvokeRequired)
            {
                Settextboxcallback Sb = new Settextboxcallback(Settextbox);
                tb.BeginInvoke(Sb, new object[] { tb, data });
            }
            else
            {
                tb.Text = data;
            }
        }
        public delegate void DisplayOnPictureBoxcallback(PictureBox pb, Bitmap Bp);
        public void DisplayOnPictureBox(PictureBox pb, Bitmap Bp)
        {
            if (pb.InvokeRequired)
            {
                DisplayOnPictureBoxcallback Db = new DisplayOnPictureBoxcallback(DisplayOnPictureBox);
                pb.BeginInvoke(Db, new object[] { pb, Bp });
            }
            else
            {
                pb.Image = Bp;
            }

        }
        public double mipi_cal_framerate()
        {

            return (bitrate * 1e6 / ((hactive + hbp + hfp + hsa) * (vactive + vsa + vbp + vfp))) / 24 * lane;
        }
        public double mipi_cal_framerate(int hsa, int hbp, int hfp, int vsa, int vbp, int vfp, int bitrate, int lane)
        {
            return (bitrate * 1e6 / ((hactive + hbp + hfp + hsa) * (vactive + vsa + vbp + vfp))) / 24 * lane;
        }
        public double mipi_cal_bitrate(int hsa, int hbp, int hfp, int vsa, int vbp, int vfp, double fr,int lane , int pixelformat)
        {
            return ((hactive + hbp + hfp + hsa) * (vactive + vsa + vbp + vfp) * pixelformat * fr) / lane;
        }
        public double mipi_cal_bitrate()
        {
            return ((hactive + hbp + hfp + hsa) * (vactive + vsa + vbp + vfp) * pixelformat * fr) / lane;
        }
        public void set_reslotuion(int hactive, int vactive)
        {
            this.hactive = hactive;
            this.vactive = vactive;
        }
        public void set_porch(int hsa, int hbp, int hfp, int vsa, int vbp, int vfp)
        {
            this.hsa = hsa;
            this.hbp = hbp;
            this.hfp = hfp;
            this.vsa = vsa;
            this.vbp = vbp;
            this.vfp = vfp;
        }
        public void set_lanecnt(int lane)
        {
            this.lane = lane;
        }

        public void set_pixelformat(int pixelformat)
        {
            if (pixelformat == 24 || pixelformat == 18 || pixelformat == 16)
                this.pixelformat = pixelformat;
            else
                pixelformat = 24;

        }

        public void set_bitrate(double hsbitrate)
        {
            this.hsbitrate = hsbitrate;
        }


        public string error_report_check(String input)
        {
            string lsb, msb = null;
            lsb = acquire_string(input, 3).Trim('h');
            msb = acquire_string(input, 4).Trim('h');
            string error_report = lsb + msb;
            if (error_report.Length != 4)
                return " ";
            else
            {
                errorstring = MipiDphyhex_to_binary(error_report);
                return errorstring;
            }




        }

        private string acquire_string(String input, int num)
        {
            char[] delimate = { ' ', ',' };
            var words = input.Split(delimate);
            return (num > words.Length) ? null : words[num];
        }

        private string hex2bin(string hex)
        {
            try
            {
                String B = Convert.ToString(Convert.ToInt32(hex, 16), 2).PadLeft(4, '0');
                char[] A = B.ToCharArray();
                Array.Reverse(A);
                int temp = A.Length;
                String output = new string(A);
                return output;
            }
            catch (FormatException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }

        }



        public string MipiDphyhex_to_binary(string input)
        {
            string output = null;
            int length = input.Length;
            for (int i = 0; i < length; i++)
            {
                if ((i % 2) == 0)
                {
                    output = output + hex2bin(input[i + 1].ToString());
                }
                else
                {
                    output = output + hex2bin(input[i - 1].ToString());
                }
            }
            return output;

        }

        public void error_decode(char[] errorbit)
        {
            



        }
    }
    class PGcontrol
    {
        PGRemoteRPCClient client = new PGRemoteRPCClient();

        public int LinkPG()
        {
            return client.Connect("", 2799);
        }

        
        
    }
}
