using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kids_Portal
{
    public partial class Settings : Form
    {
        ToolTip toolTip = new ToolTip();
        Form1 head;
        public bool webBrowserControlStatus = true;
        public bool protectionStatus = true;
        String appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        String path;
        public Settings(Form1 head)
        {
            this.head = head;
            InitializeComponent();
            currentColor.BackColor = head.tableLayoutPanel1.BackColor;
            currentColor2.BackColor = head.navBar.ForeColor;

            if (head.done)
            {
                setWords();
                getHistory();
                getReport();
                getTime();
                setColor();
            }
        }

        //preset
        public Settings(Form1 head, Color browserAndNavBarColor, Color navTextColor, int searchEngine, String homepage, bool protectionSatus, bool browserControlStatus)
        {
            InitializeComponent();
            this.head = head;

            // color of background and navigation bar
            // color of navigation bar font
            // index of search engine
            // homepage
            // protection and web control status

            // ->
            head.BackColor = browserAndNavBarColor;
            head.navBar.BackColor = browserAndNavBarColor;

            head.navBar.ForeColor = navTextColor;

            head.searchEngineIndex = searchEngine;
            head.homepage = homepage;

            setProtection(protectionSatus);
            setWebControl(browserControlStatus);

            currentColor.BackColor = head.tableLayoutPanel1.BackColor;
            currentColor2.BackColor = head.navBar.ForeColor;
        }



        private async void closeClickAsync(object sender, EventArgs e)
        {

            Hide();

            if (!head.timeout)
            {
                await starting();

                async Task starting()
                {
                    head.jae.Visible = false;
                    head.load.Show();
                    head.navBar.Enabled = false;
                    await Task.Delay(3000);
                    head.load.Hide();
                    head.navBar.Enabled = true;
                    head.jae.Visible = true;
                }
            }

            head.loadNavBar();
            head.navBar.Enabled = true;

        }

        private void closeHover(object sender, EventArgs e)
        {
            toolTip.Show("Close Settings Panel", pictureBox2);
        }

        #region Theme
        private void changeClick(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.AllowFullOpen = false;
            dlg.AnyColor = true;
            dlg.SolidColorOnly = false;
            dlg.ShowHelp = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                head.tableLayoutPanel1.BackColor = dlg.Color;
                head.navBar.BackColor = dlg.Color;
                currentColor.BackColor = dlg.Color;
                MessageBox.Show("Background Color Successfully Changed to " + dlg.Color.Name + "!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //save color table & navbar
            }
            updateSetting();
        }

        private void searchEngineClick(object sender, EventArgs e)
        {
            head.searchEngineIndex = searchEngine.SelectedIndex;
            MessageBox.Show("Search Engine Successfully Changed to " + searchEngine.Text + "!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            updateSetting();
            //save index
        }

        private void navBarColorClick(object sender, EventArgs e)
        {

            ColorDialog dlg = new ColorDialog();
            dlg.AllowFullOpen = false;
            dlg.AnyColor = false;
            dlg.SolidColorOnly = false;
            dlg.ShowHelp = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                head.navBar.ForeColor = dlg.Color;
                currentColor2.BackColor = dlg.Color;
                MessageBox.Show("Navigation Bar Font Color Successfully Changed to " + dlg.Color.Name + "!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //save color2] navbar font
            }
            updateSetting();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String jae = homepageBox.Text;
            if (!jae.Contains('.') || jae.Contains(' '))
            {
                MessageBox.Show("Invalid URL\nYou must input a valid website address or URL.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (Uri.IsWellFormedUriString(jae, UriKind.RelativeOrAbsolute))
            {
                head.homepage = homepageBox.Text;
                MessageBox.Show("Homepage Successfully Changed.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("Invalid URL\nYou must input a valid website address or URL.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                homepageBox.Text = "www.example.com";
            }
            updateSetting();
        }


        private void defaultClick(object sender, EventArgs e)
        {
            historyBox.Items.Clear();
            setProtection(true);
            setWebControl(true);
            head.navBar.ForeColor = Color.Black;
            currentColor2.BackColor = Color.Black;
            head.tableLayoutPanel1.BackColor = Color.Beige;
            head.navBar.BackColor = Color.Beige;
            currentColor.BackColor = Color.Beige;
            searchEngine.SelectedIndex = 0;
            head.searchEngineIndex = searchEngine.SelectedIndex;
            head.homepage = "https://www.google.com/search?safe=active";
            homepageBox.Text = "www.google.com";
            String time = "12:00 AM - 11:59 PM / mon-tue-wed-thu-fri-sat-sun / Disable Kids Portal";
            timeBox.Items.Clear();
            timeBox.Items.Add(time);

            updateSetting();
            //Time Management
            String[] timex = { "12:00 AM - 11:59 PM / mon-tue-wed-thu-fri-sat-sun / Disable Kids Portal" };
            path = Path.Combine(appDataPath + @"\KidsPortal", "time.txt");
            System.IO.File.WriteAllLines(path, timex);

            MessageBox.Show("Successfully Changed Back to Default Settings", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        public void hardReset()
        {

            historyBox.Items.Clear();
            setProtection(true);
            setWebControl(true);
            head.navBar.ForeColor = Color.Black;
            currentColor2.BackColor = Color.Black;
            head.tableLayoutPanel1.BackColor = Color.Beige;
            head.navBar.BackColor = Color.Beige;
            currentColor.BackColor = Color.Beige;
            searchEngine.SelectedIndex = 0;
            head.searchEngineIndex = searchEngine.SelectedIndex;
            head.homepage = "https://www.google.com/search?safe=active";
            homepageBox.Text = "www.google.com";
            String time = "12:00 AM - 11:59 PM / mon-tue-wed-thu-fri-sat-sun / Disable Kids Portal";
            timeBox.Items.Clear();
            timeBox.Items.Add(time);

            updateSetting();
            //Time Management
            String[] timex = { "12:00 AM - 11:59 PM / mon-tue-wed-thu-fri-sat-sun / Disable Kids Portal" };
            path = Path.Combine(appDataPath + @"\KidsPortal", "time.txt");
            System.IO.File.WriteAllLines(path, timex);

            
        }
        #endregion



        public bool webBrowserControlIsOn()
        {
            return webBrowserControlStatus;
        }
        public bool protectionIsOn()
        {
            return protectionStatus;
        }

        public void setWebControl(bool x)
        {
            webBrowserControlStatus = x;
            if (x)
            {
                webBrowserControl.Image = ((System.Drawing.Image)(Properties.Resources.on));

            }
            else
            {
                webBrowserControl.Image = ((System.Drawing.Image)(Properties.Resources.off));

            }
            webBrowserControl.Refresh();
        }
        public void setProtection(bool x)
        {
            protectionStatus = x;
            if (x)
            {
                Protection.Image = ((System.Drawing.Image)(Properties.Resources.on));

            }
            else
            {
                Protection.Image = ((System.Drawing.Image)(Properties.Resources.off));

            }
            Protection.Refresh();
        }
        private void btnWebBrowserControlHover(object sender, EventArgs e)
        {
            toolTip.Show("Turn on/off Web Browser Control", webBrowserControl);
        }

        private void webBrowserControl_MouseDown(object sender, MouseEventArgs e)
        {

            if (webBrowserControlIsOn())
            {
                webBrowserControl.Image = ((System.Drawing.Image)(Properties.Resources.off));
                setWebControl(false);
            }
            else if (!webBrowserControlStatus)
            {
                webBrowserControl.Image = ((System.Drawing.Image)(Properties.Resources.on));
                setWebControl(true);
            }
            webBrowserControl.Refresh();
            updateSetting();
        }

        private void protectionBtn(object sender, MouseEventArgs e)
        {
            if (protectionIsOn())
            {
                Protection.Image = ((System.Drawing.Image)(Properties.Resources.off));
                setProtection(false);
            }
            else if (!protectionStatus)
            {
                Protection.Image = ((System.Drawing.Image)(Properties.Resources.on));
                setProtection(true);
            }
            Protection.Refresh();
            updateSetting();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            head.jae.Load("https://jaenuguid.github.io/Kids-Portal-Web-Browser/");
            head.navBar.Enabled = true;
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            head.jae.Load("https://jaenuguid.github.io/Kids-Portal-Web-Browser/#target");
            head.navBar.Enabled = true;
            Hide();
        }

        private void englishBtn_Click(object sender, EventArgs e)
        {
            if (englishText.Text.Length > 2)
            {

                if (ifContains(head.english.ToArray(), englishText.Text.ToLower().Trim()) != -1)
                {
                    //will be deleted

                    englishBox.Items.RemoveAt(ifContains(head.english.ToArray(), englishText.Text.ToLower().TrimEnd().Trim()));
                    updateEnglish();
                    MessageBox.Show(englishText.Text + " has been removed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    //will be added

                    englishBox.Items.Add(englishText.Text.ToLower().TrimEnd().Trim());
                    updateEnglish();
                    MessageBox.Show(englishText.Text + " has been added!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            else
            {
                MessageBox.Show("the word must be more than 2 letters!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        public int ifContains(String[] arr, String word)
        {
            int index = Array.IndexOf(arr, word);

            return index;
        }

        private void tagalogBtn_Click(object sender, EventArgs e)
        {
            if (tagalogText.Text.Length > 2)
            {

                if (ifContains(head.tagalog.ToArray(), tagalogText.Text.ToLower()) != -1)
                {
                    //will be deleted

                    tagalogBox.Items.RemoveAt(ifContains(head.tagalog.ToArray(), tagalogText.Text.ToLower()));
                    updateTagalog();
                    MessageBox.Show(tagalogText.Text + " has been removed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    //will be added

                    tagalogBox.Items.Add(tagalogText.Text.ToLower());
                    updateTagalog();
                    MessageBox.Show(tagalogText.Text + " has been added!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            else
            {
                MessageBox.Show("the word must be more than 2 letters!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        public void updateSetting()
        {
            String stat = "1";
            path = Path.Combine(appDataPath + @"\KidsPortal", "setting.txt");


            if (head.username.Equals("jaejaejae"))
                stat = "0";
            else
                stat = "1";
                String[] account = { stat, head.username, head.password, (head.navBar.BackColor.R.ToString()) + " " + (head.navBar.BackColor.G.ToString()) + " " + (head.navBar.BackColor.B.ToString()), (head.navBar.ForeColor.R.ToString()) + " " + (head.navBar.ForeColor.G.ToString()) + " " + (head.navBar.ForeColor.B.ToString()), protectionIsOn().ToString(), webBrowserControlIsOn().ToString(), head.homepage, head.searchEngineIndex.ToString() };

            
            System.IO.File.WriteAllLines(path, account);
            //MessageBox.Show(protectionIsOn() + " <<");

           head.pushConfig(stat, head.username, head.password, (head.navBar.BackColor.R.ToString()) + " " + (head.navBar.BackColor.G.ToString()) + " " + (head.navBar.BackColor.B.ToString()), (head.navBar.ForeColor.R.ToString()) + " " + (head.navBar.ForeColor.G.ToString()) + " " + (head.navBar.ForeColor.B.ToString()), protectionIsOn(), webBrowserControlIsOn(), head.homepage, head.searchEngineIndex);
            

        }



        public void updateEnglish()
        {
            String[] holder = new string[englishBox.Items.Count];
            for (int i = 0; i < englishBox.Items.Count; i++)
            {
               holder[i] = englishBox.Items[i].ToString();
            }
            List<String> newEnglish = holder.ToList();
            newEnglish.Sort();
            head.english = newEnglish;
            path = Path.Combine(appDataPath + @"\KidsPortal", "english.txt");
            System.IO.File.WriteAllLines(path, newEnglish);


            setWords();
        }
        public void updateTagalog()
        {
           String[] holder = new string[tagalogBox.Items.Count];

            for (int i = 0; i < tagalogBox.Items.Count; i++)
            {
              holder[i] = tagalogBox.Items[i].ToString();
            }

            List<String> newTagalog = holder.ToList<String>();
            newTagalog.Sort();
            head.tagalog = newTagalog;
            path = Path.Combine(appDataPath + @"\KidsPortal", "tagalog.txt");
            System.IO.File.WriteAllLines(path, newTagalog);

            setWords();

        }
        public void updateReport()
        {

            string[] e = new string[reportBox.Items.Count];
            for (int i = 0; i < reportBox.Items.Count; i++)
            {
                e[i] = reportBox.Items[i].ToString();
            }

            head.reportData = e;


            path = Path.Combine(appDataPath + @"\KidsPortal", "report.txt");

            System.IO.File.WriteAllLines(path, head.reportData);
            

        }

        public void updateHistory()
        {
            string[] e = new string[historyBox.Items.Count];
            for (int i = 0; i < historyBox.Items.Count; i++)
            {
                e[i] = historyBox.Items[i].ToString();
            }

            head.historyData = e;


            path = Path.Combine(appDataPath + @"\KidsPortal", "history.txt");

            System.IO.File.WriteAllLines(path, head.historyData);

        }

        public void updateTime()
        {
            string[] e = new string[timeBox.Items.Count];
            for (int i = 0; i < timeBox.Items.Count; i++)
            {
                e[i] = timeBox.Items[i].ToString();
            }

            head.timeData = e;


            path = Path.Combine(appDataPath + @"\KidsPortal", "time.txt");

            System.IO.File.WriteAllLines(path, head.timeData);

        }




        public void getTime()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "time.txt");

            try
            {
                head.timeData = System.IO.File.ReadAllLines(path);
            }
            catch (System.Exception e)
            {
                System.IO.File.WriteAllLines(path, head.timeData);
            }
            timeBox.Items.Clear();
            foreach (string x in head.timeData)
            {

                if (x.Length > 3)
                    timeBox.Items.Add(x);
            }
        }

        public void getHistory()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "history.txt");

            try
            {
                head.historyData = System.IO.File.ReadAllLines(path);
            }
            catch (System.Exception e)
            {
                try
                {
                    System.IO.File.WriteAllLines(path, head.historyData);
                }
                catch (Exception ee)
                {
                    string[] nul = { "" };
                    path = Path.Combine(appDataPath + @"\KidsPortal", "history.txt");
                    System.IO.File.WriteAllLines(path, nul);

                }
            }
            historyBox.Items.Clear();
            foreach (string x in head.historyData)
            {

                if (x.Length > 3)
                    historyBox.Items.Add(x);
            }
        }
        public void getReport()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "report.txt");

            try
            {
                head.reportData = System.IO.File.ReadAllLines(path);
            }
            catch (System.Exception e)
            {
                System.IO.File.WriteAllLines(path, head.reportData);
            }
            reportBox.Items.Clear();
            foreach (string x in head.reportData)
            {
                if (x.Length > 3)
                    reportBox.Items.Add(x);
            }
        }


   


        public void setWords()
        {
            englishBox.Items.Clear();

            foreach (string x in head.english)
            {
                englishBox.Items.Add(x.ToLower());

            }


            tagalogBox.Items.Clear();
            foreach (string x in head.tagalog)
            {
                tagalogBox.Items.Add(x.ToLower());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            historyBox.Items.Clear();
            updateHistory();
        }

        private void Settings_VisibleChanged(object sender, EventArgs e)
        {
            if (head.done)
            {
                setWords();
                getHistory();
                getReport();
                getTime();
                setColor();
            }
        }

        public void setColor()
        {
            currentColor.BackColor = head.tableLayoutPanel1.BackColor;
            currentColor2.BackColor = head.navBar.ForeColor;
        }

        //Visit history website
        private void button9_Click(object sender, EventArgs e)
        {
            if (historyBox.SelectedItem != null)
            {
                String text = historyBox.GetItemText(historyBox.SelectedItem);
                String[] texts = text.Split('\t');

                head.jae.Load(texts[texts.Length - 1]);
                head.navBar.Enabled = true;
                Hide();

            }
            else
            {
                MessageBox.Show("Please select a web history to be viewed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            reportBox.Items.Clear();
            updateReport();
        }

        //Visit report website
        private void button10_Click(object sender, EventArgs e)
        {
            if (reportBox.SelectedItem != null)
            {
                String text = reportBox.GetItemText(reportBox.SelectedItem);
                String[] texts = text.Split('\t');


                if ((texts[texts.Length - 1]).Contains("Web Browser Control"))
                {
                    MessageBox.Show("You may only view websites, not applications!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    head.jae.Load(texts[texts.Length - 1]);
                    head.navBar.Enabled = true;
                    Hide();
                }

            }
            else
            {
                MessageBox.Show("Please select a web report to be viewed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You are about to close Kids Portal. \n\nAre you sure?", "Kids Portal - Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 7;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (timeBox.SelectedItem != null)
            {
                if(timeBox.Items.Count <= 1)
                {
                    MessageBox.Show("You cannot remove this, you must have at least one schedule set!\n\n" +
                        "If you find trouble using this function, you may visit our website for instruction.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    timeBox.Items.RemoveAt(timeBox.SelectedIndex);
                    updateTime();
                    MessageBox.Show("A schedule has been removed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            else
            {
                MessageBox.Show("Please select a schedule to be removed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bool go = true;



            if (fromSun.SelectedIndex > toSun.SelectedIndex)
            {

                MessageBox.Show("Invalid time, the 'From' time should be earlier!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                go = false;
            }

            if ((fromSun.SelectedIndex == toSun.SelectedIndex) && (fromHour.SelectedIndex == toHour.SelectedIndex) && (fromMin.SelectedIndex == toMin.SelectedIndex))
            {
                MessageBox.Show("Invalid time, the 'From' time should be earlier!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                go = false;
            }

            if (go && (fromSun.SelectedIndex == toSun.SelectedIndex))
            {
                if (toHour.SelectedIndex < fromHour.SelectedIndex)
                {
                    MessageBox.Show("Invalid time, the 'From' time should be earlier!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    go = false;
                }
                if (toHour.SelectedIndex == fromHour.SelectedIndex)
                {
                    if (toMin.SelectedIndex < fromMin.SelectedIndex)
                    {
                        MessageBox.Show("Invalid time, the 'From' time should be earlier!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        go = false;
                    }
                }
            }


            if (go && (!mon.Checked && !tue.Checked && !wed.Checked && !thu.Checked && !fri.Checked && !sat.Checked && !sun.Checked))
            {
                MessageBox.Show("You must select at least one day of the week!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                go = false;
            }

            if (go)
            {


                String theTime = "";

                try
                {
                    theTime += fromHour.SelectedItem.ToString() + ":" + fromMin.SelectedItem.ToString() + " " + fromSun.SelectedItem.ToString() + " - ";
                    theTime += toHour.SelectedItem.ToString() + ":" + toMin.SelectedItem.ToString() + " " + toSun.SelectedItem.ToString() + " / ";
                }
                catch (Exception ee)
                {
                    go = false;
                    MessageBox.Show("Please select a valid time!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                if (go)
                {
                    if (mon.Checked)
                    {
                        theTime += "mon-";
                    }
                    if (tue.Checked)
                    {

                        theTime += "tue-";
                    }
                    if (wed.Checked)
                    {

                        theTime += "wed-";
                    }
                    if (thu.Checked)
                    {

                        theTime += "thu-";
                    }
                    if (fri.Checked)
                    {

                        theTime += "fri-";
                    }
                    if (sat.Checked)
                    {

                        theTime += "sat-";
                    }
                    if (sun.Checked)
                    {

                        theTime += "sun";
                    }
                    theTime = theTime.TrimEnd('-');
                    theTime += " / ";

                    if (radioButton1.Checked)
                    {
                        theTime += "Disable Kids Portal";
                        //disable  Kids Portal
                    }
                    else if (radioButton2.Checked)
                    {
                        theTime += "Logout Computer";
                        //logout
                    }
                    else
                    {
                        theTime += "Shutdown Computer";
                        //shutdown
                    }

                    if (ifContains(head.timeData, theTime) >= 0)
                    {
                        MessageBox.Show("Schedule Already Exist!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {

                        timeBox.Items.Add(theTime);
                        updateTime();
                        MessageBox.Show("Schedule Successfully Added.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }

            }

            
        }


        private void radioButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will logout your computer with NO warning." +
               "\n\nWARNING:\nThis may cause your computer to be unusable.\nMake sure to always have a schedule for use.\nSince it will 'logout', even the parent/guardian/admin will not be able to use the computer." +
               "\n\nIf this happens, using different device, you may visit our website for instructions.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will logout your computer with NO warning." +
                "\n\nWARNING:\nThis may cause your computer to be unusable.\nMake sure to always have a schedule for use.\nSince it will 'shutdown', even the parent/guardian/admin will not be able to use the computer." +
                "\n\nIf this happens, using different device, you may visit our website for instructions.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btn_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click_1(object sender, EventArgs e)
        {
            String pass = passBox.Text;
            String pass2 = pass2Box.Text;
            bool go = true;


            if (pass.Length < 5)
            {
                MessageBox.Show("Password too short, must be at least 6!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                go = false;
            }

            else if (!pass.Equals(pass2))
            {
                MessageBox.Show("Password does not match!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                go = false;
            }

            if (go)
            {

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    pass = pass,
                    changed = false,
                });

                var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Accounts/" + head.username + ".json");
                request.Method = "PATCH";
                request.ContentType = "application/json";
                var buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                var response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                head.password = pass;
                updateSetting();
                head.pushConfig("1", head.username, head.password, (head.navBar.BackColor.R.ToString()) + " " + (head.navBar.BackColor.G.ToString()) + " " + (head.navBar.BackColor.B.ToString()), (head.navBar.ForeColor.R.ToString()) + " " + (head.navBar.ForeColor.G.ToString()) + " " + (head.navBar.ForeColor.B.ToString()), protectionIsOn(), webBrowserControlIsOn(), head.homepage, head.searchEngineIndex);

                MessageBox.Show("Password Successfully Changed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pass2Box.Text = "";
                passBox.Text = "";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the list of English words considered as inappropriate terms. If a website contains a word that is in this list, it will be blocked.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the list of Tagalog words considered as inappropriate terms. If a website contains a word that is in this list, it will be blocked.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This will automatically detect any installed internet browser on your computer and block it if this function is enabled." +
                "\n\nIn case you are using an uncommon internet browser, or it is not being detected by our Web Browser Control, please contact us for assistance.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("The websites listed here contains an inappropriate content.\n\n" +
                "Note that you must turn off 'Real-Time Protection' first, in order to view a website listed here.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A search engine is a software system that is designed to search for information on the World Wide Web." +
                "\n\nIf you want to use a different search engine not listed here, you may contact us to request for a new search engine integration.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is where the Kids Portal Web Browser goes back to after it blocks a website.\n\nPlease input an appropriate and safe website as a homepage, or else it will result in an infinite loop. If this happens, visit our website for instructions.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The web browsing history refers to the list of web pages the user has visited recently—and associated data such as page title and time of visit—which is recorded by Kids Portal as standard for a certain period of time.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 7)
            MessageBox.Show("Please use this function carefully", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void englishBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            englishText.Text = englishBox.GetItemText(englishBox.SelectedItem);
        }

        private void tagalogBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            tagalogText.Text = tagalogBox.GetItemText(tagalogBox.SelectedItem);
        }
    }
}
