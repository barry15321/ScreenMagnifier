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

namespace ZoomScreenView
{
    public partial class ZoomScreen : Form
    {
        public ZoomScreen() 
        {
            InitializeComponent();
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
    }
}
