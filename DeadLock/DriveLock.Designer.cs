namespace DeadLock
{
    partial class DriveLock
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label77 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHide = new Guna.UI2.WinForms.Guna2Button();
            this.comboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnunhide = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnunlock = new Guna.UI2.WinForms.Guna2Button();
            this.BtnLock = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Maroon;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1946, 8);
            this.panel3.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label77);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1946, 100);
            this.panel1.TabIndex = 7;
            // 
            // label77
            // 
            this.label77.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("Palatino Linotype", 21.75F, System.Drawing.FontStyle.Bold);
            this.label77.Location = new System.Drawing.Point(18, 14);
            this.label77.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(347, 60);
            this.label77.TabIndex = 1;
            this.label77.Text = "Drive  Actions...";
            this.label77.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1946, 877);
            this.panel2.TabIndex = 8;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnHide);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btnunhide);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnunlock);
            this.groupBox1.Controls.Add(this.BtnLock);
            this.groupBox1.Location = new System.Drawing.Point(28, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1900, 471);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnHide
            // 
            this.btnHide.BorderRadius = 5;
            this.btnHide.CheckedState.Parent = this.btnHide;
            this.btnHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHide.CustomImages.Parent = this.btnHide;
            this.btnHide.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHide.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.ForeColor = System.Drawing.Color.White;
            this.btnHide.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnHide.HoverState.Parent = this.btnHide;
            this.btnHide.Image = global::DeadLock.Properties.Resources.icons8_hide_48;
            this.btnHide.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHide.ImageSize = new System.Drawing.Size(25, 25);
            this.btnHide.Location = new System.Drawing.Point(712, 292);
            this.btnHide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHide.Name = "btnHide";
            this.btnHide.ShadowDecoration.Parent = this.btnHide;
            this.btnHide.Size = new System.Drawing.Size(297, 69);
            this.btnHide.TabIndex = 12;
            this.btnHide.Text = "   Hide  Drive";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Transparent;
            this.comboBox1.BorderRadius = 5;
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FillColor = System.Drawing.Color.Transparent;
            this.comboBox1.FocusedColor = System.Drawing.Color.Empty;
            this.comboBox1.FocusedState.Parent = this.comboBox1;
            this.comboBox1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold);
            this.comboBox1.ForeColor = System.Drawing.Color.Crimson;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.HoverState.Parent = this.comboBox1;
            this.comboBox1.ItemHeight = 30;
            this.comboBox1.Items.AddRange(new object[] {
            "None"});
            this.comboBox1.ItemsAppearance.Parent = this.comboBox1;
            this.comboBox1.Location = new System.Drawing.Point(312, 60);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.ShadowDecoration.Parent = this.comboBox1;
            this.comboBox1.Size = new System.Drawing.Size(541, 36);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // btnunhide
            // 
            this.btnunhide.BorderRadius = 5;
            this.btnunhide.CheckedState.Parent = this.btnunhide;
            this.btnunhide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnunhide.CustomImages.Parent = this.btnunhide;
            this.btnunhide.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnunhide.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnunhide.ForeColor = System.Drawing.Color.White;
            this.btnunhide.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnunhide.HoverState.Parent = this.btnunhide;
            this.btnunhide.Image = global::DeadLock.Properties.Resources.icons8_hide_48;
            this.btnunhide.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnunhide.ImageSize = new System.Drawing.Size(25, 25);
            this.btnunhide.Location = new System.Drawing.Point(1059, 292);
            this.btnunhide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnunhide.Name = "btnunhide";
            this.btnunhide.ShadowDecoration.Parent = this.btnunhide;
            this.btnunhide.Size = new System.Drawing.Size(297, 69);
            this.btnunhide.TabIndex = 11;
            this.btnunhide.Text = "   Un - Hide  Drive";
            this.btnunhide.Click += new System.EventHandler(this.btnunhide_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(46, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 48);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Drive";
            // 
            // btnunlock
            // 
            this.btnunlock.BorderRadius = 5;
            this.btnunlock.CheckedState.Parent = this.btnunlock;
            this.btnunlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnunlock.CustomImages.Parent = this.btnunlock;
            this.btnunlock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnunlock.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnunlock.ForeColor = System.Drawing.Color.White;
            this.btnunlock.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnunlock.HoverState.Parent = this.btnunlock;
            this.btnunlock.Image = global::DeadLock.Properties.Resources.unlock_xxl;
            this.btnunlock.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnunlock.ImageSize = new System.Drawing.Size(25, 25);
            this.btnunlock.Location = new System.Drawing.Point(380, 292);
            this.btnunlock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnunlock.Name = "btnunlock";
            this.btnunlock.ShadowDecoration.Parent = this.btnunlock;
            this.btnunlock.Size = new System.Drawing.Size(297, 69);
            this.btnunlock.TabIndex = 9;
            this.btnunlock.Text = "    Un - Lock Drive";
            this.btnunlock.Click += new System.EventHandler(this.btnunlock_Click);
            // 
            // BtnLock
            // 
            this.BtnLock.BorderRadius = 5;
            this.BtnLock.CheckedState.Parent = this.BtnLock;
            this.BtnLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLock.CustomImages.Parent = this.BtnLock;
            this.BtnLock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnLock.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLock.ForeColor = System.Drawing.Color.White;
            this.BtnLock.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.BtnLock.HoverState.Parent = this.BtnLock;
            this.BtnLock.Image = global::DeadLock.Properties.Resources.lock_50px;
            this.BtnLock.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnLock.ImageSize = new System.Drawing.Size(25, 25);
            this.BtnLock.Location = new System.Drawing.Point(27, 292);
            this.BtnLock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnLock.Name = "BtnLock";
            this.BtnLock.ShadowDecoration.Parent = this.BtnLock;
            this.BtnLock.Size = new System.Drawing.Size(297, 69);
            this.BtnLock.TabIndex = 8;
            this.BtnLock.Text = "Lock Drive";
            this.BtnLock.Click += new System.EventHandler(this.BtnLock_Click);
            // 
            // DriveLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1946, 985);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DriveLock";
            this.Text = "DriveLock";
            this.Load += new System.EventHandler(this.DriveLock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        internal System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox1;
        public System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnunlock;
        private Guna.UI2.WinForms.Guna2Button BtnLock;
        private Guna.UI2.WinForms.Guna2Button btnunhide;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Button btnHide;
    }
}