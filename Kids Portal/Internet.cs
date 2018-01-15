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
    public partial class Internet : Form
    {
        Form1 head;
        public Internet(Form1 head)
        {
            InitializeComponent();
            this.head = head;
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            head.goHomepage();
           head.timer1.Start();
        }

        private void Internet_Load(object sender, EventArgs e)
        {

        }
    }
}
