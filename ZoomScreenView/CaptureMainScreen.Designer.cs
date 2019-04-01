namespace ZoomScreenView
{
    partial class CaptureMainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureMainScreen));
            this.Screen = new System.Windows.Forms.PictureBox();
            this.RightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConfirmBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            this.SuspendLayout();
            // 
            // Screen
            // 
            this.Screen.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Screen.Location = new System.Drawing.Point(0, 0);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(521, 436);
            this.Screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Screen.TabIndex = 0;
            this.Screen.TabStop = false;
            this.Screen.Paint += new System.Windows.Forms.PaintEventHandler(this.Screen_Paint);
            this.Screen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Screen_MouseDown);
            this.Screen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Screen_MouseMove);
            this.Screen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Screen_MouseUp);
            // 
            // RightClick
            // 
            this.RightClick.Name = "contextMenuStrip1";
            this.RightClick.Size = new System.Drawing.Size(61, 4);
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Image = ((System.Drawing.Image)(resources.GetObject("ConfirmBtn.Image")));
            this.ConfirmBtn.Location = new System.Drawing.Point(470, 379);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(39, 36);
            this.ConfirmBtn.TabIndex = 1;
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Visible = false;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // CaptureMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 436);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.Screen);
            this.Name = "CaptureMainScreen";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Screen;
        private System.Windows.Forms.ContextMenuStrip RightClick;
        private System.Windows.Forms.Button ConfirmBtn;
    }
}