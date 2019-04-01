using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomScreenView
{
    public partial class hWndList : Form
    {
        public hWndList()
        {
            InitializeComponent();
            ListHwndDetail();
        }

        public void ListHwndDetail()
        {
            FindWindowClass fw = new FindWindowClass();
            fw.GetEnums();

            List<string> HwndName = fw.ToGetHwndNameList();
            List<string> DexCode = fw.ToGetDexCodeList();
            List<IntPtr> HwndList = fw.ToGetHwndList();

            Hwndbox.Items.Clear();
            for (int i = 0; i < HwndName.Count; i++)
                Hwndbox.Items.Add(HwndList[i] + " , " + HwndName[i] + " , " + DexCode[i]);
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
