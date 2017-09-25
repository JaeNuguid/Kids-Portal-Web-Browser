namespace newKidsPortal
{
    partial class KidsPortal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KidsPortal));
            this.Background = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.homeButton = new System.Windows.Forms.PictureBox();
            this.forwardButton = new System.Windows.Forms.PictureBox();
            this.backwardButton = new System.Windows.Forms.PictureBox();
            this.navBar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.PictureBox();
            this.resizeButton = new System.Windows.Forms.PictureBox();
            this.play = new System.Windows.Forms.PictureBox();
            this.bookButton = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notif = new System.Windows.Forms.NotifyIcon(this.components);
            this.Background.SuspendLayout();
            this.panel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forwardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backwardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookButton)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.AllowDrop = true;
            this.Background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Background.Controls.Add(this.panel);
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(693, 532);
            this.Background.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.ColumnCount = 1;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panel.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.RowCount = 2;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panel.Size = new System.Drawing.Size(693, 532);
            this.panel.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Controls.Add(this.homeButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.forwardButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.backwardButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.navBar, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.closeButton, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.resizeButton, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.play, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.bookButton, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(687, 44);
            this.tableLayoutPanel2.TabIndex = 1;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // homeButton
            // 
            this.homeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeButton.Image = global::newKidsPortal.Properties.Resources.home0;
            this.homeButton.Location = new System.Drawing.Point(73, 3);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(29, 30);
            this.homeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.homeButton.TabIndex = 2;
            this.homeButton.TabStop = false;
            this.homeButton.Click += new System.EventHandler(this.homeClick);
            this.homeButton.MouseLeave += new System.EventHandler(this.homeOut);
            this.homeButton.MouseHover += new System.EventHandler(this.homeIn);
            // 
            // forwardButton
            // 
            this.forwardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forwardButton.Image = global::newKidsPortal.Properties.Resources.forward0;
            this.forwardButton.Location = new System.Drawing.Point(38, 3);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(29, 30);
            this.forwardButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.forwardButton.TabIndex = 1;
            this.forwardButton.TabStop = false;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            this.forwardButton.MouseLeave += new System.EventHandler(this.forwardOut);
            this.forwardButton.MouseHover += new System.EventHandler(this.forwardIn);
            // 
            // backwardButton
            // 
            this.backwardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backwardButton.Image = global::newKidsPortal.Properties.Resources.backward0;
            this.backwardButton.Location = new System.Drawing.Point(3, 3);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(29, 30);
            this.backwardButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backwardButton.TabIndex = 0;
            this.backwardButton.TabStop = false;
            this.backwardButton.Click += new System.EventHandler(this.backwardButton_Click);
            this.backwardButton.MouseLeave += new System.EventHandler(this.backwardOut);
            this.backwardButton.MouseHover += new System.EventHandler(this.backwardIn);
            // 
            // navBar
            // 
            this.navBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.navBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.navBar.Font = new System.Drawing.Font("OpenSymbol", 15F);
            this.navBar.Location = new System.Drawing.Point(105, 8);
            this.navBar.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(407, 25);
            this.navBar.TabIndex = 8;
            this.navBar.Text = "Search here...";
            this.navBar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.navBar_MouseClick);
            this.navBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search);
            this.navBar.MouseLeave += new System.EventHandler(this.navBar_MouseLeave);
            this.navBar.MouseHover += new System.EventHandler(this.navBar_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(108, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 2);
            this.panel1.TabIndex = 9;
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closeButton.Image = global::newKidsPortal.Properties.Resources.close0;
            this.closeButton.Location = new System.Drawing.Point(655, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(29, 30);
            this.closeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeButton.TabIndex = 7;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeClick);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeOut);
            this.closeButton.MouseHover += new System.EventHandler(this.closeIn);
            // 
            // resizeButton
            // 
            this.resizeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resizeButton.Image = global::newKidsPortal.Properties.Resources.resize0;
            this.resizeButton.Location = new System.Drawing.Point(620, 3);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(29, 30);
            this.resizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resizeButton.TabIndex = 6;
            this.resizeButton.TabStop = false;
            this.resizeButton.Click += new System.EventHandler(this.resizeClick);
            this.resizeButton.MouseLeave += new System.EventHandler(this.resizeOut);
            this.resizeButton.MouseHover += new System.EventHandler(this.resizeIn);
            // 
            // play
            // 
            this.play.Dock = System.Windows.Forms.DockStyle.Fill;
            this.play.Image = global::newKidsPortal.Properties.Resources.go0;
            this.play.Location = new System.Drawing.Point(515, 3);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(29, 30);
            this.play.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.play.TabIndex = 5;
            this.play.TabStop = false;
            this.play.MouseClick += new System.Windows.Forms.MouseEventHandler(this.playClick);
            this.play.MouseLeave += new System.EventHandler(this.playOut);
            this.play.MouseHover += new System.EventHandler(this.playIn);
            // 
            // bookButton
            // 
            this.bookButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookButton.Image = global::newKidsPortal.Properties.Resources.book0;
            this.bookButton.Location = new System.Drawing.Point(550, 3);
            this.bookButton.Name = "bookButton";
            this.bookButton.Size = new System.Drawing.Size(29, 30);
            this.bookButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bookButton.TabIndex = 4;
            this.bookButton.TabStop = false;
            this.bookButton.Click += new System.EventHandler(this.bookButton_Click);
            this.bookButton.MouseLeave += new System.EventHandler(this.bookOut);
            this.bookButton.MouseHover += new System.EventHandler(this.bookIn);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // notif
            // 
            this.notif.Icon = ((System.Drawing.Icon)(resources.GetObject("notif.Icon")));
            this.notif.Text = "Kids Portal";
            this.notif.Visible = true;
            this.notif.Click += new System.EventHandler(this.show2);
            this.notif.DoubleClick += new System.EventHandler(this.show);
            // 
            // KidsPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(693, 532);
            this.Controls.Add(this.Background);
            this.Font = new System.Drawing.Font("OpenSymbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KidsPortal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kids Portal - Child-Friendly Web  Browser";
            this.Background.ResumeLayout(false);
            this.Background.PerformLayout();
            this.panel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forwardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backwardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel Background;
        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox closeButton;
        private System.Windows.Forms.PictureBox resizeButton;
        private System.Windows.Forms.PictureBox play;
        private System.Windows.Forms.PictureBox bookButton;
        private System.Windows.Forms.PictureBox homeButton;
        private System.Windows.Forms.PictureBox forwardButton;
        private System.Windows.Forms.PictureBox backwardButton;
        public System.Windows.Forms.TextBox navBar;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notif;
    }
}

