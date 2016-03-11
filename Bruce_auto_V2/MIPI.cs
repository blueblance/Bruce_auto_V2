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
    }
}
