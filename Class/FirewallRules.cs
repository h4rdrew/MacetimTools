using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFwTypeLib;

namespace MacetimTools.Class
{
    class FirewallRules
    {
        public static bool indicador = false;
        public static void FirewallAddRule()
        {
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
                    firewallRule.Name = "Block Internet";

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
                    firewallRule.Name = "Block Internet";

                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
                        Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

                    firewallPolicy.Rules.Add(firewallRule);
                }
            }
            CheckRules();
        }
        public static void CheckRules(string RuleName = "Block Internet")
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

            // Lista rules
            List<INetFwRule> RuleList = new List<INetFwRule>();

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name.IndexOf(RuleName) != -1)
                {
                    indicador = true;
                    //break;
                }
            }
            if (indicador == false)
            {
                FirewallAddRule();
            }

        }
        public static void FirewallSet(bool interruptor)
        {
            string RuleName = "Block Internet";
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

            // Lista rules
            List<INetFwRule> RuleList = new List<INetFwRule>();

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name.IndexOf(RuleName) != -1)
                {
                    rule.Enabled = interruptor;
                }
            }
        }
    }
}
