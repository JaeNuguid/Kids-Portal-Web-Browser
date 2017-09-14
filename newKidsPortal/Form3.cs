using newKidsPortal.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newKidsPortal
{
    public partial class Setting : Form
    {
        public bool protection =true;
        ColorDialog colorDialog1 = new ColorDialog();
        String[] urls = { "iexplore", "chrome", "firefox", "opera" };
        string[] tagalog;
        string[] english;
        public bool running = false;
       public string text ="";
        Detection det = new Detection();
        CheckBox[] boxes = new CheckBox[5];
        string[] webText = new String[2];
        public static Setting set;
        public Setting()
        {
            
            set = this;
            Console.Write("initated class");
            InitializeComponent();
            timer1.Start();
            
            english = System.IO.File.ReadAllLines(@"C:\Users\johnson@entsgp\Documents\Visual Studio 2017\Projects\newKidsPortal\newKidsPortal\Resources\english.txt");
            tagalog = System.IO.File.ReadAllLines(@"C:\Users\johnson@entsgp\Documents\Visual Studio 2017\Projects\newKidsPortal\newKidsPortal\Resources\tagalog.txt");
            boxes[0] = b0;
            boxes[1] = b1;
            boxes[2] = b2;
            boxes[3] = b3;
            boxes[4] = b4;

        }
        

        public void getArray()
        {
            
                text = KidsPortal.kp.getText();
                webText = text.Split(' ');
           
        }

        private void checkTagalog()
        {
            foreach (string line in tagalog)
            {

                foreach(string x in webText)
                {
                    if (x != null ) {
                        if (Regex.IsMatch(x, line, RegexOptions.IgnoreCase))
                        {
                            det.Show();
                            KidsPortal.kp.goHomepage();
                            timer1.Stop();
                           
                        }
                    }
                }

                
            }
            
            
        }

        public bool bre = false;
        private void checkEnglish()
        {
            running = true;
            checkTagalog    ();
            foreach (string line in english)
            {
                if (bre) break;
                foreach (string x in webText)
                {
                    if (x != null  )                                               
                        if (Regex.IsMatch(x, line, RegexOptions.IgnoreCase))
                        { 
                            
                           det.Show();
                            KidsPortal.kp.goHomepage(); 
                            timer1.Stop();
                            bre = true;
                            break;
                         
                        }
                    
                }

            }
            
            running = false;
        }
        

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function is not yet available","Kids Portal - Settings Panel");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            KidsPortal.kp.navBar.BackColor = Color.White;
            KidsPortal.kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._1));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            KidsPortal.kp.navBar.BackColor = Color.White;
            KidsPortal.kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._2));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            KidsPortal.kp.navBar.BackColor = Color.White;
            KidsPortal.kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._21));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            KidsPortal.kp.navBar.BackColor = Color.White;
            KidsPortal.kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._3));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            KidsPortal.kp.navBar.BackColor = Color.White;
            KidsPortal.kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._4));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            KidsPortal.kp.navBar.BackColor = Color.White;
            KidsPortal.kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._5));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            KidsPortal.kp.navBar.BackColor = Color.White;
            KidsPortal.kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._6));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

   

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            KidsPortal.kp.navBar.BackColor = Color.FromArgb(255, 255, 192);
            KidsPortal.kp.Background.BackColor = Color.FromArgb(255, 255, 192);
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                KidsPortal.kp.navBar.BackColor = color;
                KidsPortal.kp.Background.BackColor = color;
                KidsPortal.kp.Background.BackgroundImage = null;
               box.BackColor = color;
            }
        }

    
        private void box_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            custom.Enabled = false;
            KidsPortal.kp.set = 0;
            KidsPortal.kp.goHomepage();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            custom.Enabled = false;
            KidsPortal.kp.set = 2;
            KidsPortal.kp.goHomepage();
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            custom.Enabled = true;
            KidsPortal.kp.homepage[3] = custom.Text;
            KidsPortal.kp.set = 3;
            KidsPortal.kp.goHomepage();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            custom.Enabled = false;
            KidsPortal.kp.set = 1;
            KidsPortal.kp.goHomepage();
        }

        private void custom_TextChanged(object sender, EventArgs e)
        {
            custom.Enabled = true;
            KidsPortal.kp.homepage[3] = custom.Text;
            KidsPortal.kp.set = 3;
            KidsPortal.kp.goHomepage();
        }

        private void protectionButton_Click(object sender, EventArgs e)
        {
            if (protection)
            {
                protection = false;
                protectionLabel.Text = "Real-Time Protection is currently turend off.";
                protectionLabel.ForeColor = Color.Red;
                protectionButton.Text = "TURN ON";
                timer1.Stop();
            }
            else
            {
                timer1.Start();
                protection = true;

              

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(protection)
            {               
                protectionLabel.Text = "Real-Time Protection is currently turend on.";
                protectionLabel.ForeColor = Color.Green;
                protectionButton.Text = "TURN OFF";
                checkOtherBrowser(boxes);

                getArray();
                if (!running)
                {
                    checkEnglish();
                }
            }

        }

        public void checkOtherBrowser(CheckBox[] boxes)
        {
            for (int x = 0; x < boxes.Length; x++)
            {
                if (boxes[x].Checked)
                {

                    Process[] runningProcess = Process.GetProcesses();
                    for (int i = 0; i < runningProcess.Length; i++)
                    {
                        // compare equivalent process by their name
                        if (runningProcess[i].ProcessName == urls[x])
                        {
                            // kill  running process
                            try
                            {
                                runningProcess[i].Kill();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                        }
                    }
                }

            }


        }

        private void extra_TextChanged(object sender, EventArgs e)
        {
            if(extra.Text.Contains(" ")||extra.Text == null)
            {
                MessageBox.Show("Process should not contain any spaces or should not be blank.", "Kids Portal - Settings Panel");

            }
            else
            urls[4] = extra.Text;
        }
    }
}
