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
        public Detection()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setting.set.timer1.Start();
            Setting.set.bre = false;
            this.Hide();
        }
    }
}
