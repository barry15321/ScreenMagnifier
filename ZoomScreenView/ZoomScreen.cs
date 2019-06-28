using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace ZoomScreenView
{
    public partial class ZoomScreen : Form
    {
        public ZoomScreen() 
        {
            InitializeComponent();
            //ResizeObjectSize();
            //GetCurrentScreenSize();
        }

        ScreenCapture Shot = new ScreenCapture();
        hWndList hwdList = null;
        Rectangle UserRect = new Rectangle();
        double x, y;

        private string RegexStr(string _text, string _pattern = @"", int _GroupOption = 0)
        {
            List<string> TextBar = new List<string>();
            string text = _text, pattern = _pattern;
            int GroupOption = _GroupOption;
            Match match = Regex.Match(text, pattern);
            for (int i = 0; match.Success; i++)
            {
                TextBar.Add(match.Groups[GroupOption].Value);
                match = match.NextMatch();
            }

            if (TextBar[GroupOption].Count() != 0)
                return TextBar[GroupOption];
            else
                return "";
        }
        
        private void CaptureBtn_Click(object sender, EventArgs e)
        {
            if (Xtbx.Text.ToString().Length != 0)
                x = Convert.ToDouble(RegexStr(Xtbx.Text.ToString(), @"^[0-9]+(\.[0-9]{1,2})?$"));
            else
                x = 1.0;
            if (Ytbx.Text.ToString().Length != 0)
                y = Convert.ToDouble(RegexStr(Ytbx.Text.ToString(), @"^[0-9]+(\.[0-9]{1,2})?$"));
            else
                y = 1.0;

            this.Hide();
            CaptureMainScreen Screen = new CaptureMainScreen();
            Screen.Owner = (CaptureMainScreen)this.Owner;
            Screen.CaptureScreen();
            Screen.Show();
            Screen.FormClosed += new FormClosedEventHandler(CaptureMainScreen_FormClosed);
            
        }

        private void CaptureMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            CaptureMainScreen sub = (CaptureMainScreen)sender;
            UserRect = sub.UserSelectRect;

            UserRect.X = (UserRect.X <= 0) ? 1 : UserRect.X;
            UserRect.Y = (UserRect.Y <= 0) ? 1 : UserRect.Y;
            UserRect.Width = (UserRect.Width <= 0) ? 1 : UserRect.Width;
            UserRect.Height = (UserRect.Height <= 0) ? 1 : UserRect.Height;
            //in case 0 or nagitive
            Console.WriteLine(UserRect.X + " , " + UserRect.Y + " , " + UserRect.Width + " , " + UserRect.Height);//user rectangle need adjust
            this.Show();

            ZoomDisplay display = new ZoomDisplay(UserRect, x, y);
            display.Show();

            this.Cursor = Cursors.Default;
        }

        private void listAllHWndToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            hwdList = new hWndList();
            hwdList.Show();
        }

        private void GetCurrentScreenSize()
        {
            Console.WriteLine("Screen Counts : " + Screen.AllScreens.Count());
            for (int i = 0; i < Screen.AllScreens.Count(); i++)
            {
                Screen CurrentScreen = Screen.AllScreens[i];
                Console.WriteLine(CurrentScreen.BitsPerPixel + " pixels.");
                Console.WriteLine(CurrentScreen.Bounds);
                Console.WriteLine(CurrentScreen.DeviceName + " . device name");
                Console.WriteLine(CurrentScreen.Primary);
                Console.WriteLine(CurrentScreen.WorkingArea);
            }
        }
        
        private void captureMainScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Msgtxt = "";
            for (int i = 0; i < Screen.AllScreens.Count(); i++)
            {
                Screen CurrentScreen = Screen.AllScreens[i];
                Msgtxt += "Screen [" + i + "] , Is Primary ? " + CurrentScreen.Primary + "\n";
                Msgtxt += " , X : " + CurrentScreen.Bounds.X + " , Y : " + CurrentScreen.Bounds.Y +
                    " , Width : " + CurrentScreen.Bounds.Width + " , Height : " + CurrentScreen.Bounds.Height + "\n";
            }
            MessageBox.Show("Screen Counts : " + Screen.AllScreens.Count() + "\n\n" + Msgtxt);
        }

        private void ResizeObjectSize()
        {
            int DesignWindowWidth = 1600, DesignWindowHeight = 900;

            Rectangle MainWindow = Screen.PrimaryScreen.Bounds;
            //Rectangle SubWindow = new Rectangle(0, 0, 1366, 768);

            if (MainWindow.Width < DesignWindowWidth || MainWindow.Height < DesignWindowHeight)
            {
                double WidthMag = (double)DesignWindowWidth / (double)MainWindow.Width, HeightMag = (double)DesignWindowHeight / (double)MainWindow.Height;
                this.Size = new Size((int)((double)this.Size.Width / WidthMag), (int)((double)this.Size.Height / HeightMag));
                //this.Size = new Size(this.Size.Width / 2, this.Size.Height / 2);
                HintLabel.Size = new Size((int)((double)HintLabel.Size.Width / WidthMag), (int)((double)HintLabel.Size.Height / HeightMag));
                HintLabel.Location = new Point((int)((double)HintLabel.Location.X / WidthMag), (int)((double)HintLabel.Location.Y / HeightMag));
                CaptureBtn.Size = new Size((int)((double)CaptureBtn.Size.Width / WidthMag), (int)((double)CaptureBtn.Size.Height / HeightMag));
                CaptureBtn.Location = new Point((int)((double)CaptureBtn.Location.X / WidthMag), (int)((double)CaptureBtn.Location.Y / HeightMag));
                XLabel.Size = new Size((int)((double)XLabel.Size.Width / WidthMag), (int)((double)XLabel.Size.Height / HeightMag));
                XLabel.Location = new Point((int)((double)XLabel.Location.X / WidthMag), (int)((double)XLabel.Location.Y / HeightMag));
                YLabel.Size = new Size((int)((double)YLabel.Size.Width / WidthMag), (int)((double)YLabel.Size.Height / HeightMag));
                YLabel.Location = new Point((int)((double)YLabel.Location.X / WidthMag), (int)((double)YLabel.Location.Y / HeightMag));
                Xtbx.Size = new Size((int)((double)Xtbx.Size.Width / WidthMag), (int)((double)Xtbx.Size.Height / HeightMag));
                Xtbx.Location = new Point((int)((double)Xtbx.Location.X / WidthMag), (int)((double)Xtbx.Location.Y / HeightMag));
                Ytbx.Size = new Size((int)((double)Ytbx.Size.Width / WidthMag), (int)((double)Ytbx.Size.Height / HeightMag));
                Ytbx.Location = new Point((int)((double)Ytbx.Location.X / WidthMag), (int)((double)Ytbx.Location.Y / HeightMag));

            }
        }
    }
}
