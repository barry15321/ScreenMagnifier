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

namespace ZoomScreenView
{
    public partial class CaptureMainScreen : Form
    {
        public CaptureMainScreen()
        {
            InitializeComponent();
            this.Cursor = Cursors.Arrow;
            Screen.Refresh();
            //CaptureScreen();
        }

        #region Variable Setting

        bool StartDraw = false;//是否開始繪畫範圍
        private System.Drawing.Point MouseStartPosition = new Point();//使用者選取起點
        private System.Drawing.Point MouseEndPosition = new Point();//使用者選取終點
        private Rectangle UserSelectRange;//使用者選取範圍

        public Rectangle UserSelectRect
        {
            get
            {
                return UserSelectRange;
            }

            set
            {
                UserSelectRange = value;
            }
        }

        #endregion

        #region MouseClick Events + Painting

        private void Screen_MouseDown(object sender, MouseEventArgs e)
        {
            //若滑鼠按鍵為左鍵,才允許開始繪圖,並且記錄滑鼠點位
            
            if (e.Button == MouseButtons.Left)
            {
                ConfirmBtn.Visible = false;
                MouseStartPosition = e.Location;
                StartDraw = true;
            }
        }

        private void Screen_MouseMove(object sender, MouseEventArgs e)
        {
            //若允許繪圖
            if (StartDraw)
            {
                //滑鼠按鍵不為左鍵則跳開
                if (e.Button != MouseButtons.Left)
                {
                    return;
                }

                //記錄當前滑鼠座標為選取範圍的終點,並繪製圖片
                MouseEndPosition = e.Location;
                UserSelectRange.Location = new System.Drawing.Point(Math.Min(MouseStartPosition.X, MouseEndPosition.X), Math.Min(MouseStartPosition.Y, MouseEndPosition.Y));
                UserSelectRange.Size = new Size(Math.Abs(MouseStartPosition.X - MouseEndPosition.X), Math.Abs(MouseStartPosition.Y - MouseEndPosition.Y));
                Screen.Invalidate();

            }
        }

        private void Screen_MouseUp(object sender, MouseEventArgs e)
        {
            //放開滑鼠就不允許繼續匯圖
            StartDraw = false;
            ConfirmBtn.Location = new Point(UserSelectRange.X + UserSelectRange.Width, UserSelectRange.Y + UserSelectRange.Height);
            ConfirmBtn.Visible = true;
            
        }

        private void Screen_Paint(object sender, PaintEventArgs e)
        {
            //若允許繪圖
            if (StartDraw)
            {
                //確認當前PictureBox有圖片
                if (Screen.Image != null)
                {
                    //選取範圍不為空,且長寬都大於0
                    if (UserSelectRange != null && UserSelectRange.Width > 0 && UserSelectRange.Height > 0)
                    {
                        //繪製圖片
                        SolidBrush brush = new SolidBrush(Color.FromArgb(50, 0, 100, 255));
                        e.Graphics.FillRectangle(brush, UserSelectRange);
                        //Pen p = new Pen(Color.FromArgb(50, 0, 100, 255));
                        //e.Graphics.DrawRectangle(p, UserSelectRange);
                    }
                }
            }
        }

        #endregion

        public void CaptureScreen()
        {
            ScreenCapture Cap = new ScreenCapture();
            Image src = Cap.CaptureMainScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = src.Width - 1;
            this.Height = src.Height - 1;

            //this.Width = src.Width * 8 / 10 - 1;
            //this.Height = src.Height * 8 / 10 - 1;
            Screen.Image = src;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
