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

namespace newKidsPortal.Resources
{
    public partial class Registration : Form
    {
        KidsPortal kp;
        string path;
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      

        public Registration(KidsPortal kp, string path)
        {
            this.path = path;
            this.kp = kp;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            box1.Text = "";
            box2.Text = "";
            error.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((box1.Text != box2.Text) || box1.Text.Length < 6)
            {
                box1.Text = "";
                box2.Text = "";
                error.Visible = true;
            }
            else
            {
                string[] config = {"1",box1.Text};
                path = Path.Combine(appDataPath + @"\KidsPortal", "config.txt");
                System.IO.File.WriteAllLines(path, config);
                MessageBox.Show("You are successfully registered!\n\n" +
                    "Type \"//setting\" in the navigation bar and press Enter key" +
                    " to access the control panel.", "Kids Portal - Settings Panel");

                this.Hide();
                kp.Show();
            }
        }
    }
}
