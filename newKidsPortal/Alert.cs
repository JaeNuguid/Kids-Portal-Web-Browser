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
    public partial class Detection : Form
    {
        Setting sett;
        public Detection(Setting x)
        {
            this.sett = x;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sett.timer1.Start();
            sett.bre = false;
            this.Hide();
        }
    }
}
