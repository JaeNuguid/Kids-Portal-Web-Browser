using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kids_Portal
{
    public partial class Locked : Form
    {

        Form1 head;
        public Locked(Form1 head)
        {
            InitializeComponent();
            this.head = head;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            head.acc.show(1);
        }
    }
}
