using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kids_Portal
{
    public partial class adminLogin : Form
    {

        bool register = true;
        Form1 head;
        public adminLogin(Form1 head)
        {
            InitializeComponent();
            this.head = head;
        }

        private void adminLogin_Load(object sender, EventArgs e)
        {

        }

        private void link_Click(object sender, EventArgs e)
        {

            if (register)
            {

                userBox.Text = "";
                passBox.Text = "";
                pass2Box.Text = "";
                register = false;
                btn.Text = "LOGIN";
                pass2Box.Visible = false;
                pass2Line.Visible = false;
                pass2Lab.Visible = false;
              pass2Lab.Text = "";
                link.Text = "Not yet Registered? Register here.";
            }
            else
            {

                userBox.Text = "";
                passBox.Text = "";
                pass2Box.Text = "";
                register = true;
                btn.Text = "REGISTER";
               link.Text = "Already Registered? Login here.";
                pass2Lab.Text = "Repeat Password";
                pass2Box.Visible = true;
                pass2Lab.Visible = true;
                pass2Line.Visible = true;
            }
        }

        public void registerOnline(String user, String pass)
        {


            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                pass = pass,
                changed = false,
                });

           var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Accounts/" + user + ".json");
            request.Method = "PATCH";
                request.ContentType = "application/json";
                var buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                var response = request.GetResponse();
           
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            messageEvent(user);
        }

        public void messageEvent(String user)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                message = "jae35",
             
            });

            var request = WebRequest.CreateHttp("https://kids-portal.firebaseio.com/Messages/" + user + ".json");
            request.Method = "PATCH";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();

            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
        }

        
        public bool doesExist(String user)
        {
            String URL = "https://kids-portal.firebaseio.com/Accounts/" + user + ".json";
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);
            request1.ContentType = "application/json: charset=utf-8";
            HttpWebResponse response1 = request1.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response1.GetResponseStream())
            {
                StreamReader Read = new StreamReader(responsestream, Encoding.UTF8);
                String here = Read.ReadToEnd();
                
                    if (Read.ReadToEnd() ==null || here.Length <=4)
                        return false;

                    return true;
                
            }

            
        }

        public bool isPassCorrect(String user, String pass)
        {

            String URL = "https://kids-portal.firebaseio.com/Accounts/" + user + ".json";
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);
            request1.ContentType = "application/json: charset=utf-8";
            HttpWebResponse response1 = request1.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response1.GetResponseStream())
            {
                StreamReader Read = new StreamReader(responsestream, Encoding.UTF8);
                String here = Read.ReadToEnd();
                here = here.Trim(new Char[] { '{', '}'});
            
                String[] set = here.Split(',');
             String prePass = set[1].Substring(8, set[1].Length - 9 );

               
                if (prePass.Equals(pass)){
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private void btn_Click(object sender, EventArgs e)
        {

            bool go = true;
           
            String user = userBox.Text;
            String pass = passBox.Text;
            String pass2 = pass2Box.Text;

            if (user.Length < 5)
            {
                MessageBox.Show("Username is too short, must be at least 6!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                go = false;
            }
            else if (pass.Length < 5)
            {
                MessageBox.Show("Password too short, must be at least 6!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                go = false;
            }
            else if (register && pass2.Length < 5)
            {
                MessageBox.Show("Password too short, must be at least 6!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                go = false;
            }
            else if (register && (!pass.Equals(pass2)))
            {
                MessageBox.Show("Password does not match!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                go = false;
            } else if (pass.Contains(',') || pass.Contains('{') || pass.Contains('}') || pass.Contains(':') || pass.Contains('"') || pass.Contains('\''))
            {
                // bad -> , { } " ' :
                MessageBox.Show("For security reeasons, your password must NOT contain the following symbols.\n\n" +
                    "{ } , \" ' and :.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                go = false;

            } else if (pass.Contains("true"))
            {
                MessageBox.Show("For security reeasons, choose another password.", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                go = false;
            }

            if (go)
            {
                if (register)
                {
                    if (doesExist(user))
                    {
                        MessageBox.Show("User account already exist!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        registerOnline(user, pass);
                        messageEvent(user);
                     
                        userBox.Text = "";
                        passBox.Text = "";
                        pass2Box.Text = "";
                        register = false;
                        btn.Text = "LOGIN";
                        pass2Box.Visible = false;
                        pass2Line.Visible = false;
                        pass2Lab.Visible = false;
                        link.Text = "Not yet Registered? Register here.";
                        MessageBox.Show("Successfully Registered!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        head.Creation();
                    }
                }
                else
                {
                  
                    if (doesExist(user))
                    {
                        if (isPassCorrect(user,pass)) {
                            head.username = user;
                            head.password = pass;
                            

                            userBox.Text = "";
                            passBox.Text = "";
                            pass2Box.Text = "";
                            MessageBox.Show("Successfully Logged In!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Hide();
                            
                            head.set.updateSetting();
                            head.setSetting();

                            head.navBar.Enabled = true;

                            head.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Password!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                        MessageBox.Show("User Account does not exist!", "Kids Portal - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
             }
        }
    }
}
