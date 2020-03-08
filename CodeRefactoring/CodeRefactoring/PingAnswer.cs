using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CodeRefactoring
{
    public class PingAnswer
    {
        public string Reply { get; private set; }
        public bool Success { get; private set; } = true;
        public IPAddress Address { get; private set; }
        public long RoundTripTime { get; private set; }
        public int TTL { get; private set; }
        public bool DontFragment { get; private set; }
        public int BufferSize { get; private set; }

        public PingAnswer(string reply, IPAddress address, long roundTripTime, int tTL, bool dontFragment, int bufferSize)
        {
            Reply = reply;
            Address = address;
            RoundTripTime = roundTripTime;
            TTL = tTL;
            DontFragment = dontFragment;
            BufferSize = bufferSize;
        }

        public PingAnswer(string reply)
        {
            Reply = reply;
            Success = false;
        }
    }
}
