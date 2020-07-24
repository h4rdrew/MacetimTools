using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MacetimTools.Class;
using static MacetimTools.Class.GlobalHotKey;
using static MacetimTools.Class.SpecificPrint;
using static MacetimTools.Class.DisableEthernet;
using static MacetimTools.Class.FirewallRules;

namespace MacetimTools
{
    public partial class Form1 : Form
    {
        KeyboardHook hook = new KeyboardHook();
        ComparateImage comparate = new ComparateImage();
        FirewallRules firewall = new FirewallRules();
        public static bool vf = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("C:\\Program Files\\Macetim") == false)
            {
                Directory.CreateDirectory("C:\\Program Files\\Macetim\\True");
            }

            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F1); //Suspender o processo"GTAV.exe" e reiniciar depois de 10sec
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F9); //Desconectar a internet (rede Ethernet por enquanto) e reconectar depois de 3sec
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F10); //Desconectar a internet (via Firewall rules) e reconectar depois de 3sec --TESTE
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F12);  //Macetim de ficar solo na sessão

            GetSettings();
        }
        public void GetSettings()
        {
            checkBox1.Checked = Properties.Settings.Default.cb1;
        }
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // show the keys pressed in a label.
            //label1.Text = e.Modifier.ToString() + " + " + e.Key.ToString();
            if (e.Modifier == GlobalHotKey.ModifierKeys.Alt && e.Key == Keys.F1)
            {
                Directory.CreateDirectory("C:\\Program Files\\Macetim\\Temp");
                printpoint();
                comparate.image_comparate();
            }
            if (e.Modifier == GlobalHotKey.ModifierKeys.Alt && e.Key == Keys.F9)
            {
                if (vf == true)
                {
                    CheckRules();
                    if (indicador == true)
                    {
                        FirewallSet(true);
                        System.Threading.Thread.Sleep(3000);
                        FirewallSet(false);
                    }
                }
                else
                {
                    //DisableAdapter(""+textBox1.Text);
                    DisableAdapter("Ethernet");
                    System.Threading.Thread.Sleep(3000);
                    EnableAdapter("Ethernet");
                    //MessageBox.Show("TESTE F9");
                }
            }
            if (e.Modifier == GlobalHotKey.ModifierKeys.Alt && e.Key == Keys.F12)
            {
                Process[] remoteByName = Process.GetProcessesByName("GTA5");
                int teste = remoteByName[0].Id;
                StopProcess.SuspendProcess(teste);
                System.Threading.Thread.Sleep(10000);
                StopProcess.ResumeProcess(teste);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Process[] remoteByName = Process.GetProcessesByName("GTA5");
            int teste = remoteByName[0].Id;
            StopProcess.ResumeProcess(teste);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Process[] remoteByName = Process.GetProcessesByName("GTA5");
            int teste = remoteByName[0].Id;
            StopProcess.SuspendProcess(teste);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Process[] remoteByName = Process.GetProcessesByName("GTA5");
            int teste = remoteByName[0].Id;
            StopProcess.SuspendProcess(teste);
            System.Threading.Thread.Sleep(10000);
            StopProcess.ResumeProcess(teste);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Notas notas = new Notas();
            notas.Show();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                vf = true;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.cb1 = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
