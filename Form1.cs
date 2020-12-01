using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MacetimTools.Class;
using static MacetimTools.Class.GlobalHotKey;
using static MacetimTools.Class.SpecificPrint;
using static MacetimTools.Class.DisableEthernet;
using static MacetimTools.Class.FirewallRules;
using static MacetimTools.Class.Banco;
using HardwareHelperLib;
using System.Speech.Synthesis;
using System.Reflection;
using System.Drawing;
using System.Data.SQLite;

namespace MacetimTools
{
    public partial class Form1 : Form, ISharpUpdatable
    {
        private SplashScreen splashScreen;
        public static string ipV4, exWay;
        public static int ipIndex = 0;
        int tempo = 0, hora = 0, minuto = 0, segundo = 0;
        HH_Lib hwh = new HH_Lib();
        KeyboardHook hook = new KeyboardHook();
        ComparateImage comparate = new ComparateImage();
        private SharpUpdate updater;
        public static bool versionX = false;

        public Form1()
        {
            InitializeComponent();
            this.splashScreen = new SplashScreen();
            this.lb_version.Text = this.ApplicationAssembly.GetName().Version.ToString();
            updater = new SharpUpdate(this);
            this.Hide();
            splashScreen.Show();
            System.Threading.Thread.Sleep(3000);
            splashScreen.Close();
            this.Show();
            updater.DoUpdate();

        }

        #region SharpUpdate
        public string ApplicationName
        {
            get { return "MacetimTools"; }
        }

        public string ApplicationID
        {
            get { return "MacetimTools"; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }
        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri("https://raw.githubusercontent.com/h4rdrew/MacetimTools/master/update.xml"); }
        }

