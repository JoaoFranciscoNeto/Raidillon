using System;
using System.Collections.Generic;
using System.Text;

namespace Raidillon.Client
{
    public class ChannelPacket
    {
        public double Value { get; internal set; }

        public string Name { get; internal set; }

        public float Timestamp { get; internal set; }
    }
}
