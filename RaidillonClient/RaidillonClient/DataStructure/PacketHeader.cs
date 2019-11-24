using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RaidillonClient.DataStructure.DataEnums;

namespace RaidillonClient.DataStructure
{
    class PacketHeader : DataPacket
    {
        public ushort m_packetFormat { get; internal set; }          // 2019
        public byte m_gameMajorVersion { get; internal set; }       // Game major version - "X.00"
        public byte m_gameMinorVersion { get; internal set; }       // Game minor version - "1.XX"
        public byte m_packetVersion { get; internal set; }          // Version of this packet type, all start from 1
        public PacketId m_packetId { get; internal set; }               // Identifier for the packet type, see below
        public ulong m_sessionUID { get; internal set; }             // Unique identifier for the session
        public float m_sessionTime { get; internal set; }            // Session timestamp
        public uint m_frameIdentifier { get; internal set; }         // Identifier for the frame the data was retrieved on
        public byte m_playerCarIndex { get; internal set; }         // Index of player's car in the array

        public override string ToString()
        {
            return $"{m_packetId} - {m_sessionTime}";
        }
    }
}
