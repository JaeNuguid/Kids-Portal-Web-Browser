namespace newKidsPortal
{
    partial class voice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(voice));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.voiceLabel = new System.Windows.Forms.Label();
            this.voiceBtn = new System.Windows.Forms.Button();
            this.box = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(87, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(491, 77);
            this.label1.TabIndex = 6;
            this.label1.Text = "Voice Command";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::newKidsPortal.Properties.Resources.KidsPortal;
            this.pictureBox2.Location = new System.Drawing.Point(11, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::newKidsPortal.Properties.Resources._9;
            this.pictureBox1.Location = new System.Drawing.Point(596, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // voiceLabel
            // 
            this.voiceLabel.AutoSize = true;
            this.voiceLabel.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voiceLabel.ForeColor = System.Drawing.Color.Green;
            this.voiceLabel.Location = new System.Drawing.Point(392, 165);
            this.voiceLabel.Name = "voiceLabel";
            this.voiceLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.voiceLabel.Size = new System.Drawing.Size(224, 17);
            this.voiceLabel.TabIndex = 12;
            this.voiceLabel.Text = "Voice Command is currently turned on.";
            this.voiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // voiceBtn
            // 
            this.voiceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.voiceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.voiceBtn.Font = new System.Drawing.Font("Trebuchet MS", 25F);
            this.voiceBtn.Location = new System.Drawing.Point(395, 110);
            this.voiceBtn.Name = "voiceBtn";
            this.voiceBtn.Size = new System.Drawing.Size(293, 52);
            this.voiceBtn.TabIndex = 11;
            this.voiceBtn.Text = "TURN OFF";
            this.voiceBtn.UseVisualStyleBackColor = false;
            this.voiceBtn.Click += new System.EventHandler(this.voiceBtn_Click);
            // 
            // box
            // 
            this.box.FormattingEnabled = true;
            this.box.Location = new System.Drawing.Point(11, 194);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(689, 212);
            this.box.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(613, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "CLOSE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 28F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 46);
            this.label2.TabIndex = 15;
            this.label2.Text = "Commands";
            // 
            // voice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(712, 457);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.box);
            this.Controls.Add(this.voiceLabel);
            this.Controls.Add(this.voiceBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "voice";
            this.Text = "voice";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label voiceLabel;
        private System.Windows.Forms.Button voiceBtn;
        private System.Windows.Forms.ListBox box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}