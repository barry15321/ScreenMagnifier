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
            ResizeObjectSize();
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
            
            Console.WriteLine(UserRect.X + " , " + UserRect.Y + " , " + UserRect.Width + " , " + UserRect.Height);//user rectangle need adjust
            this.Show();

            ZoomDisplay display = new ZoomDisplay(UserRect, x, y);
            display.Show();
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

            if (MainWindow.Width < DesignWindowWidth || MainWindow.Height < DesignWindowHeight)
            {
                HintLabel.Width *= (MainWindow.Width / DesignWindowWidth);
                HintLabel.Height *= (MainWindow.Height / DesignWindowHeight);
                CaptureBtn.Width *= (MainWindow.Width / DesignWindowWidth);
                CaptureBtn.Height *= (MainWindow.Height / DesignWindowHeight);
                XLabel.Width *= (MainWindow.Width / DesignWindowWidth);
                XLabel.Height *= (MainWindow.Height / DesignWindowHeight);
                Xtbx.Width *= (MainWindow.Width / DesignWindowWidth);
                Xtbx.Height *= (MainWindow.Height / DesignWindowHeight);
                YLabel.Width *= (MainWindow.Width / DesignWindowWidth);
                YLabel.Height *= (MainWindow.Height / DesignWindowHeight);
                Ytbx.Width *= (MainWindow.Width / DesignWindowWidth);
                Ytbx.Height *= (MainWindow.Height / DesignWindowHeight);
            }
        }
    }
}
