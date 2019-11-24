using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient.DataStructure
{
    class BasePacket
    {
        public PacketHeader PacketHeader { get; internal set; }
        public DataPacket DataPacket { get; internal set; }
    }
}
