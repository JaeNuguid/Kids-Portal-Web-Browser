namespace newKidsPortal
{
    partial class blockedWords
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
            this.list = new System.Windows.Forms.ListBox();
            this.engBtn = new System.Windows.Forms.RadioButton();
            this.tagBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.box = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(88, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 77);
            this.label1.TabIndex = 4;
            this.label1.Text = "Blocked Words";
            // 
            // list
            // 
            this.list.Font = new System.Drawing.Font("Tahoma", 12F);
            this.list.FormattingEnabled = true;
            this.list.ItemHeight = 19;
            this.list.Location = new System.Drawing.Point(12, 173);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(604, 194);
            this.list.TabIndex = 7;
            // 
            // engBtn
            // 
            this.engBtn.AutoSize = true;
            this.engBtn.Checked = true;
            this.engBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.engBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.engBtn.Location = new System.Drawing.Point(17, 19);
            this.engBtn.Name = "engBtn";
            this.engBtn.Size = new System.Drawing.Size(88, 27);
            this.engBtn.TabIndex = 8;
            this.engBtn.TabStop = true;
            this.engBtn.Text = "English";
            this.engBtn.UseVisualStyleBackColor = true;
            this.engBtn.CheckedChanged += new System.EventHandler(this.engClicked);
            // 
            // tagBtn
            // 
            this.tagBtn.AutoSize = true;
            this.tagBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tagBtn.Location = new System.Drawing.Point(117, 19);
            this.tagBtn.Name = "tagBtn";
            this.tagBtn.Size = new System.Drawing.Size(95, 27);
            this.tagBtn.TabIndex = 9;
            this.tagBtn.Text = "Tagalog";
            this.tagBtn.UseVisualStyleBackColor = true;
            this.tagBtn.CheckedChanged += new System.EventHandler(this.tagClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.engBtn);
            this.groupBox1.Controls.Add(this.tagBtn);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(390, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 58);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(9, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Add Word";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(12, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 35);
            this.button2.TabIndex = 14;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // box
            // 
            this.box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box.Location = new System.Drawing.Point(12, 136);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(220, 31);
            this.box.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(237, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 31);
            this.button3.TabIndex = 13;
            this.button3.Text = "ADD";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(541, 392);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "CLOSE";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::newKidsPortal.Properties.Resources._9;
            this.pictureBox1.Location = new System.Drawing.Point(546, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::newKidsPortal.Properties.Resources.KidsPortal;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // blockedWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(630, 471);
            this.ControlBox = false;
            this.Controls.Add(this.list);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(630, 471);
            this.MinimumSize = new System.Drawing.Size(630, 471);
            this.Name = "blockedWords";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings 2";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListBox list;
        private System.Windows.Forms.RadioButton engBtn;
        private System.Windows.Forms.RadioButton tagBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox box;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}