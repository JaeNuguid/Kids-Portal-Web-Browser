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
    public partial class Access : Form
    {

        Form1 head;
        int home = 0;
        public Access(Form1 head)
        {
            this.head = head;
            InitializeComponent();
        }

        public void show(int a)
        {
            a = home;
            Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            String user = userBox.Text;
            String pass = passBox.Text;

            if(user.Length <=3)
            {
                MessageBox.Show("Invalid username.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if(pass.Length <=3)
            {
                MessageBox.Show("Invalid password.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if(user.Equals(head.username) && pass.Equals(head.password))
                {
                    head.set.Show();
                    if(home ==0)
                    head.set.tabControl1.SelectedIndex = 0;
                    else if(home == 1)
                    head.set.tabControl1.SelectedIndex = 7;
                    Hide();
                    userBox.Text = "";
                    passBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Login failed. Incorrect username or password.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            
        }
    }
}