        public Form Context
        {
            get { return this; }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            newdb();

            // Verificacao se a pasta "Macetim" existe ou nao, se nao, ele cria.
            if (Directory.Exists("C:\\Program Files\\Macetim") == false)
            {
                Directory.CreateDirectory("C:\\Program Files\\Macetim\\True");
            }

            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F1);  //--- ALT+F1: Digital Casino Heist Hotkey
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F9);  //--- ALT+F9: Network Disable Hotkey
            hook.RegisterHotKey(GlobalHotKey.ModifierKeys.Alt, Keys.F12); //--- ALT+F12: Solo Public Game Hotkey

            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "00:00:00"; //HH:mm:ss

            GetSettings(); //Carrega os dados que foram salvos em Form1_FormClosing()
        }
        public void GetSettings()
        {
            rbtn_StopProcess.Checked = Properties.Settings.Default.radb1;
            rbtn_Firewall.Checked = Properties.Settings.Default.radb2;
            rbtn_FirewallFriends.Checked = Properties.Settings.Default.radb3;
            cb_Custom.Checked = Properties.Settings.Default.cb1;
            cb_DisableDevice.Checked = Properties.Settings.Default.cb2;
            txb_GTADirectory.Text = Properties.Settings.Default.txtbx3;
            txb_Custom.Text = Properties.Settings.Default.txtbx1;


            if (cb_Custom.Checked == false)
            {
                txb_Custom.Enabled = false;
                networkIdenRefreshList();

                try
                {
                    cbx_NetworkName.SelectedIndex = Properties.Settings.Default.cbox2;
                }
                catch
                {
                    networkIdenRefreshList();
                }
            }

            if (cb_DisableDevice.Checked == true)
            {
                DeviceList();

                try
                {
                    cbx_DeviceList.SelectedIndex = Properties.Settings.Default.cbox1;
                }
                catch
                {
                    DeviceList();
                }
            }
        }
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //--- ALT+F1: Digital Casino Heist Hotkey
            if (e.Modifier == GlobalHotKey.ModifierKeys.Alt && e.Key == Keys.F1)
            {
                Directory.CreateDirectory("C:\\Program Files\\Macetim\\Temp");
                printpoint();
                comparate.image_comparate();
                VIMH(comparate.image_comparate());
            }
            //--- ALT+F9: Network Disable Hotkey
            if (e.Modifier == GlobalHotKey.ModifierKeys.Alt && e.Key == Keys.F9)
            {
                //string[] devices = new string[1];

                //------Disable by Device-----
                if (cb_DisableDevice.Checked == true) 
                {
                    SetDisableDevice(false);
                }

                //------Disable by Network Name-------
                else
                {
                    SetDisableAdapter(false);
                }
            }
            //--- ALT+F12: Solo Public Game Hotkey
            if (e.Modifier == GlobalHotKey.ModifierKeys.Alt && e.Key == Keys.F12)
            {
                //--- Stop Process
                if (rbtn_StopProcess.Checked == true)
                {
                    try
                    {
                        SetStopProcess(false);
                    }
                    catch
                    {
                        MessageBox.Show("'GTA5.exe' not found. Please check and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //--- Firewall
                if (rbtn_Firewall.Checked == true)
                {
                    CheckRules("Block Internet");
                    if (indicador == true)
                    {
                        FirewallSet(true, "Block Internet");
                        System.Threading.Thread.Sleep(10000);
                        FirewallSet(false, "Block Internet");
                    }
                }
                //--- Firewall w/Friends
                if (rbtn_FirewallFriends.Checked == true)
                {
                    if (FirewallCheckStatus("GTASoloFriends") == true)
                    {
                        FirewallSet(false, "GTASoloFriends");
                        pb_Firewall.Image = MacetimTools.Properties.Resources.uncheck;
                    }
                    else
                    {
                        FirewallSet(true, "GTASoloFriends");
                        pb_Firewall.Image = MacetimTools.Properties.Resources.check;
                    }
                }
            }
        }
        public void DeviceList()
        {
            string[] HardwareList = hwh.GetAll();
            foreach (string s in HardwareList)
            {
                cbx_DeviceList.Items.Add(s);
            }

            hwh.HookHardwareNotifications(this.Handle, true);
        }
        public void SetStopProcess(bool resume)
        {
            Process[] remoteByName = Process.GetProcessesByName("GTA5");
            int idProcess = remoteByName[0].Id;

            if (resume == false)
            {
                Class.StopProcess.SuspendProcess(idProcess);
                tempo = 10;
                timerSP.Enabled = true;
            }


            if (resume == true)
            {
                Class.StopProcess.ResumeProcess(idProcess);
            }
        }
        public void SetDisableDevice(bool resume)
        {
            string[] devices = new string[1];

            if (resume == false)
            {
                hwh.CutLooseHardwareNotifications(this.Handle);
                devices[0] = cbx_DeviceList.SelectedItem.ToString();
                hwh.SetDeviceState(devices, false);
                hwh.HookHardwareNotifications(this.Handle, true);

                tempo = 6;
                timerDD.Enabled = true;
            }

            if(resume == true)
            {
                hwh.CutLooseHardwareNotifications(this.Handle);
                devices[0] = cbx_DeviceList.SelectedItem.ToString();
                hwh.SetDeviceState(devices, true);
                hwh.HookHardwareNotifications(this.Handle, true);
            }
        }
        public void SetDisableAdapter(bool resume)
        {
            if (cb_Custom.Checked == true)
            {
                if(resume == false)
                {
                    DisableAdapter(txb_Custom.Text);
                    tempo = 3;
                    timerNM.Enabled = true;
                }

                if(resume == true)
                {
                    EnableAdapter(txb_Custom.Text);
                }
            }
            else
            {
                if(resume == false)
                {
                    DisableAdapter(cbx_NetworkName.SelectedItem.ToString());
                    tempo = 3;
                    timerNM.Enabled = true;
                }

                if (resume == true)
                {
                    EnableAdapter(cbx_NetworkName.SelectedItem.ToString());
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case HardwareHelperLib.Native.WM_DEVICECHANGE:
                    {
                        if (m.WParam.ToInt32() == HardwareHelperLib.Native.DBT_DEVNODES_CHANGED)
                        {
                            string[] HardwareList = hwh.GetAll();
                            foreach (string s in HardwareList)
                            {
                                cbx_DeviceList.Items.Add(s);
                            }
                        }
                        break;
                    }
            }
            base.WndProc(ref m);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Custom.Checked == true)
            {
                txb_Custom.Enabled = true;
                cbx_NetworkName.Enabled = false;
            }

            if (cb_Custom.Checked == false)
            {
                txb_Custom.Enabled = false;
                cbx_NetworkName.Enabled = true;

                if (cbx_NetworkName.Items.Count == 0)
                {
                    networkIdenRefreshList();
                }
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DisableDevice.Checked == true)
            {
                //-----------------------
                cbx_NetworkName.Enabled = false;
                cb_Custom.Enabled = false;
                txb_Custom.Enabled = false;
                //-----------------------
                DeviceList();
                cbx_DeviceList.Enabled = true;
            }

            if (cb_DisableDevice.Checked == false)
            {
                if (cb_Custom.Checked == true)
                {
                    txb_Custom.Enabled = true;
                    cbx_NetworkName.Enabled = false;
                }

                if (cb_Custom.Checked == false)
                {
                    txb_Custom.Enabled = false;
                    cbx_NetworkName.Enabled = true;
                }

                cb_Custom.Enabled = true;
                cbx_DeviceList.Enabled = false;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_FirewallFriends.Checked == true)
            {
                gb_IPRules.Enabled = true;
                IpVerf();
                ipRulesRefreshList();
                if (FirewallCheckStatus("GTASoloFriends") == true)
                {
                    pb_Firewall.Visible = true;
                    pb_Firewall.Image = MacetimTools.Properties.Resources.check;
                }
                else
                {
                    pb_Firewall.Visible = true;
                    pb_Firewall.Image = MacetimTools.Properties.Resources.uncheck;
                }
            }
            else
            {
                gb_IPRules.Enabled = false;
                pb_Firewall.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /* 
            Checando se o textbox2 ou textbox3 nao estao vazios ou nulos
            caso algum nao esteja no parametro requisitado, o processo retorna.

            Com devidos dados inseridos em textBox2 e textBox3, outras duas variaveis publicas
            estarao recebendos os valores.

            IPList() eh acionado para que possa armazenar os dados no arquivo IPList.txt

            CheckRules() eh acionado para verificar se existe tal regra, se nao, ele cria
            a regra com o nome pre-difinido e insere o IP enviado pelo usuario.

            IpVerf() eh acionado para organizar os IP existentes na regra do firewall e adicionar
            a uma lista publica ListIP.

            Sera limpo os textBox e em seguida foco no textBox2

            ipRulesRefreshList() eh acionado para atualizar a listBox1 com o novo IP.
            */

            #region SwitchCase de tratamento

            int caseSwitch = 0;

            if (string.IsNullOrEmpty(txb_IP.Text) && string.IsNullOrEmpty(txb_GTADirectory.Text))
            {
                caseSwitch = 1;
            }

            if (string.IsNullOrEmpty(txb_IP.Text) && !string.IsNullOrEmpty(txb_GTADirectory.Text))
            {
                caseSwitch = 2;
            }

            if (string.IsNullOrEmpty(txb_GTADirectory.Text) && !string.IsNullOrEmpty(txb_IP.Text))
            {
                caseSwitch = 3;
            }

            switch (caseSwitch)
            {
                case 1:
                    MessageBox.Show("O campo de IP e GTA5.exe não foram preenchidos.");
                    caseSwitch = 0;
                    return;
                case 2:
                    MessageBox.Show("O campo de IP não foi preenchido.");
                    caseSwitch = 0;
                    return;
                case 3:
                    MessageBox.Show("O campo do caminho do GTA5.exe precisa ser preenchido.");
                    caseSwitch = 0;
                    return;
                case 0:
                    break;
            }

            #endregion

            exWay = txb_GTADirectory.Text;
            ipV4 = txb_IP.Text;

            CheckRules("GTASoloFriends");
            dbInsert(txb_IP.Text, txb_Name.Text);
            IpVerf();
            txb_IP.Clear();
            txb_Name.Clear();
            txb_IP.Focus();
            ipRulesRefreshList();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] test = lbx_IPList.SelectedItem.ToString().Split(' ');
                IpRemove(lbx_IPList.SelectedIndex);
                IPRemoveDB(test[0]);
                ipRulesRefreshList();
            }
            catch
            {
                ipRulesRefreshList();
            }
        }
        public void ipRulesRefreshList()
        {
            // ---ipRulesRefreshList() eh responsavel por pegar os dados do IPList.txt e transferir para a listBox1 para ser visivel

            lbx_IPList.Items.Clear();

            string cs = @"URI=file:C:\Program Files\Macetim\iplist.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT IP, NAME FROM iplist ORDER BY " +
                "CAST(substr(trim(IP), 1, instr(trim(IP), '.') - 1) AS INTEGER), " +
                "CAST(substr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), 1, instr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), '.') - 1) AS INTEGER), " +
                "CAST(substr(substr(trim(IP), length(substr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), 1, instr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), '.'))) + length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), 1, instr(substr(trim(IP), length(substr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), 1, instr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), '.'))) + length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), '.') - 1) AS INTEGER), " +
                "CAST(substr(trim(IP), length(substr(substr(trim(IP), length(substr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), 1, instr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), '.'))) + length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), 1, instr(substr(trim(IP), length(substr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), 1, instr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), '.'))) + length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), '.'))) + length(substr(trim(IP), 1, instr(trim(IP), '.'))) + length(substr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), 1, instr(substr(trim(IP), length(substr(trim(IP), 1, instr(trim(IP), '.'))) + 1, length(IP)), '.'))) + 1, length(trim(IP))) AS INTEGER)";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                lbx_IPList.Items.Add($"{rdr.GetString(0)} - {rdr.GetString(1)}");
            } 
        }
        public void networkIdenRefreshList()
        {
            // ---networkIdenRefreshList() eh responsavel em atualizar a lista de redes disponiveis.

            cbx_NetworkName.DataSource = null;
            cbx_NetworkName.Items.Clear();
            cbx_NetworkName.DataSource = NetworkIdentifier();
        }
        public void IPRemoveDB(string ip)
        {
            string cs = @"URI=file:C:\Program Files\Macetim\iplist.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = $"delete from iplist where IP = '{ip}'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
        }
        public void VIMH(string text)
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Configure the audio output.   
                synth.SetOutputToDefaultAudioDevice();

                // Create a PromptBuilder object and append a text string.  
                PromptBuilder song = new PromptBuilder();
                song.AppendText($"{text}");

                // Speak the contents of the prompt synchronously.  
                synth.Speak(song);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            updater.DoUpdate();

            if (versionX == true)
            {
                MessageBox.Show($"Its version is the most recent. Version: {ProductVersion}");
            }
        }
        private void timerSP_Tick(object sender, EventArgs e)
        {
            tempo--;

            if (tempo == 0)
            {
                timerSP.Enabled = false;
                SetStopProcess(true);
            }
        }
        private void timerDD_Tick(object sender, EventArgs e)
        {
            tempo--;

            if(tempo == 0)
            {
                timerDD.Enabled = false;
                SetDisableDevice(true);
            }
        }
        private void timerNM_Tick(object sender, EventArgs e)
        {
            tempo--;

            if (tempo == 0)
            {
                timerNM.Enabled = false;
                SetDisableAdapter(true);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            segundo--;

            if (segundo <= 0 && minuto > 0)
            {
                segundo = 59;
                minuto--;
            }

            if(segundo <=0 && minuto <= 0 && hora > 0)
            {
                hora--;
                minuto = 59;
                segundo = 59;
            }

            #region If Pra Caralho(Apenas teste)
            if (hora < 10)
            {
                if (minuto < 10)
                {
                    if (segundo < 10)
                    {
                        label14.Text = "0" + hora + ":" + "0" + minuto + ":" + "0" + segundo;
                    }
                    if (segundo > 9)
                    {
                        label14.Text = "0" + hora + ":" + "0" + minuto + ":" + segundo;
                    }
                }
                if (minuto > 9)
                {
                    if (segundo < 10)
                    {
                        label14.Text = "0" + hora + ":" + minuto + ":" + "0" + segundo;
                    }
                    if (segundo > 9)
                    {
                        label14.Text = "0" + hora + ":" + minuto + ":" + segundo;
                    }
                }
            }

            if (hora > 9)
            {
                if (minuto < 10)
                {
                    if (segundo < 10)
                    {
                        label14.Text = hora + ":" + "0" + minuto + ":" + "0" + segundo;
                    }
                    if (segundo > 9)
                    {
                        label14.Text = hora + ":" + "0" + minuto + ":" + segundo;
                    }
                }
                if (minuto > 9)
                {
                    if (segundo < 10)
                    {
                        label14.Text = hora + ":" + minuto + ":" + "0" + segundo;
                    }
                    if (segundo > 9)
                    {
                        label14.Text = hora + ":" + minuto + ":" + segundo;
                    }
                }
            }

            //if (minuto < 10)
            //{
            //    if (segundo < 10)
            //    {
            //        label14.Text = "0" + hora + ":" + "0" + minuto + ":" + "0" + segundo;
            //    }
            //    if (segundo > 9)
            //    {
            //        label14.Text = "0" + hora + ":" + "0" + minuto + ":" + segundo;
            //    }
            //}

            //if (minuto > 9)
            //{
            //    if (segundo < 10)
            //    {
            //        label14.Text = "0" + hora + ":" + minuto + ":" + "0" + segundo;
            //    }
            //    if (segundo > 9)
            //    {
            //        label14.Text = "0" + hora + ":" + minuto + ":" + segundo;
            //    }
            //}

            //if (segundo < 10)
            //{
            //    label14.Text = "0" + hora + ":" + "0" + minuto + ":" + "0" + segundo;
            //}

            //if (segundo > 9)
            //{
            //    label14.Text = "0" + hora + ":" + "0" + minuto + ":" + segundo;
            //}
            #endregion


            if (hora == 0 && minuto == 0 && segundo == 0)
            {
                timer1.Enabled = false;
                label14.Text = "00:00:00";
                VIMH(textBox6.Text);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            /* 
            O usuario seta o 'GTA5.exe' aonde esta atualmente instalado.
            */

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.SafeFileName != "GTA5.exe")
                {
                    MessageBox.Show("Selecione o 'GTA5.exe'.");
                }
                else
                {
                    txb_GTADirectory.Text = ofd.FileName;
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            hora = Convert.ToInt16(hourNumeric.Value);
            minuto = Convert.ToInt16(minuteNumeric.Value);
            segundo = Convert.ToInt16(secondNumeric.Value);

            timer1.Enabled = true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            hwh.CutLooseHardwareNotifications(this.Handle);
            hwh = null;
            Properties.Settings.Default.cb1 = cb_Custom.Checked;
            Properties.Settings.Default.cb2 = cb_DisableDevice.Checked;
            Properties.Settings.Default.cbox1 = cbx_DeviceList.SelectedIndex;
            Properties.Settings.Default.cbox2 = cbx_NetworkName.SelectedIndex;
            Properties.Settings.Default.radb1 = rbtn_StopProcess.Checked;
            Properties.Settings.Default.radb2 = rbtn_Firewall.Checked;
            Properties.Settings.Default.radb3 = rbtn_FirewallFriends.Checked;
            Properties.Settings.Default.txtbx3 = txb_GTADirectory.Text;
            Properties.Settings.Default.txtbx1 = txb_Custom.Text;
            Properties.Settings.Default.Save();
        }
    }
}

