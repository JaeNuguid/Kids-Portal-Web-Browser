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

namespace Kids_Portal
{
    public partial class Plugin : Form
    {
        Form1 head;
        String appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        String path;


        public Plugin(Form1 head)
        {
            this.head = head;
            InitializeComponent();
        }

        public void updateBookmark()
        {
            string[] e = new string[bookmarkBox.Items.Count];
            for (int i = 0; i < bookmarkBox.Items.Count; i++)
            {
                e[i] = bookmarkBox.Items[i].ToString();
            }

            head.bookmarkData = e;


            path = Path.Combine(appDataPath + @"\KidsPortal", "bookmark.txt");

            System.IO.File.WriteAllLines(path, head.bookmarkData);

        }

        //Add bookmark
        private void button5_Click(object sender, EventArgs e)
        {
            String allen = titleBox.Text;
            String jae = urlBox.Text;

            if(allen.Length < 3)
            {
                MessageBox.Show("Invalid Title\nThe title is too short.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!jae.Contains('.')||jae.Length<3)
            {
                MessageBox.Show("Invalid URL\nYou must input a valid website address or URL.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (Uri.IsWellFormedUriString(jae, UriKind.RelativeOrAbsolute))
            {

                bookmarkBox.Items.Add(allen.ToLower().TrimEnd()+"\t"+ jae.ToLower().TrimEnd());
                updateBookmark();
                MessageBox.Show("Website Successfully Added.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("Invalid URL\nYou must input a valid website address or URL.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                titleBox.Text = "www.example.com";
            }
        }
        //remove bookmark
        private void button2_Click(object sender, EventArgs e)
        {
            if (bookmarkBox.SelectedItem != null)
            {
                bookmarkBox.Items.RemoveAt(bookmarkBox.SelectedIndex);
                updateBookmark();
                MessageBox.Show("A bookmark has been removed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("Please select a bookmark to be removed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }



        //visit bookmark website
        private void button1_Click(object sender, EventArgs e)
        {
            if (bookmarkBox.SelectedItem != null)
            {
                String text = bookmarkBox.GetItemText(bookmarkBox.SelectedItem);
                String[] texts = text.Split('\t');

                head.jae.Load(texts[texts.Length - 1]);
                head.navBar.Enabled = true;
                Hide();

            }
            else
            {
                MessageBox.Show("Please select a bookmark to be viewed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


        public void getHistory()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "history.txt");

            try
            {
                head.historyData = System.IO.File.ReadAllLines(path);
            }
            catch (System.Exception e)
            {
                System.IO.File.WriteAllLines(path, head.historyData);
            }
            historyBox.Items.Clear();
            foreach (string x in head.historyData)
            {
                if(x.Length>3)
                historyBox.Items.Add(x);
            }
        }


        public void getBookmark()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "bookmark.txt");

            try
            {
                head.bookmarkData = System.IO.File.ReadAllLines(path);
            }
            catch (System.Exception e)
            {
                System.IO.File.WriteAllLines(path, head.bookmarkData);
            }
            bookmarkBox.Items.Clear();
            foreach (string x in head.bookmarkData)
            {

                if (x.Length > 3)
                    bookmarkBox.Items.Add(x);
            }
        }




        //Visit history website
        private void button8_Click(object sender, EventArgs e)
        {
            if(historyBox.SelectedItem!= null) { 
            String text = historyBox.GetItemText(historyBox.SelectedItem);
                String[] texts = text.Split('\t');

             head.jae.Load(texts[texts.Length-1]);
            head.navBar.Enabled = true;
                Hide();

            }else
            {
                MessageBox.Show("Please select a web history to be viewed!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private async void pictureBox2_ClickAsync(object sender, EventArgs e)
        {
            Hide();
            await starting();

            async Task starting()
            {
                head.jae.Visible = false;
                head.load.Show();
                head.navBar.Enabled = false;
                await Task.Delay(1000);
                head.load.Hide();
                head.navBar.Enabled = true;
                head.jae.Visible = true;
            }

            head.loadNavBar();
            head.navBar.Enabled = true;
        }

        private void Plugin_VisibleChanged(object sender, EventArgs e)
        {
            getBookmark();
            getHistory();
        }
    }
}
