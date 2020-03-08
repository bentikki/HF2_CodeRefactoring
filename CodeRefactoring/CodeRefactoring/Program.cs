using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CodeRefactoring
{
    class Program
    {
        static void Main()
        {
            IPAddress[] array = Dns.GetHostAddresses("en.wikipedia.org");
            foreach (IPAddress ip in array)
            {
                Console.WriteLine(ip.ToString());
            }

            //PingSender class to send pings. 
            PingSender pingSender = new PingSender();
            PingAnswer ping = pingSender.LocalPing();
            //PingAnswer ping = pingSender.Ping("8.8.8.8");

            Console.WriteLine("Reply: " + ping.Reply);
            if (ping.Success)
            {
                Console.WriteLine("Address:         " + ping.Address);
                Console.WriteLine("RoundTripTime:   " + ping.RoundTripTime);
                Console.WriteLine("TTL:             " + ping.TTL);
                Console.WriteLine("DontFragment:    " + ping.DontFragment);
                Console.WriteLine("BufferSize:      " + ping.BufferSize);
            }


            Console.WriteLine("start");
            string t = GetIPInfo.HostnameFromIp("8.8.8.8");
            Console.WriteLine(t);
            Console.WriteLine("slut");
            string adr = GetIPInfo.IpFromHostname(t);
            Console.WriteLine("Weee " + adr);



            string a = Traceroute.Trace("8.8.8.8");
            Console.WriteLine("route*** " + a);

            List<string> dhcpAdresses =  Dhcp.GetServerAdresses();

            foreach (string adress in dhcpAdresses)
            {
                Console.WriteLine("Dhcp Address ............................ : " + adress);
            }


            IPHostEntry hostInfo = Dns.GetHostEntry(Environment.MachineName);

            IPAddress[] address = hostInfo.AddressList;

            // Get the alias names of the addresses in the IP address list.
            string[] alias = hostInfo.Aliases;

            Console.WriteLine("Host name : " + hostInfo.HostName);
            Console.WriteLine("\nAliases : ");
            for (int index = 0; index < alias.Length; index++)
            {
                Console.WriteLine(alias[index]);
            }
            Console.WriteLine("\nIP address list : ");
            for (int index = 0; index < address.Length; index++)
            {
                Console.WriteLine(address[index]);
            }

            Console.WriteLine("End of Line");
            Console.ReadKey();

        }

    }
}

