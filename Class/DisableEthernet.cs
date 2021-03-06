﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace MacetimTools.Class
{
    class DisableEthernet
    {
        public static void netsh_comand()
        {
            List<string> q = new List<string>();
            string networkInterfaceName = "";

            try
            {
                networkInterfaceName = q[0]; // Set Network Interface from Arguments

                Task TaskOne = Task.Factory.StartNew(() => DisableAdapter(networkInterfaceName));
                TaskOne.Wait();
                Task TaskTwo = Task.Factory.StartNew(() => EnableAdapter(networkInterfaceName));
            }
            catch (Exception e)
            {
                // Log Error Message
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "NetworkAdaptersUtility";
                    if (e.GetType().IsAssignableFrom(typeof(System.IndexOutOfRangeException)))
                    {
                        eventLog.WriteEntry("No Network Interface Provided", EventLogEntryType.Error, 101, 1);
                    }
                    else
                    {
                        eventLog.WriteEntry(e.Message, EventLogEntryType.Error, 101, 1);
                    }
                }
            }
        }
        public static void EnableAdapter(string interfaceName)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
        public static void DisableAdapter(string interfaceName)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
        public static List<string> NetworkIdentifier()
        {
            NetworkInterface[] networkInfo = NetworkInterface.GetAllNetworkInterfaces();

            //string currentNetName = "Not identified";
            
            List<string> currentNetName = new List<string>();

            for (int i = 0; i < networkInfo.Length; i++)
            {
                string nStatus = networkInfo[i].OperationalStatus.ToString();

                if (nStatus == "Up" && networkInfo[i].Name != "Loopback Pseudo-Interface 1")
                {
                    currentNetName.Add(networkInfo[i].Name.ToString());
                }
            }
            return currentNetName;
        }
    }
    
}
