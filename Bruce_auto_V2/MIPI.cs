using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Bruce_auto_V2
{
    class MIPI
    {
        private int hactive = 1080;
        private int vactive = 1920;
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

        public double mipi_cal_function(double hsa , double hbp , double hfp , double vsa , double vbp, double vfp , double bitrate , int lane)
        {
            return  (bitrate * 1e6 / ((hactive + hbp + hfp + hsa) * (vactive + vsa + vbp + vfp)))/24 * lane ;
        }
        public void set_reslotuion(int hactive , int vactive)
        {
            this.hactive = hactive;
            this.vactive = vactive;
        }


    }
}
