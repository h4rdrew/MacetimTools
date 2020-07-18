using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MacetimTools.Class;
using static MacetimTools.Class.GlobalHotKey;
using static MacetimTools.Class.SpecificPrint;
using static MacetimTools.Class.DisableEthernet;

namespace MacetimTools
{
    public partial class Form1 : Form
    {
        KeyboardHook hook = new KeyboardHook();
        ComparateImage comparate = new ComparateImage();
        public Form1()
        {
            InitializeComponent();

            if (Directory.Exists("C:\\Program Files\\Macetim") == false)
            {
                Directory.CreateDirectory("C:\\Program Files\\Macetim\\True");
            }

            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F1); //Suspender o processo"GTAV.exe" e reiniciar depois de 10sec
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F9); //Desconectar a internet (rede Ethernet por enquanto) e reconectar depois de 3sec
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F12);  //Macetim de ficar solo na sessão
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
                //Dispose(true);
                //Dispose();
                //Application.Restart();
            }
            if (e.Modifier == GlobalHotKey.ModifierKeys.Alt && e.Key == Keys.F9)
            {
                //DisableAdapter(""+textBox1.Text);
                DisableAdapter("Ethernet");
                System.Threading.Thread.Sleep(3000);
                EnableAdapter("Ethernet");
                //MessageBox.Show("TESTE F9");

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
    }
}
