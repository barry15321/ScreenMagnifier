using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Runtime.InteropServices;
//using OpenCvSharp;

namespace ZoomScreenView
{
    public partial class ZoomDisplay : Form
    {
        Rectangle UserRect;
        double x, y;
        public ZoomDisplay(Rectangle _UserRect , double _x , double _y)
        {
            UserRect = _UserRect;
            x = _x; y = _y;
            InitializeComponent();
        }
        
        ScreenCapture Cap = new ScreenCapture();
        GlobalKeyboardHook hook = new GlobalKeyboardHook();
        bool TogMovement = false;
        int MvalX, MvalY;

        private void ZoomDisplay_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            hook = new GlobalKeyboardHook();
            hook.KeyDown += new KeyEventHandler(DetectKeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                hook.HookedKeys.Add(key);
            hook.hook();
        }

        private void DetectKeyDown(object sender, KeyEventArgs e)
        {
            int value = (int)e.KeyValue;
            switch (value)
            {
                case 27:
                    hook.unhook();
                    this.Close();
                    break;
            }
        }

        private void DisplayPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            TogMovement = true;
            MvalX = e.X;
            MvalY = e.Y;

        }

        private void DisplayPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMovement)
            {
                this.SetDesktopLocation(MousePosition.X - MvalX, MousePosition.Y - MvalY);
            }
        }

        private void DisplayPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            TogMovement = false;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Image MainScreen = Cap.CaptureAllScreen();
            //Image MainScreen = Cap.CaptureMainScreen();
            Image<Bgr, byte> MainSrc = new Image<Bgr, byte>((Bitmap)MainScreen);
                        
            Mat CutScreen = new Mat(MainSrc.Mat, UserRect);
            CvInvoke.Resize(CutScreen, CutScreen, Size.Empty, y, x , Inter.Area);
            this.Size = CutScreen.Size;
            DisplayPictureBox.Image = CutScreen.ToImage<Bgr, byte>().ToBitmap();

            GC.Collect();
        }
    }
}
