using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CodeRefactoring
{
    public static class Dhcp
    {
        public static List<string> GetServerAdresses()
        {
            List<string> adressList = new List<string>();

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapteradapterProperties = adapter.GetIPProperties();
                IPAddressCollection addresses = adapteradapterProperties.DhcpServerAddresses;
                if (addresses.Count > 0)
                {
                    adressList.Add(adapter.Description);
                    foreach (IPAddress address in addresses)
                    {
                        adressList.Add(address.ToString());
                    }
                }
            }

            return adressList;
        }

    }
}
