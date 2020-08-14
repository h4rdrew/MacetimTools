using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using NetFwTypeLib;
using static MacetimTools.Form1;

namespace MacetimTools.Class
{
    class FirewallRules
    {
        public static string ipNeg = " ", ipPos = " ";
        public static bool indicador = false;
        public static List<string> ListIP = new List<string>();
        public static void FirewallAddRule(string RuleName)
        {
            int option = 0;

            if(RuleName == "GTASoloFriends")
            {
                option = 1;
            }

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(
                        Type.GetTypeFromProgID("HNetCfg.FWRule"));

                    firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    firewallRule.Description = "Used to block all internet access.";
                    firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    firewallRule.Enabled = false;
                    firewallRule.InterfaceTypes = "All";
                    if(option == 1)
                    {
                        firewallRule.Protocol = 17;
                        firewallRule.ApplicationName = $@"{exWay}";
                        firewallRule.LocalPorts = "6672";
                    }
                    firewallRule.Name = RuleName;

                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
                        Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

                    firewallPolicy.Rules.Add(firewallRule);
                }
                if (i == 1)
                {
                    INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(
                        Type.GetTypeFromProgID("HNetCfg.FWRule"));

                    firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    firewallRule.Description = "Used to block all internet access.";
                    firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                    firewallRule.Enabled = false;
                    firewallRule.InterfaceTypes = "All";
                    if (option == 1)
                    {
                        firewallRule.Protocol = 17;
                        firewallRule.ApplicationName = $@"{exWay}";
                        firewallRule.LocalPorts = "6672";
                    }
                    firewallRule.Name = RuleName;

                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
                        Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

                    firewallPolicy.Rules.Add(firewallRule);
                }
            }
            CheckRules(RuleName);
        }
        public static void CheckRules(string RuleName)
        {
            indicador = false;

            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

            List<INetFwRule> RuleList = new List<INetFwRule>();
            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name.IndexOf(RuleName) != -1)
                {
                    indicador = true;
                    if(RuleName == "GTASoloFriends")
                    {
                        INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                        string aux = rule.RemoteAddresses;
                        IpA();

                        if (aux == "*")
                        {
                            rule.RemoteAddresses = $"0.0.0.0-{ipNeg},{ipPos}-255.255.255.255";
                        }
                        else
                        {
                            rule.RemoteAddresses = $"{aux}" + $",0.0.0.0-{ipNeg},{ipPos}-255.255.255.255";
                        }
                    }
                }
            }
            if (indicador == false)
            {
                if (RuleName == "GTASoloFriends") 
                {
                    FirewallAddRule(RuleName);
                    IpA();
                }
                if(RuleName == "Block Internet")
                {
                    FirewallAddRule(RuleName);
                }
            }
        }
        public static void FirewallSet(bool interruptor, string RuleName)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

            List<INetFwRule> RuleList = new List<INetFwRule>();

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name.IndexOf(RuleName) != -1)
                {
                    rule.Enabled = interruptor;
                }
            }
        }
        public static bool FirewallCheckStatus(string RuleName)
        {
            try
            {
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                var rule = firewallPolicy.Rules.Item(RuleName);

                bool cStatus = rule.Enabled;

                return cStatus;
            }
            catch
            {
                return false;
            }
        }
        public static void IpA()
        {
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            var rule = firewallPolicy.Rules.Item("GTASoloFriends");
            string[] blocks = new string[4];

            blocks = ipV4.Split('.');
            int[] myints = Array.ConvertAll(blocks, s => int.Parse(s));
            myints[3]--;
            string fullIP = "";

            for (int i = 0; i < 4; i++)
            {
                blocks[i] = myints[i].ToString() + ".";
                fullIP = fullIP + blocks[i];
                if (i == 3)
                {
                    fullIP = fullIP.Remove(fullIP.Length - 1);
                }
            }
            ipNeg = fullIP;

            blocks = ipV4.Split('.');
            myints = Array.ConvertAll(blocks, s => int.Parse(s));
            myints[3]++;
            fullIP = "";

            for (int i = 0; i < 4; i++)
            {
                blocks[i] = myints[i].ToString() + ".";
                fullIP = fullIP + blocks[i];
                if (i == 3)
                {
                    fullIP = fullIP.Remove(fullIP.Length - 1);
                }
            }

            ipPos = fullIP;

        }
        public static void IpVerf()
        {
            try
            {
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                var rule = firewallPolicy.Rules.Item("GTASoloFriends");

                string aux = rule.RemoteAddresses;
                string[] blocks;
                List<string> myList = new List<string>();
                blocks = aux.Split('-', ',');
                for (int i = 0; i < blocks.Length; i++)
                {
                    myList.Add(blocks[i]);
                }

                //--------------------  Organizando a lista abaixo com apenas IP's inseridas
                myList.RemoveAt(0);

                int v = 1, x = 0, p = ((myList.Count + 1) / 4);

                while (myList.Count != p)
                {
                    myList.RemoveAt(v);
                    x++;
                    if (x == 3)
                    {
                        v++;
                        x = 0;
                    }
                }

                string[] Jooj = new string[4];
                int[] myints;
                string[] ListU = new string[myList.Count];
                p = ListIP.Count;

                for (int i = 0; i < p; i++)
                {
                    ListIP.RemoveAt(0);
                }

                for (int i = 0; i < myList.Count; i++)
                {
                    Jooj = myList[i].Split('.').ToArray();
                    myints = Array.ConvertAll(Jooj, s => int.Parse(s));
                    myints[3]++;

                    for (int z = 0; z < 4; z++)
                    {
                        ListU[i] = ListU[i] + myints[z].ToString() + ".";
                    }

                    ListU[i] = ListU[i].Remove(ListU[i].Length - 1);
                    ListIP.Add(ListU[i]);
                }
            }
            catch
            {
                return;
            }
        }
        public static void IpRemove(int ipRemove)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

            List<INetFwRule> RuleList = new List<INetFwRule>();
            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name.IndexOf("GTASoloFriends") != -1)
                {
                    string aux = rule.RemoteAddresses;
                    string[] blocks;
                    List<string> myList = new List<string>();
                    blocks = aux.Split(',');

                    for (int i = 0; i < blocks.Length; i++)
                    {
                        myList.Add(blocks[i]);
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        myList.RemoveAt(ipRemove * 2);
                    }

                    aux = string.Join(",", myList.ToArray());
                    rule.RemoteAddresses = aux;
                }
            }
            IpVerf();
        }
    }

}
