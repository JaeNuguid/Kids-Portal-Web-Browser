        using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using HtmlAgilityPack;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Web;

namespace Kids_Portal
{
    public partial class Form1 : Form
    {
        #region variables
        public Loading load;
        public Boolean done = false;
        Internet inter;
        public Boolean overrideHide = false;
        public ToolTip toolTip = new ToolTip();
        public String username ="jaejaejae";
        public String password = "jaejaejae";
        public Settings set;
        public Access acc;
        Locked locked;
        public adminLogin adLog;
        public String pageTitle="";
        public Plugin plugin;
        String checker = "http://www.kiddle.co/s.php?q=";
        String currentHtml = "";
        String previousHtml = "";
        String previousTitle = "";
        public List<String> tagalog;
        public List<String> english;
        public String[] settingData = { "" };
        public String[] bookmarkData = { "" };
        public String[] historyData = { "" };
        public String[] reportData = { "" };
        public Boolean timeout = false;
        public String[] timeData = { "" };
        String checker2 = "https://www.google.com/search?safe=active&q=";
        public String homepage = "https://www.google.com/search?safe=active";
        public String pageURL;
        String[] searchEngine = { "https://www.google.com/search?safe=active&q=", "https://search.yahoo.com/search?p=", " http://www.bing.com/search?q=", "http://www.kiddle.co/s.php?q=", "http://www.kidrex.org/results/?q=", "https://www.youtube.com/results?search_query=", "en.wikipedia.org/w/index.php?search=" };
        public int searchEngineIndex = 0;
        List<String> userBrowsers = new List<string>();
        //google,yahoo,bing,kiddle,kidrex,youtube,wikipedia

        public delegate void SimpleDelegate();
        String[] days = { "sun", "mon", "tue", "wed", "thu", "fri", "sat"};
        public ChromiumWebBrowser jae;
        public BlockContent bc;
        public BrowserControlWarning bcw;
        Boolean isTyping = false;

        #endregion
        Boolean masterVisible = true;

        public Form1()
        {

            InitializeComponent();
            InitializeChromium();
            InitializeCoClasses();

            //Check if your using x64 system first if return is null your on a x86 system.
            RegistryKey browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            if (browserKeys == null)
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

            // Lets get our keys!
            string[] browserNames = browserKeys.GetSubKeyNames();
            // Loop through all the subkeys for the information you want then display it on the console.
           
            for (int i = 0; i < browserNames.Length; i++)
            {
                RegistryKey browserKey = browserKeys.OpenSubKey(browserNames[i]);
                
                userBrowsers.Add((string)browserKey.GetValue(null));
            }
            userBrowsers.Add("task manager");
      
            navBar.Text = homepage;
            loadNavBar();
            

            //Loading Data
            path = Path.Combine(appDataPath + @"\KidsPortal", "setting.txt");
            if (!File.Exists(path))
            {
                
                Creation();
            }


            try
            {
                settingData = System.IO.File.ReadAllLines(path);
            }
            catch (System.Exception e)
            {

                path = Path.Combine(appDataPath + @"\KidsPortal", "setting.txt");

                String[] account = { "0", username, password, (navBar.BackColor.Name), (navBar.ForeColor.Name), set.protectionIsOn().ToString(), set.webBrowserControlIsOn().ToString(), homepage };
                path = Path.Combine(appDataPath + @"\KidsPortal", "setting.txt");
                settingData = account;
                System.IO.File.WriteAllLines(path, account);
            }
            if (settingData[0].Equals("0") || settingData == null)
            {
                Creation();
                //    Registration reg = new Registration(this, appDataPath);
                //  reg.Show();
            }
            else
            {

                path = Path.Combine(appDataPath + @"\KidsPortal", "setting.txt");

                settingData = System.IO.File.ReadAllLines(path);
                username = settingData[1];
               password = settingData[2];
                setSetting();
            }

            path = Path.Combine(appDataPath + @"\KidsPortal", "setting.txt");
            settingData = System.IO.File.ReadAllLines(path);
            

            loadData();
             starting();

            async Task starting()
            {
                load.Show();
                navBar.Enabled = false;
                await Task.Delay(3000);
                load.Hide();
                navBar.Enabled = true;
                settings.Visible = true;
            }

            timer1.Start();
            timer2.Start();

            done = true;
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings

            // Create a browser component
            jae = new ChromiumWebBrowser(homepage);
            goHomepage();
            // Add it to the form and fill it to the form window.
            tableLayoutPanel1.Controls.Add(jae);
            jae.Margin = new Padding(25, 5, 25, 25);
            jae.Dock = DockStyle.Fill;
            jae.AddressChanged += OnBrowserAddressChanged;
            jae.TitleChanged += TitleChangedEventArgs;
            jae.DownloadHandler = new DownloadHandler();
            jae.LifeSpanHandler = new BrowserLifeSpanHandler();
        
        }
        


