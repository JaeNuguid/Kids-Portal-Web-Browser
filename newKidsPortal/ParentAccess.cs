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
    public partial class Login : Form
    {
        Setting set;
        KidsPortal kp;
        string[] config;
        string path;
        string appDataPath;
        public Login(KidsPortal kp,Setting set, string appDataPath)
        {
            this.appDataPath = appDataPath;
            this.kp = kp;
            this.set = set;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "config.txt");  
            config = System.IO.File.ReadAllLines(path);
            
            if (box.Text == config[2] && email.Text == config[1])
            {
                set.Show();
                box.Text = "";
                error.Visible = false;
                this.Hide();
            }
            else
            {
                error.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
