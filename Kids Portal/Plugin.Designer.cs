namespace Kids_Portal
{
    partial class Plugin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.historyTab = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.historyBox = new System.Windows.Forms.ListBox();
            this.bookmarkTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bookmarkBox = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.historyTab.SuspendLayout();
            this.bookmarkTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 20F);
            this.label1.Location = new System.Drawing.Point(130, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plugin Panel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F);
            this.label2.Location = new System.Drawing.Point(133, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(544, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "This is the Plugin Panel, where you can view your web browsing history and \r\nmana" +
    "ge your bookmarks.\r\n";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.historyTab);
            this.tabControl1.Controls.Add(this.bookmarkTab);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 15.25F);
            this.tabControl1.ItemSize = new System.Drawing.Size(52, 30);
            this.tabControl1.Location = new System.Drawing.Point(12, 118);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 390);
            this.tabControl1.TabIndex = 4;
            // 
            // historyTab
            // 
            this.historyTab.Controls.Add(this.button8);
            this.historyTab.Controls.Add(this.historyBox);
            this.historyTab.Location = new System.Drawing.Point(4, 34);
            this.historyTab.Name = "historyTab";
            this.historyTab.Padding = new System.Windows.Forms.Padding(3);
            this.historyTab.Size = new System.Drawing.Size(768, 352);
            this.historyTab.TabIndex = 1;
            this.historyTab.Text = "History";
            this.historyTab.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(582, 303);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(180, 41);
            this.button8.TabIndex = 14;
            this.button8.Text = "Visit Website";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // historyBox
            // 
            this.historyBox.Font = new System.Drawing.Font("Tahoma", 12F);
            this.historyBox.FormattingEnabled = true;
            this.historyBox.HorizontalScrollbar = true;
            this.historyBox.ItemHeight = 19;
            this.historyBox.Location = new System.Drawing.Point(6, 6);
            this.historyBox.Name = "historyBox";
            this.historyBox.ScrollAlwaysVisible = true;
            this.historyBox.Size = new System.Drawing.Size(756, 289);
            this.historyBox.TabIndex = 9;
            // 
            // bookmarkTab
            // 
            this.bookmarkTab.Controls.Add(this.label4);
            this.bookmarkTab.Controls.Add(this.label3);
            this.bookmarkTab.Controls.Add(this.urlBox);
            this.bookmarkTab.Controls.Add(this.button2);
            this.bookmarkTab.Controls.Add(this.titleBox);
            this.bookmarkTab.Controls.Add(this.button5);
            this.bookmarkTab.Controls.Add(this.button1);
            this.bookmarkTab.Controls.Add(this.bookmarkBox);
            this.bookmarkTab.Location = new System.Drawing.Point(4, 34);
            this.bookmarkTab.Name = "bookmarkTab";
            this.bookmarkTab.Padding = new System.Windows.Forms.Padding(3);
            this.bookmarkTab.Size = new System.Drawing.Size(768, 352);
            this.bookmarkTab.TabIndex = 2;
            this.bookmarkTab.Text = "Bookmark";
            this.bookmarkTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F);
            this.label4.Location = new System.Drawing.Point(264, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Website Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.Location = new System.Drawing.Point(9, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Title";
            // 
            // urlBox
            // 
            this.urlBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.urlBox.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlBox.Location = new System.Drawing.Point(398, 244);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(226, 28);
            this.urlBox.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 30);
            this.button2.TabIndex = 19;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // titleBox
            // 
            this.titleBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleBox.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBox.Location = new System.Drawing.Point(52, 244);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(185, 28);
            this.titleBox.TabIndex = 18;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(631, 244);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(131, 30);
            this.button5.TabIndex = 17;
            this.button5.Text = "Add";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(582, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 41);
            this.button1.TabIndex = 16;
            this.button1.Text = "Visit Website";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bookmarkBox
            // 
            this.bookmarkBox.Font = new System.Drawing.Font("Tahoma", 12F);
            this.bookmarkBox.FormattingEnabled = true;
            this.bookmarkBox.HorizontalScrollbar = true;
            this.bookmarkBox.ItemHeight = 19;
            this.bookmarkBox.Location = new System.Drawing.Point(6, 6);
            this.bookmarkBox.Name = "bookmarkBox";
            this.bookmarkBox.ScrollAlwaysVisible = true;
            this.bookmarkBox.Size = new System.Drawing.Size(756, 232);
            this.bookmarkBox.TabIndex = 15;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Kids_Portal.Properties.Resources.exit1;
            this.pictureBox2.Location = new System.Drawing.Point(753, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_ClickAsync);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kids_Portal.Properties.Resources.KidsPortal;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Plugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(800, 520);
            this.MinimumSize = new System.Drawing.Size(800, 520);
            this.Name = "Plugin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.Plugin_VisibleChanged);
            this.tabControl1.ResumeLayout(false);
            this.historyTab.ResumeLayout(false);
            this.bookmarkTab.ResumeLayout(false);
            this.bookmarkTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage historyTab;
        private System.Windows.Forms.TabPage bookmarkTab;
        public System.Windows.Forms.ListBox historyBox;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ListBox bookmarkBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox urlBox;
    }
}