using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newKidsPortal
{
    public partial class Exception : Form
    {

        string[] webs;
        public static Exception exc;
        string path, appDataPath;
        public Exception(string appDataPath)
        {
            exc = this;
            this.appDataPath = appDataPath;
            InitializeComponent();
            path = Path.Combine(appDataPath + @"\KidsPortal", "exception.txt");

            try{
                webs = System.IO.File.ReadAllLines(path);
             }
            catch (System.Exception e)
            {
                path = Path.Combine(appDataPath + @"\KidsPortal", "exception.txt");
                System.IO.File.WriteAllLines(path, webs);
            }

}

        public void SetList()
        {
            webs = System.IO.File.ReadAllLines(path);

            list.Items.Clear();
            foreach (string x in webs)
            {
                list.Items.Add(x);
            }
        }

        public void addException(string x)
        {
                list.Items.Add(x);
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                list.Items.RemoveAt(list.SelectedIndex);
            }
                update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public bool isIgnore(string url)
        {

            bool go = true;
            foreach(string x in webs)
            {
                if (url.ToLower().Contains(x.ToLower())){
                  go = false;
                }
            }
            return go;
        }


        public void update()
        {
     

            string[] e = new string[list.Items.Count];
            for (int i = 0; i < list.Items.Count; i++)
            {
                e[i] = list.Items[i].ToString();
            }

            webs = e;

            path = Path.Combine(appDataPath + @"\KidsPortal", "exception.txt");
            System.IO.File.WriteAllLines(path, webs);
          }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(box.Text.Length>2)
            list.Items.Add(box.Text);
            update();
        }
    }
}
