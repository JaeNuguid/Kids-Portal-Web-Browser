using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using newKidsPortal.Resources;
using System.IO;

namespace newKidsPortal
{
    public partial class KidsPortal : Form
    {

        public string previous = "testing";
        private String tempoNavBar = "";
        public ChromiumWebBrowser bro;

        ToolTip toolTip = new ToolTip();
        public Setting sett;
        public Login n;
        public string[] homepage = { "https://www.google.com", "http://www.kiddle.co/", "http://www.kidrex.org/", "" };
        string[] searches = { "https://www.google.com/search?q=", "http://www.kiddle.co/s.php?q=", "http://www.kidrex.org/results/?q=", "https://www.google.com/search?q=" };
        public int set = 2;
        public string[] config;
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string path;


        public KidsPortal()
        {
         InitializeComponent();
         System.IO.Directory.CreateDirectory(appDataPath +@"\KidsPortal");
           
            
            // Start the browser after initialize global component
            InitializeChromium();


           path = Path.Combine(appDataPath + @"\KidsPortal", "config.txt");
            if (!File.Exists(path))
            {
                string[] nul = { };
                string[] xx = { "0", "password" };
                System.IO.File.WriteAllLines(path,xx);

                reCreate();
               
            }

            path = Path.Combine(appDataPath + @"\KidsPortal", "config.txt");
            config = System.IO.File.ReadAllLines(path);

            if (config[0] == "0")
            {
                this.Hide();
                reCreate();
                Registration reg = new Registration(this, appDataPath);
                reg.Show();
            }

            config = System.IO.File.ReadAllLines(path);

            sett = new Setting(this, appDataPath);
            n = new Login(this, sett, appDataPath);
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => navBar.Text = args.Address
            );
            urlX = navBar.Text;
        }


        public void reCreate()
        {
            words wor = new words();
            string[] en = wor.getEnglish();
            string[] ta = wor.getTagalog();
            path = Path.Combine(appDataPath + @"\KidsPortal", "english.txt");
            System.IO.File.WriteAllLines(path, en);
            path = Path.Combine(appDataPath + @"\KidsPortal", "tagalog.txt");
            System.IO.File.WriteAllLines(path, ta);
            string[] nul = { };
            path = Path.Combine(appDataPath + @"\KidsPortal", "exception.txt");
            System.IO.File.WriteAllLines(path, nul);
            path = Path.Combine(appDataPath + @"\KidsPortal", "history.txt");
            System.IO.File.WriteAllLines(path, nul);
            Console.WriteLine(">>>" + path);
            path = Path.Combine(appDataPath + @"\KidsPortal", "report.txt");
            System.IO.File.WriteAllLines(path, nul);
        }
        public void addHistory(string x)
        {
            sett.addHistory(x);
        }

        public string urlX = "";

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
           bro = new ChromiumWebBrowser(homepage[set]);
           
            // Add it to the form and fill it to the form window.
            panel.Controls.Add(bro);
           bro.Margin = new Padding(25,5,25,25);
           bro.Dock = DockStyle.Fill;
            bro.AddressChanged += OnBrowserAddressChanged;
            
        }
            
      


        private void backwardIn(object sender, EventArgs e)
        {

            toolTip.Show("Previous Page", backwardButton);
            backwardButton.Image = ((System.Drawing.Image)(Properties.Resources.backward1));
          
        }

        private void backwardOut(object sender, EventArgs e)
        {
            backwardButton.Image = ((System.Drawing.Image)(Properties.Resources.backward0));

        }

        private void forwardIn(object sender, EventArgs e)
        {
            toolTip.Show("Next Page", forwardButton);
            forwardButton.Image = ((System.Drawing.Image)(Properties.Resources.forward1));
        }

        private void forwardOut(object sender, EventArgs e)
        {
            forwardButton.Image = ((System.Drawing.Image)(Properties.Resources.forward0));
        }

        private void homeIn(object sender, EventArgs e)
        {
            toolTip.Show("Homepage",homeButton );
            homeButton.Image = ((System.Drawing.Image)(Properties.Resources.home1));
        }

        private void homeOut(object sender, EventArgs e)
        {
            homeButton.Image = ((System.Drawing.Image)(Properties.Resources.home0));

        }

        private void bookIn(object sender, EventArgs e)
        {
            toolTip.Show("Bookmark Manager", bookButton);
            bookButton.Image = ((System.Drawing.Image)(Properties.Resources.book1));

        }

        private void bookOut(object sender, EventArgs e)
        {

            bookButton.Image = ((System.Drawing.Image)(Properties.Resources.book0));
        }

        private void resizeIn(object sender, EventArgs e)
        {
            toolTip.Show("Maximize/Minimize", resizeButton );
            resizeButton.Image = ((System.Drawing.Image)(Properties.Resources.resize1));
        }

        private void resizeOut(object sender, EventArgs e)
        {

            resizeButton.Image = ((System.Drawing.Image)(Properties.Resources.resize0));
        }

        private void closeIn(object sender, EventArgs e)
        {
            toolTip.Show("Close Kids Portal",  closeButton);
            closeButton.Image = ((System.Drawing.Image)(Properties.Resources.close1));
        }

        private void closeOut(object sender, EventArgs e)
        {
            closeButton.Image = ((System.Drawing.Image)(Properties.Resources.close0));

        }

        private void resizeClick(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal){
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void closeClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void navBar_MouseClick(object sender, MouseEventArgs e)
        {
            tempoNavBar = navBar.Text;
            navBar.Text = "";
        }

        private void navBar_MouseLeave(object sender, EventArgs e)
        {
            navBar.Text = tempoNavBar;
        }

       

       

        private void search(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                if (navBar.Text.Contains("//setting"))
                {                    
                    n.Show();
                }
                else
                {
                    if (passURL(navBar.Text))
                    {
                        bro.Load(navBar.Text);
                        addHistory(navBar.Text);
                        timer1.Start();
                    }
                    tempoNavBar = navBar.Text;
                    string text = navBar.Text;
                    
                }
            }
        }


        private Boolean passURL(String text)
        {
            text = text.ToLower();
            string newText = "";
            if (!(text.Contains(".com") || text.Contains(".org") || text.Contains(".net")) || text.Contains(' '))
            {
                if (text.Contains(' '))
                {
                    string[] words = navBar.Text.Split(' ');

                    for (int x = 0; x < words.Length; x++)
                    {
                        newText += words[x] + '+';
                    }
                }


                bro.Load(searches[set] + newText.TrimEnd('+'));
                addHistory(searches[set] + newText.TrimEnd('+'));
                return false;
            }
            return true;

        }

        private void homeClick(object sender, EventArgs e)
        {
          bro.Load(homepage[set]);
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            bro.Forward();
        }

        private void backwardButton_Click(object sender, EventArgs e)
        {
            bro.Back();
        }

        public void goHomepage()
        {
            bro.Load(homepage[set]);
        }

 

        private void navBar_MouseHover(object sender, EventArgs e)
        {

            tempoNavBar = navBar.Text;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            if(bro.GetTextAsync().Result!= previous)
            {
                previous = bro.GetTextAsync().Result;
             }
               
        }

        public string getText() 
        {
            return previous;
        }

        
        
    }
}
