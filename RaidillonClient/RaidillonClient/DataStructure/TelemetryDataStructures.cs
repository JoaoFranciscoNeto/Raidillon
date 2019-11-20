using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient.DataStructure
{
    class TelemetryDataStructures
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PacketHeader
        {
            public ushort m_packetFormat;          // 2019
            public sbyte m_gameMajorVersion;       // Game major version - "X.00"
            public sbyte m_gameMinorVersion;       // Game minor version - "1.XX"
            public sbyte m_packetVersion;          // Version of this packet type, all start from 1
            public sbyte m_packetId;               // Identifier for the packet type, see below
            public ulong m_sessionUID;             // Unique identifier for the session
            public float m_sessionTime;            // Session timestamp
            public uint m_frameIdentifier;         // Identifier for the frame the data was retrieved on
            public sbyte m_playerCarIndex;         // Index of player's car in the array
        }

        public enum PacketId
        {
            Motion,
            Session,
            LapData,
            Event,
            Participants,
            CarSetups,
            CarTelemetry,
            CarStatus
        }
    }
}
