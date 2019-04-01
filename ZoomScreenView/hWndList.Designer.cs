namespace ZoomScreenView
{
    partial class hWndList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hWndList));
            this.Hwndbox = new System.Windows.Forms.ListBox();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Hwndbox
            // 
            this.Hwndbox.FormattingEnabled = true;
            this.Hwndbox.ItemHeight = 16;
            this.Hwndbox.Location = new System.Drawing.Point(24, 38);
            this.Hwndbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Hwndbox.Name = "Hwndbox";
            this.Hwndbox.Size = new System.Drawing.Size(232, 452);
            this.Hwndbox.TabIndex = 6;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ConfirmBtn.Location = new System.Drawing.Point(180, 502);
            this.ConfirmBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(76, 26);
            this.ConfirmBtn.TabIndex = 8;
            this.ConfirmBtn.Text = "Close";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(21, 15);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(72, 16);
            this.TitleLabel.TabIndex = 9;
            this.TitleLabel.Text = "hWnd List : ";
            // 
            // hWndList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 541);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.Hwndbox);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "hWndList";
            this.Text = "hWndList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox Hwndbox;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Label TitleLabel;
    }
}