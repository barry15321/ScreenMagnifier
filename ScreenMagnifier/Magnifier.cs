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

namespace Magnifier
{
    public partial class Magnifier : Form
    {
        public Magnifier() 
        {
            InitializeComponent();
        }

        ScreenCapture Shot = new ScreenCapture();
        Rectangle UserRect = new Rectangle();
        decimal nx = 1 , ny = 1;
        int MaxWidth = 0, MaxHeight = 0;
        
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

            this.Hide();
            CaptureMainScreen Screen = new CaptureMainScreen();
            Screen.Owner = (CaptureMainScreen)this.Owner;
            Screen.CaptureScreen();
            Screen.Show();
            Screen.FormClosed += new FormClosedEventHandler(CaptureMainScreen_FormClosed);
            
        }

        private void CaptureMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CaptureMainScreen sub = (CaptureMainScreen)sender;
            UserRect = ((CaptureMainScreen)sender).UserSelectRect;

            UserRect.X = (UserRect.X <= 0) ? 1 : UserRect.X;
            UserRect.Y = (UserRect.Y <= 0) ? 1 : UserRect.Y;
            UserRect.Width = (UserRect.Width <= 0) ? 1 : UserRect.Width;
            UserRect.Height = (UserRect.Height <= 0) ? 1 : UserRect.Height;
            //in case 0 or nagitive
            Console.WriteLine(UserRect.X + " , " + UserRect.Y + " , " + UserRect.Width + " , " + UserRect.Height);//user rectangle need adjust
            this.Show();

            ZoomDisplay display = new ZoomDisplay(UserRect, (double)nx, (double)ny);
            display.Show();

            this.Cursor = Cursors.Default;
        }

        public void ScreenInfo()
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

        private void nWidth_ValueChanged(object sender, EventArgs e)
        {
            if (this.nWidth.Value < 1)
                this.nWidth.Value = 1;
            nx = this.nWidth.Value;
        }

        private void nHeight_ValueChanged(object sender, EventArgs e)
        {
            if (this.nHeight.Value < 1)
                this.nHeight.Value = 1;
            ny = this.nHeight.Value;
        }

        private void Magnifier_Load(object sender, EventArgs e)
        {
            string Msgtxt = "";
            //Msgtxt += "Screen : " + Screen.AllScreens.Count(); 
            for (int i = 0; i < Screen.AllScreens.Count(); i++)
            {
                Screen CurrentScreen = Screen.AllScreens[i];               
                Msgtxt += "  " + CurrentScreen.Bounds.Width + " * " + CurrentScreen.Bounds.Height + " ";
                MaxHeight += CurrentScreen.Bounds.Height;
                MaxWidth += CurrentScreen.Bounds.Width;
            }
            label1.Text = Msgtxt;

            this.nHeight.Value = 1;
            this.nWidth.Value = 1;


            //設定按字型來縮放控制元件
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //設定字型大小為12px
            //this.Font = new Font("Constantia", 12F , FontStyle.Regular , GraphicsUnit.Pixel , ((byte)(134)));

            this.Font = new Font("Microsoft Sans Serif" , 12F , FontStyle.Regular , GraphicsUnit.Pixel , ((byte)(134)));
            
        }

    }
}
