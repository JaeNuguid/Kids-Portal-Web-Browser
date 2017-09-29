using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newKidsPortal
{
    public partial class voice : Form
    { 
      String[] voices = {     "how are you", "Who are you", "what are you made of","where are you","how old are you",
"close browser", "exit browser", "minimize browser", "hide browser", "logout computer", "shutdown computer", "open notepad", "open calculator", "open explorer", "open folder", "what is the time now", "what is the day today", "hi computer", "hello computer", "what is kids portal", "go to kids portal", "increase volume",
            "decrease volume", "mute volume","go to google", "go to facebook","go to youtube", "go to homepage","go to twitter", "go to wikipedia","go to yahoo", "go to gmail","go to hotmail", "I want to search images","I want to search videos", "I want to search pictures","I want to play games", "search for games","search for pictures", "search for images","I want to learn something", "go to messenger","go to instagram", "go to netflix",
            "go to linked in","I want to watch videos","I want to watch movies","maximize browser", "go to drop box","go to the developer","open setting", "open voice command","hide voice command"};

    KidsPortal kp;
        public voice(KidsPortal kp)
        {
            this.kp = kp;
            InitializeComponent();
            setCommands();
        }

        public void setCommands()
        {
            foreach (string x in voices)
                box.Items.Add(x);
        }
        public bool on= true;

        private void voiceBtn_Click(object sender, EventArgs e)
        {
            if (on)
            {
                on = false;
                voiceLabel.Text = "Web Control is currently turend off.";
                voiceBtn.ForeColor = Color.Red;
                voiceBtn.Text = "TURN ON";
                
            }
            else
            {
                on= true;
                voiceLabel.Text = "Web Control is currently turend on.";
                voiceBtn.ForeColor = Color.Green;
                voiceBtn.Text = "TURN OFF";

            }
            kp.onVoice(on);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
