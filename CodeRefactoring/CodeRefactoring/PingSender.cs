using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CodeRefactoring
{
    public class PingSender
    {
        public IPAddress Address { get; private set; }
        public long RoundTripTime { get; private set; }
        public int TTL { get; private set; }
        public bool DontFragment { get; private set; }
        public int BufferSize { get; private set; }

        public string[] LocalPing()
        {
            string[] pingArray = new string[5];
            // Ping's the local machine.
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Loopback;
            PingReply reply = pingSender.Send(address);

            if (reply.Status == IPStatus.Success)
            {
                this.Address = reply.Address;
                pingArray[1] = "RoundTrip time: " + reply.RoundtripTime;
                pingArray[2] = "Time to live: " + reply.Options.Ttl;
                pingArray[3] = "Don't fragment: " + reply.Options.DontFragment;
                pingArray[4] = "Buffer size: " + reply.Buffer.Length;
            }
            else
            {
                pingArray[0] = reply.Status.ToString();
            }

            return pingArray;
        }

    }
}
