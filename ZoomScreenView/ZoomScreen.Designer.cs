namespace ZoomScreenView
{
    partial class ZoomScreen
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CaptureBtn = new System.Windows.Forms.Button();
            this.HintLabel = new System.Windows.Forms.Label();
            this.ToolMenu = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureMainScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listAllHWndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XLabel = new System.Windows.Forms.Label();
            this.Xtbx = new System.Windows.Forms.TextBox();
            this.YLabel = new System.Windows.Forms.Label();
            this.Ytbx = new System.Windows.Forms.TextBox();
            this.ToolMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CaptureBtn
            // 
            this.CaptureBtn.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CaptureBtn.Location = new System.Drawing.Point(336, 69);
            this.CaptureBtn.Name = "CaptureBtn";
            this.CaptureBtn.Size = new System.Drawing.Size(111, 28);
            this.CaptureBtn.TabIndex = 1;
            this.CaptureBtn.Text = "CaptureScreen";
            this.CaptureBtn.UseVisualStyleBackColor = true;
            this.CaptureBtn.Click += new System.EventHandler(this.CaptureBtn_Click);
            // 
            // HintLabel
            // 
            this.HintLabel.AutoSize = true;
            this.HintLabel.Location = new System.Drawing.Point(37, 36);
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(356, 17);
            this.HintLabel.TabIndex = 2;
            this.HintLabel.Text = "Capture Main Screen , and Zoom picture size. - Barry.Yang";
            // 
            // ToolMenu
            // 
            this.ToolMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ToolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.ToolMenu.Location = new System.Drawing.Point(0, 0);
            this.ToolMenu.Name = "ToolMenu";
            this.ToolMenu.Size = new System.Drawing.Size(461, 24);
            this.ToolMenu.TabIndex = 7;
            this.ToolMenu.Text = "ToolMenu";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureMainScreenToolStripMenuItem,
            this.listAllHWndToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // captureMainScreenToolStripMenuItem
            // 
            this.captureMainScreenToolStripMenuItem.Name = "captureMainScreenToolStripMenuItem";
            this.captureMainScreenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.captureMainScreenToolStripMenuItem.Text = "Zoom Screen";
            // 
            // listAllHWndToolStripMenuItem
            // 
            this.listAllHWndToolStripMenuItem.Name = "listAllHWndToolStripMenuItem";
            this.listAllHWndToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.listAllHWndToolStripMenuItem.Text = "Window Info";
            this.listAllHWndToolStripMenuItem.Click += new System.EventHandler(this.listAllHWndToolStripMenuItem_Click);
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(119, 75);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(62, 17);
            this.XLabel.TabIndex = 8;
            this.XLabel.Text = "X Value : ";
            // 
            // Xtbx
            // 
            this.Xtbx.BackColor = System.Drawing.Color.Gainsboro;
            this.Xtbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Xtbx.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Xtbx.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Xtbx.Location = new System.Drawing.Point(179, 72);
            this.Xtbx.MaxLength = 3;
            this.Xtbx.Multiline = true;
            this.Xtbx.Name = "Xtbx";
            this.Xtbx.Size = new System.Drawing.Size(38, 22);
            this.Xtbx.TabIndex = 10;
            this.Xtbx.TabStop = false;
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(225, 75);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(62, 17);
            this.YLabel.TabIndex = 9;
            this.YLabel.Text = "Y Value : ";
            // 
            // Ytbx
            // 
            this.Ytbx.BackColor = System.Drawing.Color.Gainsboro;
            this.Ytbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ytbx.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Ytbx.Location = new System.Drawing.Point(284, 72);
            this.Ytbx.MaxLength = 3;
            this.Ytbx.Name = "Ytbx";
            this.Ytbx.Size = new System.Drawing.Size(38, 23);
            this.Ytbx.TabIndex = 11;
            // 
            // ZoomScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 109);
            this.Controls.Add(this.Xtbx);
            this.Controls.Add(this.Ytbx);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.HintLabel);
            this.Controls.Add(this.CaptureBtn);
            this.Controls.Add(this.ToolMenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ZoomScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZoomViewer";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.ToolMenu.ResumeLayout(false);
            this.ToolMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CaptureBtn;
        private System.Windows.Forms.Label HintLabel;
        private System.Windows.Forms.MenuStrip ToolMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureMainScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listAllHWndToolStripMenuItem;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.TextBox Xtbx;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.TextBox Ytbx;
    }
}

