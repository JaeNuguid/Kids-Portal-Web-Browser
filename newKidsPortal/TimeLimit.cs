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
        Button[] times = new Button[84];
        string[] on;
        string appDataPath;
        string path;
        public TimeLimit(string add, Setting set)
        {
           appDataPath= add;
            InitializeComponent();
            times[0] = button1;
            times[1] = button2;
            times[2] = button3;
            times[3] = button4;
            times[4] = button5;
            times[5] = button6;
            times[6] = button7;
            times[7] = button8;
            times[8] = button9;
            times[9] = button10;
            times[10] = button11;
            times[11] = button12;
            times[12] = button13;
            times[13] = button14;
            times[14] = button15;
            times[15] = button16;
            times[16] = button17;
            times[17] = button18;
            times[18] = button19;
            times[19] = button20;
            times[20] = button21;
            times[21] = button22;
            times[22] = button23;
            times[23] = button24;
            times[24] = button25;
            times[25] = button26;
            times[26] = button27;
            times[27] = button28;
            times[28] = button29;
            times[29] = button30;
            times[30] = button31;
            times[31] = button32;
            times[32] = button33;
            times[33] = button34;
            times[34] = button35;
            times[35] = button36;
            times[36] = button37;
            times[37] = button38;
            times[38] = button39;
            times[39] = button40;
            times[40] = button41;
            times[41] = button42;
            times[42] = button43;
            times[43] = button44;
            times[44] = button45;
            times[45] = button46;
            times[46] = button47;
            times[47] = button48;
            times[48] = button49;
            times[49] = button50;
            times[50] = button51;
            times[51] = button52;
            times[52] = button53;
            times[53] = button54;
            times[54] = button55;
            times[55] = button56;
            times[56] = button57;
            times[57] = button58;
            times[58] = button59;
            times[59] = button60;
            times[60] = button61;
            times[61] = button62;
            times[62] = button63;
            times[63] = button64;
            times[64] = button65;
            times[65] = button66;
            times[66] = button67;
            times[67] = button68;
            times[68] = button69;
            times[69] = button70;
            times[70] = button71;
            times[71] = button72;
            times[72] = button73;
            times[73] = button74;
            times[74] = button75;
            times[75] = button76;
            times[76] = button77;
            times[77] = button78;
            times[78] = button79;
            times[79] = button80;
            times[80] = button81;
            times[81] = button82;
            times[82] = button83;
            times[83] = button84;

            for (int x = 0; x < 84; x++)
            {
                times[x].Click += new EventHandler(onClick);
            }

        }

        void onClick(object sender, EventArgs e)
        {
            var btn = sender as Button;

            for (int x = 0; x < 84; x++)
            {
               if(btn == times[x])
                {
                    if (times[x].Text.Contains("Not"))
                    {
                        turnOn(times[x]);
                        on[x] = "1";
                    }
                    else
                    {
                        turnOff(times[x]);
                        on[x] = "0";
                    }
                    update();
                    break;
                }
            }
         
        }

        public void update()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "times.txt");
            System.IO.File.WriteAllLines(path, on);
        }

        public void setButtons()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "times.txt");
            on = File.ReadAllLines(path);

            for(int x =0; x<84; x++)
            {
                if (on[x].Contains("0"))
                {
                    turnOff(times[x]);
                }
                else
                {
                    turnOn(times[x]);
                }
            }
        }

        public void turnOn(Button b)
        {
           b.Text = "Allowed";
         b.BackColor = Color.FromArgb(192, 255, 192);
        }

        public void turnOff(Button b)
        {

         b.BackColor = Color.FromArgb(255, 192, 192);
           b.Text = "Not Allowed";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button85_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public void allowAll()
        {
            for(int x=0; x< 84; x++)
            {
                times[x].Text = "Allowed";
                times[x].BackColor = Color.FromArgb(192, 255, 192);
                on[x] = "1";
            }
            update();
        }
      
        public int hourNow()
        {
            int d;
            var date = DateTime.Now;
           d= date.Hour;
          
            if (!(d % 2 == 0)) d -= 1;
          
            return d;
          
        }


        public bool checkTime()
        {
            string d= System.DateTime.Now.DayOfWeek.ToString();

            switch (d)
            {
                case "Monday":
                    return checkMon();
  

                case "Tuesday":
                    return checkTue();


                case "Wednesday":
                    return checkWed();

                case "Thursday":
                    return checkThur();


                case "Friday":
                    return checkFri();


                case "Saturday":
                    return checkSat();

                case "Sunday":
                    return checkSun();

                default:
                    break;
            }
            return false;
        }
        private void button86_Click(object sender, EventArgs e)
        {
        allowAll();
            update();
        }

        public bool checkMon()
        {
            int y = 0;
            for(int x=0; x< 12; x++)
            {
           
                if (on[x].Contains("0"))
                {
                    if (y == hourNow())
                    {
                       
                        return true;
                    }
                }
                y += 2;
            }
            return false;

        }
        public bool checkTue()
        {
            int y = 0;
            for (int x=12; x < 24; x++)
            {
                if (on[x].Contains("0"))
                {
                    if(y == hourNow())
                    {
                        return true;
                    }
                }
                y += 2;

            }
            return false;

        }
        public bool checkWed()
        {
            int y = 0;
            for (int x=24; x< 36; x++)
            {
                if (on[x].Contains("0"))
                {
                    if (y == hourNow())
                    {
                        return true;
                    }
                }
                y += 2;

            }
            return false;

        }
        public bool checkThur()
        {
            int y = 0;
            for (int x = 36; x < 48; x++)
            {
                if (on[x].Contains("0"))
                {
                    if (y == hourNow())
                    {
                        return true;
                    }
                }
                y += 2;

            }
            return false;

        }
        public bool checkFri()
        {
            int y = 0;
            for (int x = 48; x < 60; x++)
            {
                if (on[x].Contains("0"))
                {
                    if (y == hourNow())
                    {
                        return true;
                    }
                }
                y += 2;

            }
            return false;

        }
        public bool checkSat()
        {
            int y = 0;
            for (int x = 60; x < 72; x++)
            {
                if (on[x].Contains("0"))
                {
                    if (y == hourNow())
                    {
                        return true;
                    }
                }
                y += 2;

            }
            return false;

        }
        public bool checkSun()
        {
            int y = 0;
            for (int x = 72; x < 84; x++)
            {
                if (on[x].Contains("0"))
                {
                    if (y == hourNow())
                    {
                        return true;
                    }
                }
                y += 2;

            }
            return false;

        }

    }
}
