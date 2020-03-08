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

        public PingAnswer LocalPing()
        {
            IPAddress address = IPAddress.Loopback;
            return this.Ping(address);
        }

        public PingAnswer Ping(object address)
        {
            
            // Ping's the local machine.
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(Convert.ToString( address ));

            if (reply.Status == IPStatus.Success)
            {
                
                return new PingAnswer(
                        reply.Status.ToString(),
                        reply.Address,
                        reply.RoundtripTime,
                        reply.Options.Ttl,
                        reply.Options.DontFragment,
                        reply.Buffer.Length
                    );
            }
            else
            {
                //Error
                return new PingAnswer(
                        reply.Status.ToString()
                    );
            }
        }

    }
}
