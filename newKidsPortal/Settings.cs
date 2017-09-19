using newKidsPortal.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        blockedWords bW = new blockedWords();
        ColorDialog colorDialog1 = new ColorDialog();
        String[] urls = { "iexplore", "chrome", "firefox", "opera" };
        string[] tagalog;
        string[] english;
        string[] xWords;
        string appDataPath;
        string path;
        Exception Ex;
        public bool running = false;
       public string text ="";
        Detection det;
        CheckBox[] boxes = new CheckBox[5];
        KidsPortal kp;
          
        string[] webText = new String[2];
     

        public void setWords(string[] e, string[] t)
        {
            english = e;
            tagalog = t;
        }
        public Setting(KidsPortal kp, string store)
        {
            appDataPath = store;
            Ex = new Exception(store);
            this.kp = kp;
            det = new Detection(this);
            bW.Hide();
            InitializeComponent();
            importHistory();
            importReport();
            boxes[0] = b0;
            boxes[1] = b1;
            boxes[2] = b2;
            boxes[3] = b3;
            boxes[4] = b4;
            timer1.Start();

            path = Path.Combine(appDataPath + @"\KidsPortal", "english.txt");
            english = System.IO.File.ReadAllLines(path);
            path = Path.Combine(appDataPath + @"\KidsPortal", "tagalog.txt");            
            tagalog = System.IO.File.ReadAllLines(path);

            bW.setWords(english, tagalog);
            
      

        }
        

        public void getArray()
        {
            if (kp != null)
            {
                text = kp.getText();
                webText = text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                xWords = english.Concat(tagalog).ToArray();
            }
        }

      
        public bool bre = false;
        private void checkEnglish()
        {
            running = true;

            foreach (string line in xWords)
            {
                if (bre) break;
                foreach (string x in webText)
                {

                    if (x != null  )                                               
                        if (x.Equals(line, StringComparison.InvariantCultureIgnoreCase))
                        {
                            //Testing
                            //Console.WriteLine(x + " >> " + line);

                            addReport(kp.navBar.Text, line);
                            det.Show();
                            kp.goHomepage(); 
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
            kp.navBar.BackColor = Color.White;
            kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._1));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            kp.navBar.BackColor = Color.White;
            kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._2));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            kp.navBar.BackColor = Color.White;
            kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._21));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            kp.navBar.BackColor = Color.White;
            kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._3));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            kp.navBar.BackColor = Color.White;
            kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._4));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            kp.navBar.BackColor = Color.White;
            kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._5));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            kp.navBar.BackColor = Color.White;
            kp.Background.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._6));
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }

   

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            kp.navBar.BackColor = Color.FromArgb(255, 255, 192);
            kp.Background.BackColor = Color.FromArgb(255, 255, 192);
            MessageBox.Show("You have successfully changed the theme.", "Kids Portal - Settings Panel");

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                kp.navBar.BackColor = color;
                kp.Background.BackColor = color;
                kp.Background.BackgroundImage = null;
               box.BackColor = color;
            }
        }

    
        private void box_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            custom.Enabled = false;
            kp.set = 0;
            kp.goHomepage();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            custom.Enabled = false;
            kp.set = 2;
            kp.goHomepage();
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            custom.Enabled = true;
            kp.homepage[3] = custom.Text;
            kp.set = 3;
            kp.goHomepage();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            custom.Enabled = false;
            kp.set = 1;
            kp.goHomepage();
        }

        private void custom_TextChanged(object sender, EventArgs e)
        {
            custom.Enabled = true;
            kp.homepage[3] = custom.Text;
            kp.set = 3;
            kp.goHomepage();
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

                    // where checking starts
                    if (kp != null)
                    {
                        if (Ex.isIgnore(kp.urlX) && kp.navBar.Text.Length > 3)
                            checkEnglish();
                    }
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
                            catch (System.Exception e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            bW.Show();
            bW.setEnglish();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ex.Show();
            Ex.SetList();
        }

        string[] hist;

        public void importHistory()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "history.txt");

            try{
                hist = System.IO.File.ReadAllLines(path);
            }
            catch (System.Exception e)
            {
                System.IO.File.WriteAllLines(path, hist);
            }
            historyBox.Items.Clear();
            foreach (string x in hist)
            {
               historyBox.Items.Add(x);
            }
        }

        public void importReport()
        {

            path = Path.Combine(appDataPath + @"\KidsPortal", "report.txt");
            try { 
            repo = System.IO.File.ReadAllLines(path);
            }
            catch (System.Exception e)
            {
                System.IO.File.WriteAllLines(path, repo);
            }
            reportBox.Items.Clear();
            foreach (string x in repo)
            {
                reportBox.Items.Add(x);
            }
        }


        public void addHistory(string x)
        {
           

                if ((x.Contains(".com") || x.Contains(".info") || x.Contains(".edu") || x.Contains(".io") || x.Contains(".net") || x.Contains(".org")))
                {
                  
                historyBox.Items.Add(DateTime.Now.ToString("d/MM/yyyy") + "\t" + DateTime.Now.ToString("hh:mm:ss tt") + "\t " + x);
                    updateHistory();
                }
            
            
        }

        public void addReport(string x,string bad)
        {


            if ((x.Length>3)&&(x.Contains(".com") || x.Contains(".info") || x.Contains(".edu") || x.Contains(".io") || x.Contains(".net") || x.Contains(".org")))
            {
                System.Uri uri = new Uri(x);
                string fixedUri = uri.AbsoluteUri.Replace(uri.Query, string.Empty);
                reportBox.Items.Add(DateTime.Now.ToString("d/MM/yyyy") + "\t" + DateTime.Now.ToString("hh:mm:ss tt") + "\t " + fixedUri+"\t"+bad);
                updateReport();
            }


        }   


        public void updateHistory()
        {
            string[] e = new string[historyBox.Items.Count];
            for (int i = 0; i < historyBox.Items.Count; i++)
            {
                e[i] = historyBox.Items[i].ToString();
            }

            hist = e;

            
            path = Path.Combine(appDataPath + @"\KidsPortal", "history.txt");
            
              System.IO.File.WriteAllLines(path, hist);

        }

        public void updateReport()
        {
            string[] e = new string[reportBox.Items.Count];
            for (int i = 0; i < reportBox.Items.Count; i++)
            {
                e[i] = reportBox.Items[i].ToString();
            }

            repo = e;

            path = Path.Combine(appDataPath + @"\KidsPortal", "report.txt");

            System.IO.File.WriteAllLines(path, repo);
        }

        string[] repo;
        private void button5_Click(object sender, EventArgs e)
        {
            string[] history = new string[historyBox.Items.Count];
            for (int i = 0; i < historyBox.Items.Count; i++)
            {
                history[i] = historyBox.Items[i].ToString();
            }

            if (history[historyBox.SelectedIndex].Contains(".com") || history[historyBox.SelectedIndex].Contains(".info") || history[historyBox.SelectedIndex].Contains(".edu") || history[historyBox.SelectedIndex].Contains(".io") || history[historyBox.SelectedIndex].Contains(".net") || history[historyBox.SelectedIndex].Contains(".org"))
            {
                string[] xx = history[historyBox.SelectedIndex].Split(' ');

                Exception.exc.list.Items.Add(xx[2]);
                Exception.exc.update();
                MessageBox.Show("Successfully added to Exception List.", "Kids Portal - Settings Panel");

            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            historyBox.Items.Clear();
            updateHistory();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            reportBox.Items.Clear();
            updateReport();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string[] reports = new string[reportBox.Items.Count];
            for (int i = 0; i < reportBox.Items.Count; i++)
            {
                reports[i] = reportBox.Items[i].ToString();
            }

            if (reports[reportBox.SelectedIndex].Contains(".com") || reports[reportBox.SelectedIndex].Contains(".info") || reports[reportBox.SelectedIndex].Contains(".edu") || reports[reportBox.SelectedIndex].Contains(".io") || reports[reportBox.SelectedIndex].Contains(".net") || reports[reportBox.SelectedIndex].Contains(".org"))
            {
                string[] xx = reports[reportBox.SelectedIndex].Split(' ');

                Exception.exc.list.Items.Add(xx[2]);
                Exception.exc.update();
                MessageBox.Show("Successfully added to Exception List.", "Kids Portal - Settings Panel");

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if ((box1.Text != box2.Text) || box1.Text.Length < 6)
            {
                box1.Text = "";
                box2.Text = "";
                MessageBox.Show("Invalid Password.", "Kids Portal - Settings Panel");

            }
            else
            {
                string[] config = { "1", box1.Text };

                path = Path.Combine(appDataPath + @"\KidsPortal", "config.txt");
                System.IO.File.WriteAllLines(path, config);
               MessageBox.Show("Your password has been changed successfully.", "Kids Portal - Settings Panel");

                box1.Text = "";
                box2.Text = "";
            }
          
        }
    }
}
