using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using PGRemoteRPC;

namespace Bruce_auto_V2
{
    enum MIPI_error_report : int
    {
        SoT_Error,
        SoT_sync_Error,
        EoT_Sync_Error,
        Escape_Mode_Entry_Command_Error,
        LowPower_Transmit_Sync_Error,
        Any_protocol_TimeOut,
        Fale_Coontrol_Error,
        Contention_is_Detected,
        Single_ECC_Error,
        Multi_ECC_Error,
        CheckSum_Error,
        Data_Type_Not_Recognized,
        DSI_Vitrual_Channel_ID_Invalid,
        Reserved,
        Protocol_Violation   
    };
    class MIPI
    {
        private int hactive = 1080;
        private int vactive = 1920;
        private int hsa, hbp, hfp = 80;
        private int vsa, vbp, vfp = 8;
        private int bitrate = 1000;
        private int lane = 4;


        public delegate void Settextboxcallback(TextBox tb, String data);
        public void Settextbox(TextBox tb, String data)
        {
            if(tb.InvokeRequired)
            {
                int a = (int)MIPI_error_report.Contention_is_Detected;
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
        public double mipi_cal_function()
        {

            return (bitrate * 1e6 / ((hactive + hbp + hfp + hsa) * (vactive + vsa + vbp + vfp))) / 24 * lane;
        }
        public double mipi_cal_function(int hsa , int hbp , int hfp , int vsa , int vbp, int vfp , int bitrate , int lane)
        {
            return  (bitrate * 1e6 / ((hactive + hbp + hfp + hsa) * (vactive + vsa + vbp + vfp)))/24 * lane ;
        }
        public void set_reslotuion(int hactive , int vactive)
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

        public string convertbin(String input)
        {
            int numbase = 2;
            try
            {
                return null;

            }
            catch(FormatException)
            {
                return null;
            }
            catch(OverflowException)
            {
                return null;
            }
            catch(ArgumentException)
            {
                return null;
            }

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
