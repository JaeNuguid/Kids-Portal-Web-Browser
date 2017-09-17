using newKidsPortal.Properties;
using newKidsPortal.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newKidsPortal
{

    public partial class blockedWords : Form
    {

        public string[] tagalog;
        public string[] english;
        Setting sett;

        public blockedWords()
        {
            InitializeComponent();

        }
        public blockedWords(Setting dsx)
        {
            this.sett = dsx;
            InitializeComponent();
           
        }

        public void setWords(string[] e, string[] t)
        {
            english = e;
            tagalog = t;

            
        }


        public void setEnglish()
        {
            list.Items.Clear();
            foreach (string x in english)
            {
                list.Items.Add(x); 
            }
        }

        public void setTagalog()
        {
            list.Items.Clear();
            foreach (string x in tagalog)
            {
                list.Items.Add(x);
            }
        }

        public void updateEnglish()
        {
            english = new string[list.Items.Count];
            for (int i = 0; i < list.Items.Count; i++)
            {
               english[i] = list.Items[i].ToString();
            }
            sett.setWords(english, tagalog);
            System.IO.File.WriteAllLines(@"C:\Users\johnson@entsgp\Documents\Visual Studio 2017\Projects\newKidsPortal\newKidsPortal\Resources\english.txt", english);
        }

        public void updateTagalog()
        {
            tagalog = new string[list.Items.Count];
            for (int i = 0; i < list.Items.Count; i++)
            {
                tagalog[i] = list.Items[i].ToString();
            }
            sett.setWords(english, tagalog);
            System.IO.File.WriteAllLines(@"C:\Users\johnson@entsgp\Documents\Visual Studio 2017\Projects\newKidsPortal\newKidsPortal\Resources\tagalog.txt", tagalog);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                list.Items.RemoveAt(list.SelectedIndex);

                if (engBtn.Checked)
                {
                    updateEnglish();
                }
                else
                {
                    updateTagalog();
                }
            }
        }

        private void engClicked(object sender, EventArgs e)
        {
            if (engBtn.Checked)
            {
                setEnglish();
            }
        }

        private void tagClicked(object sender, EventArgs e)
        {
            if (tagBtn.Checked)
            {
                setTagalog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(box.Text.Length> 2)
            {
                list.Items.Add(box.Text);

                if (engBtn.Checked)
                {
                    updateEnglish();
                }
                else
                {
                    updateTagalog();
                }
             }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