        public void InitializeCoClasses()
        {

            adLog = new adminLogin(this);

            //warning loading
            load = new Loading();

            //warning for internet connection error
            inter = new Internet(this);

            //warning for blocked content
            bc = new BlockContent(this);

            //Warning for web browser control
            bcw = new BrowserControlWarning(this);

            //Bookmark & History
            plugin = new Plugin(this);
            //settings
            set = new Settings(this);
            
            acc = new Access(this);
            locked = new Locked(this);
        }


        #region online

        public void pushConfig(String status, String user, String pass, String color, String color2, Boolean protect, Boolean secure, String homepage, int index)
        {
            //   { "0", "jaejaejae", "jaejaejae", (navBar.BackColor.R.ToString()) + " " + (navBar.BackColor.G.ToString()) + " " + (navBar.BackColor.B.ToString()), (navBar.ForeColor.R.ToString()) + " " + (navBar.ForeColor.G.ToString()) + " " + (navBar.ForeColor.B.ToString()), set.protectionIsOn().ToString(), set.webBrowserControlIsOn().ToString(), homepage, searchEngineIndex.ToString() };
            if (username.Length > 3)
            {

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    status = status,
                    user = user,
                    pass = pass,
                    color = color,
                    color2 = color2,
                    protect = protect,
                    secure = secure,
                    homepage = homepage,
                    index = index,

                });

                var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Configs/" + user + "/.json");
                request.Method = "PATCH";
                request.ContentType = "application/json";
                var buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                var response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();


