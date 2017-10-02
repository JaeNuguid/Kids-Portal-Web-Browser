using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newKidsPortal
{
    public partial class TimeLimit : Form
    {
        string appDataPath;
        string path;
        string[] times;

        public TimeLimit(string add, Setting set)
        {
            appDataPath = add;
            InitializeComponent();
            h1.SelectedIndex = 0;
            h2.SelectedIndex = 0;
            m1.SelectedIndex = 0;
            m2.SelectedIndex = 0;

        }

     
        public void update()
        {
            string[] ee = new string[box.Items.Count];
            for (int i = 0; i < box.Items.Count; i++)
            {
                ee[i] = box.Items[i].ToString();
            }

            times = ee;

            path = Path.Combine(appDataPath + @"\KidsPortal", "times.txt");
            System.IO.File.WriteAllLines(path, times);
        }

        public void setTimes()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "times.txt");
            times = File.ReadAllLines(path);
            

            box.Items.Clear();
            foreach (string x in times)
            {
                box.Items.Add(x);
            }


        }

    
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button85_Click(object sender, EventArgs e)
        {
            Hide();
        }

     

        public int hourNow()
        {
            int d;
            var date = DateTime.Now;
            d = date.Hour;

            return d;

        }

        public int minuteNow()
        {
            int d;
            var date = DateTime.Now;
            d = date.Minute;

            return d;

        }

        public String dayNow()
        {
           return DateTime.Now.DayOfWeek.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            box.Items.Clear();
            h1.SelectedIndex = 0;
            h2.SelectedIndex = 0;
            m1.SelectedIndex = 0;
            m2.SelectedIndex = 0;

            mon.Checked = false;
            tue.Checked = false;
            wed.Checked = false;
            thu.Checked = false;
            fri.Checked = false;
            sat.Checked = false;
            sun.Checked = false;
            update();
        }

        

        private void button4_Click(object sender, EventArgs ee)
        {
        string hour1 = "00", hour2  = "00", min1 = "00", min2 = "00";
            bool a, b, c, d, e, f, g;
            a = mon.Checked;
            b = tue.Checked;
            c = wed.Checked;
            d = thu.Checked;
            e = fri.Checked;
            f = sat.Checked;
            g = sun.Checked;
            hour1 = (h1.Text);
            hour2 = (h2.Text);
            min1 =(m1.Text);
            min2 = (m2.Text);

            if (Convert.ToInt16(hour1) > Convert.ToInt16(hour2))
            {
                MessageBox.Show("Invalid schedule of hours!", "Kids Portal - Time Limit Panel");

            }
            else if(((Convert.ToInt16(hour1) == Convert.ToInt16(hour2)) && (Convert.ToInt16(min1) == Convert.ToInt16(min2)))|| ((Convert.ToInt16(hour1) == Convert.ToInt16(hour2)) && (Convert.ToInt16(min1) > Convert.ToInt16(min2))))
            {
                MessageBox.Show("Invalid schedule of time!", "Kids Portal - Time Limit Panel");

            }
            else if(!a && !b && !c && !d && !e && !f && !g)
            {
                MessageBox.Show("You must select at least 1 scheduled days", "Kids Portal - Time Limit Panel");

            }
            else
            {
                string xn="";
                if (a) xn += "Monday-";
                if (b) xn += "Tuesday-";
                if (c) xn += "Wednesday-";
                if (d) xn += "Thursday-";
                if (e) xn += "Friday-";
                if (f) xn += "Saturday-";
                if (g) xn += "Sunday-";
                
                string xj = hour1+":"+min1 + " to " + hour2 + ":" + min2 + "\t every " + xn.TrimEnd('-'); ;
                //h1 0,1
                //m1 3,4
                //h2 9,10
                //m2 12,13
                box.Items.Add(xj);
                update();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (box.SelectedIndex >= 0)
            {
                box.Items.RemoveAt(box.SelectedIndex);
            }
            update();
        }
        //h1 0,1
        //m1 3,4
        //h2 9,10
        //m2 12,13
        int fromH = 0;
        int fromM = 0;
        int toH = 0;
        int toM = 0;
        string days;
        public Boolean checkTime()
        {
            int hN = hourNow();
            if(times!=null)
            foreach (string time in times)
            {
                if (time.Contains(dayNow()))
                {
                    fromH = Convert.ToInt16(time.Substring(0, 2));
                    fromM = Convert.ToInt16(time.Substring(3, 2));
                    toH = Convert.ToInt16(time.Substring(9, 2));
                    toM = Convert.ToInt16(time.Substring(12, 2));
                    TimeSpan start = new TimeSpan(fromH, fromM,0); //10 o'clock
                    TimeSpan end = new TimeSpan(toH, toM,0); //12 o'clock
                    TimeSpan now = DateTime.Now.TimeOfDay;

                    if ((now >= start) && (now <= end))
                    {

                        return true;
                        
                    }

                }
            }
            return false;
        }
    }

}