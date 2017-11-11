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
using System.Reflection;
using System.Speech.Recognition;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;

namespace newKidsPortal
{
    public partial class KidsPortal : Form
    {
        String username = "";
        public string previous = "testing";
        private String tempoNavBar = "";
        public ChromiumWebBrowser bro;
        string datass = Properties.Resources.kpweb;
        ToolTip toolTip = new ToolTip();
        public Setting sett;
        public Login n;
        string[] searches = { "https://www.google.com/search?q=", "http://www.kiddle.co/s.php?q=", "http://www.kidrex.org/results/?q=", "https://www.youtube.com/results?search_query=" };
        public int set = 2;
        voice vc;
        public string[] config;
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string path;
        Bookmark bk;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();


        public void pushData()
        {
            if (username.Length > 3)
             {
               username = config[1];
                string user = username.Substring(0, username.LastIndexOf("@") );
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    title = titles,
                    url = urlX,
                    date = DateTime.Now.ToString("yyyy-MM-d") + " " + DateTime.Now.ToString("hh:mm:ss tt"),

                });

                var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Users/"+user+"/.json");
                request.Method = "POST";
                request.ContentType = "application/json";
                var buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request .GetRequestStream().Write(buffer, 0, buffer.Length);
                var response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            }
        }


        public KidsPortal()
        {
         InitializeComponent();
         
         System.IO.Directory.CreateDirectory(appDataPath +@"\KidsPortal");
            KidsPortalEngine();
            vc = new voice(this);
            // Start the browser after initialize global component
            InitializeChromium();
            

           path = Path.Combine(appDataPath + @"\KidsPortal", "config.txt");
            if (!File.Exists(path))
            {
                string[] nul = { };
                string[] xx = { "0","username", "password" };
                System.IO.File.WriteAllLines(path,xx);

                reCreate();
               
            }

            path = Path.Combine(appDataPath + @"\KidsPortal", "config.txt");

            try { 
            config = System.IO.File.ReadAllLines(path);
            }
            catch (System.Exception e)
            {
                path = Path.Combine(appDataPath + @"\KidsPortal", "config.txt");
                System.IO.File.WriteAllLines(path, config);
            }
            if (config[0] == "0")
            {
                this.Hide();
                reCreate();
                Registration reg = new Registration(this, appDataPath);
                reg.Show();
            }
            path = Path.Combine(appDataPath + @"\KidsPortal", "config.txt");

            config = System.IO.File.ReadAllLines(path);
            username = config[1];
            bk = new Bookmark(this, appDataPath);
            sett = new Setting(this, appDataPath);
            n = new Login(this, sett, appDataPath);

            onVoice(false);
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => navBar.Text = args.Address
            );  
            urlX = navBar.Text;
        }

        public void KidsPortalEngine()
        {
            String[] voices = {"open bookmark","close bookmark","go back","go forward", "how are you", "Who are you", "what are you made of","where are you","how old are you",
"close browser", "exit browser", "minimize browser", "hide browser", "logout computer", "shutdown computer", "open notepad", "open calculator", "open explorer", "open folder", "what is the time now", "what is the day today", "hi computer", "hello computer", "what is kids portal", "go to kids portal", "increase volume",
            "decrease volume", "mute volume","go to google", "go to facebook","go to youtube", "go to homepage","go to twitter", "go to wikipedia","go to yahoo", "go to gmail","go to hotmail", "I want to search images","I want to search videos", "I want to search pictures","I want to play games", "search for games","search for pictures", "search for images","I want to learn something", "go to messenger","go to instagram", "go to netflix",
            "go to linked in","I want to watch videos","I want to watch movies","maximize browser", "go to drop box","go to the developer","open setting", "open voice command","close voice command"};
            Choices commands = new Choices();
            commands.Add(voices);
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();

            
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;

        }
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
           IntPtr wParam, IntPtr lParam);

        private void Mute()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        private void VolDown()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        private void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }

        [DllImport("user32")]
        public static extern void LockWorkStation();

        public void onVoice(bool on)
        {
            if (on)
            {
                recEngine.RecognizeAsync(RecognizeMode.Multiple);

            }
            else
            {
                recEngine.RecognizeAsyncStop();
            }
        }
        
        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "open bookmark":
                    bk.Show();
                    break;
                case "close bookmark":
                    bk.Hide();
                    break;
                case "go back":
                    bro.Forward();
                    break;

                case "go forward":
                    bro.Back();
                    break;

                case "close browser":
                    Hide();
                    break;


                case "exit browser":
                    Hide();
                    break;


                case "minimize browser":

                    WindowState = FormWindowState.Minimized;
                    break;

                case "maximize browser":

                    WindowState = FormWindowState.Maximized;

                    break;

                case "hide browser":
                   
                        WindowState = FormWindowState.Minimized;
                    
                    break;


                case "logout computer":
                  LockWorkStation();
                    break;


                case "shutdown computer":
                    Process.Start("shutdown", "/s /t 0");
                    break;


                case "open notepad":
                    Process.Start("notepad.exe");
                    break;


                case "open calculator":
                    Process.Start("calc.exe");
                    break;


                case "open explorer":
                    Process.Start("explorer.exe");
                    break;


                case "open folder":
                    Process.Start("explorer.exe");
                    break;


                case "what is the time now":
                    bro.Load("https://time.is");
                    break;


                case "what is the day today":
                    bro.Load("https://time.is");
                    break;


                case "hi computer":
                    MessageBox.Show("Hi there!", "Kids Portal - Voice Command");

                    break;


                case "hello computer":
                    MessageBox.Show("Hello there!", "Kids Portal - Voice Command");

                    break;
                
                case "how are you":
                    MessageBox.Show("I'm good, how about you?", "Kids Portal - Voice Command");

                    break;



                case "Who are you":
                    MessageBox.Show("I am the guardian of Kids Portal!", "Kids Portal - Voice Command");

                    break;


                case "how old are you":
                    MessageBox.Show("Probably, your age times infinity", "Kids Portal - Voice Command");

                    break;

                case "where are you":
                    MessageBox.Show("In front of you!", "Kids Portal - Voice Command");

                    break;

                  
                case "what are you made of":
                    MessageBox.Show("A whole bunch of 0s and 1s.", "Kids Portal - Voice Command");

                    break;





                case "what is kids portal":
                    bro.Load("https://jaenuguid.github.io/Kids-Portal-Web-Browser/");
                    break;


                case "go to kids portal":
                    bro.Load("https://jaenuguid.github.io/Kids-Portal-Web-Browser/");
                    break;


                case "increase volume":
                    VolUp();
                    break;


                case "decrease volume":
                    VolDown();
                    break;


                case "mute volume":
                    Mute();
                    break;


                case "go to google":
                    bro.Load("http://www.google.com");
                    break;


                case "go to facebook":
                    bro.Load("https://www.facebook.com");
                    break;


                case "go to youtube":
                    bro.Load("https://www.youtube.com");
                    break;


                case "go to homepage":
                    goHomepage();
                    break;


                case "go to twitter":
                    bro.Load("https://www.wikipedia.org");
                    break;


                case "go to wikipedia":
                    bro.Load("https://www.wikipedia.org");
                    break;


                case "go to yahoo":
                    bro.Load("http://yahoo.com");
                    break;


                case "go to gmail":
                    bro.Load("https://mail.google.com/mail/");
                    break;


                case "go to hotmail":
                    bro.Load("http://hotmail.com");
                    break;


                case "I want to search images":
                    bro.Load("https://images.google.com");
                    break;


                case "I want to search videos":
                    bro.Load("https://www.youtube.com");
                    break;


                case "I want to watch videos":
                    bro.Load("https://www.youtube.com");
                    break;


                case "I want to watch movies":
                    bro.Load("https://www.youtube.com");
                    break;



                case "I want to search pictures":
                    bro.Load("https://images.google.com");
                    break;


                case "I want to play games":
                    bro.Load("http://www.y8.com");
                    break;


                case "search for games":
                    bro.Load("http://www.wordgames.com/");
                    break;


                case "search for pictures":
                    bro.Load("https://images.google.com");
                    break;


                case "search for images":
                    bro.Load("https://images.google.com");
                    break;


                case "I want to learn something":
                    bro.Load("https://zidbits.com");
                    break;


                case "go to messenger":
                    bro.Load("https://www.messenger.com");
                    break;


                case "go to instagram":
                    bro.Load("https://www.instagram.com");
                    break;


                case "go to netflix":
                    bro.Load("https://www.netflix.com/");
                    break;


                case "go to linked in":
                    bro.Load("https://www.linkedin.com");
                    break;


                case "go to drop box":
                    bro.Load("https://www.dropbox.com");
                    break;


                case "go to the developer":
                     bro.Load("https://www.linkedin.com/in/jaenuguid/");
                    break;


                case "open setting":
                    n.Show();
                    break;


                case "open voice command":
                    vc.Show();
                    break;

                case "close voice command":
                    vc.Hide();
                    break;

                default:
                    break;
            }
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
            path = Path.Combine(appDataPath + @"\KidsPortal", "report.txt");
            System.IO.File.WriteAllLines(path, nul);
            path = Path.Combine(appDataPath + @"\KidsPortal", "bookmark.txt");
            System.IO.File.WriteAllLines(path, nul);

            String[] nu = { "00:00 to 23:59 every Monday-Tuesday-Wednesday-Thursday-Friday-Saturday-Sunday" };
            
            path = Path.Combine(appDataPath + @"\KidsPortal", "times.txt");
            System.IO.File.WriteAllLines(path, nu);
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
           bro = new ChromiumWebBrowser("https://jaenuguid.github.io/Kids-Portal-Web-Browser/");
            goHomepage();
            // Add it to the form and fill it to the form window.
            panel.Controls.Add(bro);
           bro.Margin = new Padding(25,5,25,25);
           bro.Dock = DockStyle.Fill;
            bro.AddressChanged += OnBrowserAddressChanged;
            bro.TitleChanged += TitleChangedEventArgs;
        }
        String titles = "";
        private void TitleChangedEventArgs(object sender, TitleChangedEventArgs args)
        {
            titles = args.Title;
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
            // Application.Exit();
            Hide();
        }
        
        private void navBar_MouseClick(object sender, MouseEventArgs e)
        {
            navBar.Focus();
            navBar.SelectAll();
        }

        private void navBar_MouseLeave(object sender, EventArgs e)
        {
        //    navBar.Text = tempoNavBar;
        }

       

       

        private void search(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                if (navBar.Text.Contains("//setting"))
                {
                    navBar.Text = tempoNavBar;
                    n.Show();
                }
                else if (navBar.Text.Contains("kidsportal.com"))
                {
                    goHomepage();
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

              
                newText = text;
                if (text.Contains(" "))
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
            goHomepage();
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
            bro.Load("about:blank");
            bro.LoadHtml(datass,"http://kidsportal.com");
          //  bro.Load(homepage[set]); 

        }

      
        private void navBar_MouseHover(object sender, EventArgs e)
        {

            tempoNavBar = navBar.Text;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {


            if((bro.GetTextAsync().Result!= previous))
            {
                previous = bro.GetTextAsync().Result;
             }
               
        }

        public string getText() 
        {
            return previous;
        }

        private void bookButton_Click(object sender, EventArgs e)
        {
            bk.Show();
            bk.setList();
        }

        private void playIn(object sender, EventArgs e)
        {
            play.Image = ((System.Drawing.Image)(Properties.Resources.go1));

        }

        private void playOut(object sender, EventArgs e)
        {

            play.Image = ((System.Drawing.Image)(Properties.Resources.go0));
        }

        private void playClick(object sender, MouseEventArgs e)
        {
            
                if (navBar.Text.Contains("//setting"))
                {
                    n.Show();
                }else if (navBar.Text.Contains("kidsportal.com"))
             {
                goHomepage();
               }else
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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void show(object sender, EventArgs e)
        {
            Show();
        }

        private void show2(object sender, EventArgs e)
        {
            Show();
        }

        private void voiceC(object sender, EventArgs e)
        {
            vc.Show();
        }
    }
}