                 json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                 status = "enable"
                });

                 request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Status/" + user + "/.json");
                request.Method = "PATCH";
                request.ContentType = "application/json";
                buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

                json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    message = "jae35"
                });

                request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Messages/" + user + "/.json");
                request.Method = "PATCH";
                request.ContentType = "application/json";
                buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            }
        }

        public void pushReport(String titleX, String urlX, String dateX)
        {
            if (username.Length > 3)
            {

                string user = username;
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    title = titleX,
                    url = urlX,
                    date = dateX,

                });

                var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Reports/" + user + "/.json");
                request.Method = "POST";
                request.ContentType = "application/json";
                var buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                var response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            }
            

        }

        #endregion


        public async Task realTimeCheckAsync()
        {
            String[] title = pageTitle.Split(' ');
            await liveCheck();  
        }
        // Where words are being filtered and checked.

        public bool safeWord(List<String> toCheck)
        {
            if (done)
            {
                toCheck.Sort();

                if (english.Intersect(toCheck).Any())
                {
                    return false;
                }
                else if (tagalog.Intersect(toCheck).Any())
                {
                    return false;
                }

            }

            return true;
        }

        #region protection
 

        
        

        private async void timer1_TickAsync(object sender, EventArgs e)
        {

            if (masterVisible)
            {

                Visible = true; 

            //update history
            if (pageTitle.Length > 3)
                if (previousTitle != pageTitle)
                {
                    set.historyBox.Items.Add(DateTime.Now.ToString("d/MM/yyyy") + "\t" + DateTime.Now.ToString("hh:mm:ss tt") + "\t " + pageTitle + "\t" + navBar.Text);
                    set.updateHistory();
                    previousTitle = pageTitle;
                }


            if (set.protectionIsOn() && !isTyping)
                if (load.Visible == false)
                    if (!navBar.Text.Equals("about:blank"))
                        if (!navBar.Text.ToLower().Contains("kids-portal"))
                        {
                                await realTimeCheckAsync();
                        }

                                                                            

            //temporary
           //set.setWebControl(false);

            if (set.webBrowserControlIsOn())
            {
                Process[] processCollection = Process.GetProcesses();
                foreach (String brows in userBrowsers)
                {
                    foreach (Process p in processCollection)
                    {
                        if ((p.MainWindowTitle.ToString().ToLower().Contains(brows.ToLower())))
                        {
                            set.reportBox.Items.Add(DateTime.Now.ToString("d/MM/yyyy") + "\t" + DateTime.Now.ToString("hh:mm:ss tt") + "\t " + "Web Browser Control" + "\tTried to open " + brows.ToLower());
                            pushReport("Web Browser Control","User tried to open "+brows, DateTime.Now.ToString("d/MM/yyyy") + " " + DateTime.Now.ToString("hh:mm:ss tt"));
                            set.updateReport();

                            p.Kill();
                            navBar.Enabled = false;
                            timer1.Stop();
                            bcw.Show();

                        }
                    }
                }
            }


            isTyping = false;

            }
            else
            {
                Visible = false;

                set.setWebControl(false);
        }


        }

        public void checkTime()
        {
            Boolean block = false;
            int locks = 0;
            //   String[] time = { "00:00 AM - 11:59 PM / mon-tue-wed-thu-fri-sat-sun / Disable Kids Portal" };
            if (timeData == null || timeData.Length <= 0)
            {
                block = true;
            }
            else
                foreach (String z in timeData)
                {

                    if (z.Contains(days[(int)DateTime.Now.DayOfWeek]))
                    {

                        int fromH = 0;
                        int fromM = 0;
                        int toH = 0;
                        int toM = 0;
                        int x = 0, y = 0;
                        //from 0 & 1
                        //to 3 & 4
                        String[] time = z.Split(' ');



                        String[] from = time[0].Split(':');
                        String[] to = time[3].Split(':');

                        if (time[1].Equals("PM")) x = 12;
                        if (from[0].Equals("12")) x -= 12;
                        fromH = Convert.ToInt32(from[0]) + x;
                        fromM = Convert.ToInt32(from[1]);


                        if (time[4].Equals("PM")) y = 12;
                        if (to[0].Equals("12")) y -= 12;
                        toH = Convert.ToInt32(to[0]) + y;
                        toM = Convert.ToInt32(to[1]);


                        TimeSpan startTime = new TimeSpan(fromH, fromM, 0);
                        TimeSpan endTime = new TimeSpan(toH, toM, 0);

                        if ((DateTime.Now.TimeOfDay >= startTime &&
                            DateTime.Now.TimeOfDay <= endTime))
                        {



                            //enable
                            block = false;


                        }
                        else
                        {
                            block = true;
                            if (z.Contains("Logout"))
                            {
                                locks = 1;
                            }
                            else if (z.Contains("Shutdown"))
                            {
                                locks = 2;
                            }
                            break;
                            // disable
                            //Disable Kids Portal / Logout Compter / Shutdown Computer



                        }



                    }

                }

            if (block)
            {

                timeout = true;
                if (Visible) Visible = false;

                masterVisible = false;
                
                locked.Show();

                if (locks == 1)
                {
                    LockWorkStation();
                }
                else if (locks == 2)
                {
                    Process.Start("shutdown", "/s /t 30");
                }

            }
            else
            {

                masterVisible = true;

                timeout = false;
                locked.Hide();
                if (!Visible) Visible = true;
                return;
            }
        }

        
   
        #endregion

        #region pre-functions

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() => navBar.Text = e.Address
            
            );
                liveCheck();
            pageURL = navBar.Text;

        }

     
        private void TitleChangedEventArgs(object sender, TitleChangedEventArgs e)
        {

            this.InvokeOnUiThreadIfRequired(() =>
          pageTitle = e.Title
                   );
            try
            {
               
            }
            catch(Exception ee)
            {
                Console.WriteLine("Error: Current HTML " + ee.ToString());
            }

        }
        
        public async Task liveCheck()
        {

            try
            {
                List<String> XTML = await getHeadandBody(navBar.Text);
                
                
                if (!safeWord(XTML))
                {
                    warn();
                    return;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                //inter.Show();
            }

        }

        public async void loadUrlAsync(String url)
        {
            
           jae.Visible = false;
          
            try
            {
                List<String> XTML = await getHeadandBody(url);

                if (!safeWord(XTML) && set.protectionIsOn())
                {
                     warn();
                    return;
                }
                

                jae.Load(url);

                jae.Visible = true;
            }catch(Exception e)
            {
                Console.WriteLine("Error: "+e);
                //inter.Show();
            }
            

        }
        
        public async Task<List<String>> getHeadandBody(String url)
        {
            String meta = "";
            List<String> skeleton = new List<String>();
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDocX = new HtmlAgilityPack.HtmlDocument();
            try
            {
                if (url.ToLower().Contains("facebook.com"))
                {
                    var html = "";
                    
              return await jae.GetSourceAsync().ContinueWith(taskHtml =>
                     {

                         List<String> skel = new List<String>();
                         html = taskHtml.Result;
                         htmlDocX.LoadHtml(html);
                         var spanNode = htmlDocX.DocumentNode.SelectNodes("//span"); // texts
                        var spawnNode = htmlDocX.DocumentNode.SelectNodes("//p"); // texts

                        if (spanNode != null)
                             foreach (var n in spanNode)
                             {

                                 if (n != null && n.InnerText.Length > 2)
                                 {
                                     String words = n.InnerText;
                                     words = Regex.Replace(words, "[^a-zA-Z0-9_]+", " ");
                                     words = Regex.Replace(words, @"\s+", " ");

                                     String[] wordSets = words.Split(' ');
                                     foreach (String x in wordSets)
                                     {
                                         if (x.Length > 2)
                                         {

                                             
                                             skel.Add(x.ToLower()); // added this.
                                        }
                                     }
                                 }
                             }

                         if (spawnNode != null)
                             foreach (var n in spawnNode)
                             {
                                 if (n != null && n.InnerText.Length > 2)
                                 {
                                     String words = n.InnerText;
                                     words = Regex.Replace(words, "[^a-zA-Z0-9_]+", " ");
                                     words = Regex.Replace(words, @"\s+", " ");

                                     String[] wordSets = words.Split(' ');
                                     foreach (String x in wordSets)
                                     {
                                         if (x.Length > 2)
                                         {
                                             skel.Add(x.ToLower()); // added this.
                                        }
                                     }
                                 }
                             }


                         return skel;
                     });
                    
                    
                }else if (url.ToLower().Contains("youtube.com"))
                {

                    var html = "";

                    return await jae.GetSourceAsync().ContinueWith(taskHtml =>
                    {

                        List<String> skel = new List<String>();
                        html = taskHtml.Result;
                        htmlDocX.LoadHtml(html);
                        var aNode = htmlDocX.DocumentNode.SelectNodes("//a"); // texts
                        var spanNode = htmlDocX.DocumentNode.SelectNodes("//span"); // texts
                        var spawnNode = htmlDocX.DocumentNode.SelectNodes("//yt-formatted-string"); // texts
                        var titleNode = htmlDocX.DocumentNode.SelectSingleNode("//head/title");

                        String[] title = titleNode.InnerText.Split(' ');
                        if(titleNode!= null)
                        foreach (String x in title)
                        {
                            if (x.Length > 2)
                                skeleton.Add(x.ToLower()); // added title
                        }

                        if (aNode != null)
                            foreach (var n in aNode)
                            {

                                if (n != null && n.InnerText.Length > 2)
                                {
                                    String words = n.InnerText;
                                    words = Regex.Replace(words, "[^a-zA-Z0-9_]+", " ");
                                    words = Regex.Replace(words, @"\s+", " ");

                                    String[] wordSets = words.Split(' ');
                                    foreach (String x in wordSets)
                                    {
                                        if (x.Length > 2)
                                        {

                                            
                                            skel.Add(x.ToLower()); // added this.
                                        }
                                    }
                                }
                            }

                        if (spanNode != null)
                            foreach (var n in spanNode)
                            {

                                if (n != null && n.InnerText.Length > 2)
                                {
                                    String words = n.InnerText;
                                    words = Regex.Replace(words, "[^a-zA-Z0-9_]+", " ");
                                    words = Regex.Replace(words, @"\s+", " ");

                                    String[] wordSets = words.Split(' ');
                                    foreach (String x in wordSets)
                                    {
                                        if (x.Length > 2)
                                        {

                                            
                                            skel.Add(x.ToLower()); // added this.
                                        }
                                    }
                                }
                            }

                        if (spawnNode != null)
                            foreach (var n in spawnNode)
                            {
                                if (n != null && n.InnerText.Length > 2)
                                {
                                    String words = n.InnerText;
                                    words = Regex.Replace(words, "[^a-zA-Z0-9_]+", " ");
                                    words = Regex.Replace(words, @"\s+", " ");

                                    String[] wordSets = words.Split(' ');
                                    foreach (String x in wordSets)
                                    {
                                        if (x.Length > 2)
                                        {
                                            skel.Add(x.ToLower()); // added this.
                                        }
                                    }
                                }
                            }


                        return skel;
                    });


                }
                else
                {

                    var htmlDoc = web.Load(url);

                    var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title"); // title
                    var node2 = htmlDoc.DocumentNode.SelectNodes("//meta/@content"); // meta
                    var node3 = htmlDoc.DocumentNode.SelectSingleNode("//body"); // body content 

                    String[] title = node.InnerHtml.Split(' ');
                    foreach (String x in title)
                    {
                        if (x.Length > 2)
                            skeleton.Add(x.ToLower()); // added title
                    }

                    var metaTags = htmlDoc.DocumentNode.SelectNodes("//meta");
                    if (metaTags != null)
                    {

                        foreach (var tag in metaTags)
                        {
                            if (tag.Attributes["name"] != null && tag.Attributes["content"] != null)
                            {
                                String tagName = tag.Attributes["name"].Value.ToLower();
                                String tagContent = tag.Attributes["content"].Value.ToLower();
                                if (tagName.Equals("description") || tagName.Equals("keywords"))
                                {
                                    meta += tagContent;
                                }
                            }
                        }

                        meta = Regex.Replace(meta, "[^a-zA-Z0-9_]+", " ");
                        meta = Regex.Replace(meta, @"\s+", " ");

                        String[] metas = meta.Split(' ');
                        foreach (String x in metas)
                        {
                            if (x.Length > 2)
                                skeleton.Add(x.ToLower()); // added meta contents
                        }
                    }

                    String restOfHtml = node3.InnerText;
                    restOfHtml = Regex.Replace(restOfHtml, "[^a-zA-Z0-9_]+", " ");
                    restOfHtml = Regex.Replace(restOfHtml, @"\s+", " ");

                    String[] restOfHtmlArr = restOfHtml.Split(' ');
                    foreach (String x in restOfHtmlArr)
                    {
                        if (x.Length > 2)
                            skeleton.Add(x.ToLower()); // added body contents
                    }
                    skeleton.Sort();


                    List<String> uniqueValues = skeleton.Distinct().ToList();
                    return uniqueValues;
                }
            }catch(Exception e)
            {
            }

            return skeleton;
        }


       

        public void loadNavBar()
        {

            String URL = Regex.Replace(navBar.Text, @"\s+", " ");
            
            if (URL.Contains(" "))
            { //word
                URL = URL.Replace(" ", "+");
                loadUrlAsync(searchEngine[searchEngineIndex] + URL);

            }
            else if (!URL.Contains("."))
            { //single word
                loadUrlAsync(searchEngine[searchEngineIndex] + URL);
            }
            else
            {
                if (URL.ToLower().StartsWith("http://") || URL.ToLower().StartsWith("https://"))
                    loadUrlAsync(URL);
                else
                    loadUrlAsync("http://"+URL);
                
             
               
            }
            
                    


        }

        // Declaration

        delegate void disableFatDel();

        public void disableFat()
        {
            pushReport(pageTitle, navBar.Text, DateTime.Now.ToString("d/MM/yyyy") + " " + DateTime.Now.ToString("hh:mm:ss tt"));
            // MessageBox.Show("Inappropriate Website", "Kids Portal");
            set.reportBox.Items.Add(DateTime.Now.ToString("d/MM/yyyy") + "\t" + DateTime.Now.ToString("hh:mm:ss tt") + "\t " + pageTitle + "\t" + navBar.Text);
            set.updateReport();
            bc.Show();
            navBar.Enabled = false;
            previousTitle = pageTitle;
            currentHtml = "";
            timer1.Stop();
            jae.Load("about:blank");
     
            load.Hide();
            navBar.Text = homepage;
            goHomepage();
            jae.Visible = true;
        }

        public void warn() { 

  
            if (InvokeRequired)
            {
                Invoke(new disableFatDel(disableFat));
            }
            else
            {
                pushReport(pageTitle, navBar.Text, DateTime.Now.ToString("d/MM/yyyy") + " " + DateTime.Now.ToString("hh:mm:ss tt"));
                // MessageBox.Show("Inappropriate Website", "Kids Portal");
                set.reportBox.Items.Add(DateTime.Now.ToString("d/MM/yyyy") + "\t" + DateTime.Now.ToString("hh:mm:ss tt") + "\t " + pageTitle + "\t" + navBar.Text);
                set.updateReport();
                bc.Show();
                navBar.Enabled = false;
                previousTitle = pageTitle;
                currentHtml = "";
                timer1.Stop();

                jae.Load("about:blank");
                load.Hide();
                navBar.Text = homepage;
                goHomepage();
                jae.Visible = true;
            }
           

        }
        public void goHomepage()
        {
            jae.Load(homepage);
        }
        #endregion


        #region Tooltips

        private void navBar_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Enter a search term or Website URL", navBar);
        }

        private void backHover(object sender, EventArgs e)
        {
            toolTip.Show("Previous", back);
        }

        private void homeHover(object sender, EventArgs e)
        {
            toolTip.Show("Go to Homepage", home);
        }

        private void forwardHover(object sender, EventArgs e)
        {
            toolTip.Show("Forward", forward);
        }

        private void goHover(object sender, EventArgs e)
        {
            toolTip.Show("Search / Refresh Page", go);
        }

        private void historyHover(object sender, EventArgs e)
        {
            toolTip.Show("History Panel", history);
        }

        private void bookmarkHover(object sender, EventArgs e)
        {
            toolTip.Show("Bookmark Panel", bookmark);
        }

        private void settingHover(object sender, EventArgs e)
        {
            toolTip.Show("Settings Panel", settings);
        }

        private void resizeHover(object sender, EventArgs e)
        {
            toolTip.Show("Minimize Window", resize);
        }

        private void closeHover(object sender, EventArgs e)
        {
            toolTip.Show("Close Kids Portal", close);
        }

        #endregion tooltips


        #region browserInterface
        private void backClick(object sender, MouseEventArgs e)
        {
            jae.Back();
        }

        private void homeClick(object sender, MouseEventArgs e)
        {
            goHomepage();
        }

        private void forwardClick(object sender, MouseEventArgs e)
        {
            jae.Forward();
        }

        private void goClickAsync(object sender, MouseEventArgs e)
        {
            isTyping = false;
            loadNavBar();
        }

        private void enterDownAsync(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                isTyping = false;
                loadNavBar();
            }

        }

        private void historyClick(object sender, MouseEventArgs e)
        {
            jae.Stop();
            navBar.Enabled = false;
            plugin.getHistory();
            plugin.Show();

            plugin.tabControl1.SelectedIndex = 0;
        }

        private void bookmarkClick(object sender, MouseEventArgs e)
        {
            plugin.Show();
            plugin.tabControl1.SelectedIndex = 1;
            jae.Stop();
            navBar.Enabled = false;

        }

        private void settingClick(object sender, MouseEventArgs e)
        {
            jae.Stop();
            navBar.Enabled = false;

           acc.show(0);
        }

        private void resizeClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        



        #endregion browserInterface


        [DllImport("user32")]
        public static extern void LockWorkStation();

        

        String appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        String path;

        public void checkMessage()
        {
           
                String URL = "https://kids-portal.firebaseio.com/Messages/" + username + ".json";
                HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);
                request1.ContentType = "application/json: charset=utf-8";
                HttpWebResponse response1 = request1.GetResponse() as HttpWebResponse;
                using (Stream responsestream = response1.GetResponseStream())
                {
                    StreamReader Read = new StreamReader(responsestream, Encoding.UTF8);
                    String here = Read.ReadToEnd();
                here = here.Trim('"');
                here = here.Replace("{", "");
                here = here.Replace("}", "");
                String[] here2 = here.Split(':');
                String msg = here2[1].Trim('"'); 
                //  message="";

                if (!here.Contains("jae35")){
                    
                        clearMessage();
                        MessageBox.Show("Your parent or guardian sent you a message:\n\n" +
                            "\"" + msg + "\"", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       
                }



                }
        }

        public void pullConfig()
        {

            String URL = "https://kids-portal.firebaseio.com/Configs/" + username + ".json";
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);
            request1.ContentType = "application/json: charset=utf-8";
            HttpWebResponse response1 = request1.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response1.GetResponseStream())
            {
                StreamReader Read = new StreamReader(responsestream, Encoding.UTF8);
                String here = Read.ReadToEnd();
                // {"color":"0 0 0","color2":"0 0 0","homepage":"https://www.google.com/search?safe=active","index":5,"pass":"testing","protect":true,"secure":true,"status":"1","user":"testing"}
                here = here.Trim(new char[] {'{','}'});
                here = here.Replace("\"","");
                String[] setx = here.Split(',');

                String color = setx[0].Split(':')[1];
                String color2 =  setx[1].Split(':')[1];
                String homepagex = setx[2].Substring(9, setx[2].Length - 9);
                String index =  setx[3].Split(':')[1];
                String pass =  setx[4].Split(':')[1];
                String protect =  setx[5].Split(':')[1];
                String secure =  setx[6].Split(':')[1];
                String status =  setx[7].Split(':')[1];
                String user =  setx[8].Split(':')[1];



                String[] back = (color).Split(' ');
                String[] font = (color2).Split(' ');

                Color a = Color.FromArgb(Convert.ToInt32(back[0]), Convert.ToInt32(back[1]), Convert.ToInt32(back[2]));
                Color b = Color.FromArgb(Convert.ToInt32(font[0]), Convert.ToInt32(font[1]), Convert.ToInt32(font[2]));

                navBar.BackColor = a;
                tableLayoutPanel1.BackColor = a;    
                navBar.ForeColor = b;
                

                Boolean se = true, se2 = true;
                if (protect.Equals("false"))
                {
                    se = false;

                    set.setProtection(se);
                    set.protectionStatus = false;
                }
                else
                {
                    set.setProtection(se);
                    set.protectionStatus = true;
                }
                

                if (secure.Equals("false"))
                {
                    se2 = false;
                    set.setWebControl(se2);
                    set.webBrowserControlStatus = false;
                }
                else
                {

                    set.webBrowserControlStatus = true;
                    set.setWebControl(se2);
                }
                
                homepage = homepagex;
                searchEngineIndex = Convert.ToInt32(index);     

                clearChange();

             
            }

        }
        public void checkConfig()
        {

            String URL = "https://kids-portal.firebaseio.com/Accounts/" + username + ".json";
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);
            request1.ContentType = "application/json: charset=utf-8";
            HttpWebResponse response1 = request1.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response1.GetResponseStream())
            {
                StreamReader Read = new StreamReader(responsestream, Encoding.UTF8);
                String here = Read.ReadToEnd();

                if (here.Contains("true"))
                {
                   pullConfig();
                    clearChange();
                }
                

            }
        }

        public void clearChange()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                pass = password,
                changed = false,
            });

            var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Accounts/" + username + ".json");
            request.Method = "PATCH";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

        }
        public void clearMessage()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                message = "jae35",
            });

            var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Messages/" + username + ".json");
            request.Method = "PATCH";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
            
        }

        public void loadData()
        {

            try
            {

                path = Path.Combine(appDataPath + @"\KidsPortal", "english.txt");
                english = System.IO.File.ReadAllLines(path).ToList();
                english.Sort();


                path = Path.Combine(appDataPath + @"\KidsPortal", "tagalog.txt");
                tagalog = System.IO.File.ReadAllLines(path).ToList();
                tagalog.Sort();

                
            }
            catch (System.Exception e)
            {
                Creation();
            }
         
        }
        

        public void updateEnglish()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "english.txt");
            System.IO.File.WriteAllLines(path, english);

        }

        public void updateTagalog()
        {
            path = Path.Combine(appDataPath + @"\KidsPortal", "tagalog.txt");
            System.IO.File.WriteAllLines(path, tagalog);

        }
        

        public  void setWords(List<String> e, List<String> t)
        {
            english = e;
            tagalog = t;
        }

   
        public void setSetting()
        {
            String[] back = (settingData[3]).Split(' ');
            String[] font = (settingData[4]).Split(' ');
         
            Color a = Color.FromArgb(Convert.ToInt32(back[0]), Convert.ToInt32(back[1]), Convert.ToInt32(back[2]));
            Color b= Color.FromArgb(Convert.ToInt32(font[0]), Convert.ToInt32(font[1]), Convert.ToInt32(font[2]));

            navBar.BackColor = a;
            tableLayoutPanel1.BackColor = a;
            navBar.ForeColor = b;

            Boolean se = true, se2 = true;
            if (settingData[5].Equals(false)) se = false; 
            set.setProtection(se);

            if (settingData[6].Equals(false)) se2 = false;
            set.setWebControl(se2);

            homepage = settingData[7];
            searchEngineIndex = Convert.ToInt32(settingData[8]);
            set.updateSetting();
        }

    
      
        private void upkey(object sender, KeyEventArgs e)
        {
            isTyping = true;
        }

        private void navBar_MouseMove(object sender, MouseEventArgs e)
        {
            isTyping = false;
        }

   
        public void Creation()
        {
            Visible = false;
           

            System.IO.Directory.CreateDirectory(appDataPath + @"\KidsPortal");
            string[] nul = { "" };
            //Words
            Words wos = new Words();
            english = wos.getEnglish();
            tagalog = wos.getTagalog();
            path = Path.Combine(appDataPath + @"\KidsPortal", "english.txt");
            System.IO.File.WriteAllLines(path, english);
            path = Path.Combine(appDataPath + @"\KidsPortal", "tagalog.txt");
            System.IO.File.WriteAllLines(path, tagalog);


            //History
            path = Path.Combine(appDataPath + @"\KidsPortal", "history.txt");
            System.IO.File.WriteAllLines(path, nul);

            path = Path.Combine(appDataPath + @"\KidsPortal", "report.txt");
            System.IO.File.WriteAllLines(path, nul);


            //Bookmark
            path = Path.Combine(appDataPath + @"\KidsPortal", "bookmark.txt");
            System.IO.File.WriteAllLines(path, nul);



            //settings
            String[] account = { "0", username, password, (navBar.BackColor.R.ToString()) + " " + (navBar.BackColor.G.ToString()) + " " + (navBar.BackColor.B.ToString()), (navBar.ForeColor.R.ToString()) + " " + (navBar.ForeColor.G.ToString()) + " " + (navBar.ForeColor.B.ToString()), set.protectionIsOn().ToString(), set.webBrowserControlIsOn().ToString(), homepage, searchEngineIndex.ToString() };
            settingData = account;
            pushConfig("0", username, password, (navBar.BackColor.R.ToString()) + " " + (navBar.BackColor.G.ToString()) + " " + (navBar.BackColor.B.ToString()), (navBar.ForeColor.R.ToString()) + " " + (navBar.ForeColor.G.ToString()) + " " + (navBar.ForeColor.B.ToString()), set.protectionIsOn(), set.webBrowserControlIsOn(), homepage, searchEngineIndex);
            path = Path.Combine(appDataPath + @"\KidsPortal", "setting.txt");
            System.IO.File.WriteAllLines(path, account);


            String[] time = { "12:00 AM - 11:59 PM / mon-tue-wed-thu-fri-sat-sun / Disable Kids Portal" };
            //Time Management
            path = Path.Combine(appDataPath + @"\KidsPortal", "time.txt");
            System.IO.File.WriteAllLines(path, time);

            adLog.Show();
            navBar.Enabled = false;

            Visible = true;
        }

        public void checkStatus()
        {
            String URL = "https://kids-portal.firebaseio.com/Status/" + username + ".json";
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);
            request1.ContentType = "application/json: charset=utf-8";
            HttpWebResponse response1 = request1.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response1.GetResponseStream())
            {
                StreamReader Read = new StreamReader(responsestream, Encoding.UTF8);
                String here = Read.ReadToEnd();
                here = here.Trim('"');
                here = here.Replace("{", "");
                here = here.Replace("}", "");
                String[] here2 = here.Split(':');
                String msg = here2[1].Trim('"');
                //  message="";

                if (msg.Equals("enable"))
                {
                  
                    enable();

                }
                else if (msg.Equals("disable"))
                {  
                    disable();
                }
                else if (msg.Equals("logout"))
                {
                    logout();
                }
                else if (msg.Equals("shutdown"))
                {
                    shutdown();
                }
                else if (msg.Equals("softReset"))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                    {
                        status = "enable",

                    });

                    var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Status/" + username + "/.json");
                    request.Method = "PATCH";
                    request.ContentType = "application/json";
                    var buffer = Encoding.UTF8.GetBytes(json);
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                    var response = request.GetResponse();
                    json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                    set.hardReset();
                }
                else if (msg.Equals("hardReset"))
                {
                    settings.Hide();
                    Creation();
                }



            }

        }
        public void logout()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                status = "enable",
               
            });

            var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Status/" + username + "/.json");
            request.Method = "PATCH";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
            LockWorkStation();
        }

        public void shutdown()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                status = "enable",

            });

            var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Status/" + username + "/.json");
            request.Method = "PATCH";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
            Process.Start("shutdown", "/s /t 30");
         
        }

        public void disable()
        {
            masterVisible = false;
            Hide();
            set.setWebControl(false);
        }

        public void enable()
        {
            masterVisible = true;
            Visible = true;
        }

        public void hardReset()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                status = "enable",

            });

            var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Status/" + username + "/.json");
            request.Method = "PATCH";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            set.updateSetting();
            //Time Management
            String[] timex = { "12:00 AM - 11:59 PM / mon-tue-wed-thu-fri-sat-sun / Disable Kids Portal" };
            path = Path.Combine(appDataPath + @"\KidsPortal", "time.txt");
            System.IO.File.WriteAllLines(path, timex);

        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!username.Equals("jaejaejae"))
            {
                if (masterVisible)
                {
                    checkConfig();
                    checkTime();
                }
                else
                {
                    Hide();
                    set.setWebControl(false);
                    
                }

                checkMessage();
                checkStatus();
            }
        }

        private void closeClick(object sender, MouseEventArgs e)
        {

            //nothing yet
            this.WindowState = FormWindowState.Minimized;

        }

    }
}

