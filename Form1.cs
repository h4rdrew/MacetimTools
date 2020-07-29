using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MacetimTools.Class;
using static MacetimTools.Class.GlobalHotKey;
using static MacetimTools.Class.SpecificPrint;
using static MacetimTools.Class.DisableEthernet;
using static MacetimTools.Class.FirewallRules;
using HardwareHelperLib;
using System.Collections.Generic;

namespace MacetimTools
{
    public partial class Form1 : Form
    { 
        HH_Lib hwh = new HH_Lib();
        KeyboardHook hook = new KeyboardHook();
        ComparateImage comparate = new ComparateImage();
        FirewallRules firewall = new FirewallRules();
        public static bool vf = false;
        public static bool vf2 = false;
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

            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F1); //Macetim da Digital
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F9); //Desconectar a internet (rede Ethernet por enquanto) e reconectar depois de 3sec
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F10);
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F12);  //Macetim de ficar solo na sessão

            string[] HardwareList = hwh.GetAll();
            foreach (string s in HardwareList)
            {
                comboBox1.Items.Add(s);
            }

            hwh.HookHardwareNotifications(this.Handle, true);
            comboBox1.Enabled = false;
            GetSettings();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case HardwareHelperLib.Native.WM_DEVICECHANGE:
                    {
                        if (m.WParam.ToInt32() == HardwareHelperLib.Native.DBT_DEVNODES_CHANGED)
                        {
                            //comboBox1.Items.Clear();
                            string[] HardwareList = hwh.GetAll();
                            foreach (string s in HardwareList)
                            {
                                comboBox1.Items.Add(s);
                            }
                        }
                        break;
                    }
            }
            base.WndProc(ref m);
        }
        public void GetSettings()
        {
            checkBox1.Checked = Properties.Settings.Default.cb1;
            checkBox2.Checked = Properties.Settings.Default.cb2;
            comboBox1.SelectedIndex = Properties.Settings.Default.cbox1;
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
                string[] devices = new string[1];
                if (vf2 == true)
                {
                    //Disable
                    hwh.CutLooseHardwareNotifications(this.Handle);
                    devices[0] = comboBox1.SelectedItem.ToString();
                    hwh.SetDeviceState(devices, false);
                    hwh.HookHardwareNotifications(this.Handle, true);
                    //-----------------------------------------------
                    System.Threading.Thread.Sleep(3000);
                    //Enable
                    hwh.CutLooseHardwareNotifications(this.Handle);
                    devices[0] = comboBox1.SelectedItem.ToString();
                    hwh.SetDeviceState(devices, true);
                    hwh.HookHardwareNotifications(this.Handle, true);
                }
                else
                {
                    DisableAdapter("Ethernet");
                    System.Threading.Thread.Sleep(3000);
                    EnableAdapter("Ethernet");
                }
            }
            if (e.Modifier == GlobalHotKey.ModifierKeys.Alt && e.Key == Keys.F12)
            {
                if (vf == true)
                {
                    CheckRules();
                    if (indicador == true)
                    {
                        FirewallSet(true);
                        System.Threading.Thread.Sleep(10000);
                        FirewallSet(false);
                    }
                }
                else
                {
                    Process[] remoteByName = Process.GetProcessesByName("GTA5");
                    int teste = remoteByName[0].Id;
                    StopProcess.SuspendProcess(teste);
                    System.Threading.Thread.Sleep(10000);
                    StopProcess.ResumeProcess(teste);
                }
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
        private void button5_Click(object sender, EventArgs e)
        {
            //Enable
            string[] devices = new string[1];
            hwh.CutLooseHardwareNotifications(this.Handle);
            devices[0] = comboBox1.SelectedItem.ToString();
            hwh.SetDeviceState(devices, true);
            hwh.HookHardwareNotifications(this.Handle, true);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //Disable
            string[] devices = new string[1];
            hwh.CutLooseHardwareNotifications(this.Handle);
            devices[0] = comboBox1.SelectedItem.ToString();
            hwh.SetDeviceState(devices, false);
            hwh.HookHardwareNotifications(this.Handle, true);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                vf = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                vf = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                comboBox1.Enabled = true;
                vf2 = true;
            }
            else
            {
                comboBox1.Enabled = false;
                vf2 = false;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            hwh.CutLooseHardwareNotifications(this.Handle);
            hwh = null;
            Properties.Settings.Default.cb1 = checkBox1.Checked;
            Properties.Settings.Default.cb2 = checkBox2.Checked;
            Properties.Settings.Default.cbox1 = comboBox1.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
