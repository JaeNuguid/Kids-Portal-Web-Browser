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
    public partial class Bookmark : Form
    {
        String[] books;
        string path, appDataPath;
        KidsPortal kp;
        public Bookmark(KidsPortal kp, string appDataPath)
        {
            this.appDataPath = appDataPath;
            this.kp = kp;
            InitializeComponent();
        }
        public void setList()
        {


            path = Path.Combine(appDataPath + @"\KidsPortal", "bookmark.txt");

            try
            {
                books = System.IO.File.ReadAllLines(path);
            }
            catch (System.Exception e)
            {
                path = Path.Combine(appDataPath + @"\KidsPortal", "bookmark.txt");
                System.IO.File.WriteAllLines(path, books);
            }
            list.Items.Clear();
            foreach (string x in books)
            {
                list.Items.Add(x);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void add_Click(object sender, EventArgs e)
        {
            string url = box.Text;

            if (url.Length > 3 && (url.Contains(".info") || url.Contains(".gov") || url.Contains(".com") || url.Contains(".io") || url.Contains(".edu") || url.Contains(".net") || url.Contains(".org") ))
            {
                list.Items.Add(url);
                update();
            }
        }

        private void visit_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
               kp.bro.Load(books[list.SelectedIndex]);
            }
            Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                list.Items.RemoveAt(list.SelectedIndex);
            }
            update();
        }

        public void update()
        {


            string[] e = new string[list.Items.Count];
            for (int i = 0; i < list.Items.Count; i++)
            {
                e[i] = list.Items[i].ToString();
            }

            books = e;
            path = Path.Combine(appDataPath + @"\KidsPortal", "bookmark.txt");
            System.IO.File.WriteAllLines(path, books);
           }
    }
}
