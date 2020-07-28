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
        List<DEVICE_INFO> HardwareList;
        KeyboardHook hook = new KeyboardHook();
        ComparateImage comparate = new ComparateImage();
        FirewallRules firewall = new FirewallRules();
        public static bool vf = false;
        public Form1()
        {
            InitializeComponent();
        }
        public void ReloadHardwareList()
        {
            HardwareList = hwh.GetAll();
            listdevices.Items.Clear();
            foreach (var device in HardwareList)
            {
                ListViewItem lvi = new ListViewItem(new string[] { device.name, device.friendlyName, device.hardwareId, device.status.ToString() });
                listdevices.Items.Add(lvi);
            }
            label6.Text = HardwareList.Count.ToString() + " Devices Attached";
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

            ReloadHardwareList();

            hwh.HookHardwareNotifications(this.Handle, true);

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
                            ReloadHardwareList();
                        }
                        break;
                    }
            }
            base.WndProc(ref m);
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
            if (e.Modifier == GlobalHotKey.ModifierKeys.Alt && e.Key == Keys.F10)
            {
                //if (comboBox1.SelectedItem.Count == 0)
                //    return;
                //string[] devices = new string[1];
                hwh.CutLooseHardwareNotifications(this.Handle);
                //devices[0] = comboBox1.SelectedItem.ToString();
                try
                {

                    hwh.SetDeviceState(HardwareList[comboBox1.SelectedIndex], true);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
                hwh.HookHardwareNotifications(this.Handle, true);
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
            hwh.CutLooseHardwareNotifications(this.Handle);
            hwh = null;
            Properties.Settings.Default.cb1 = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listdevices.SelectedIndices.Count == 0)
                return;

            hwh.CutLooseHardwareNotifications(this.Handle);
            try
            {
                hwh.SetDeviceState(HardwareList[listdevices.SelectedIndices[0]], true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            hwh.HookHardwareNotifications(this.Handle, true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listdevices.SelectedIndices.Count == 0)
                return;

            hwh.CutLooseHardwareNotifications(this.Handle);

            try
            {
                hwh.SetDeviceState(HardwareList[listdevices.SelectedIndices[0]], false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

            hwh.HookHardwareNotifications(this.Handle, true);
        }
    }
}
