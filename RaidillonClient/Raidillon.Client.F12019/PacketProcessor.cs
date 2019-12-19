using System.Collections.Generic;
using System.IO;

namespace Raidillon.Client.F12019
{
    internal static class PacketProcessor
    {
        internal static List<ChannelPacket> ProcessPacket(byte[] buffer)
        {
            var channelPackets = new List<ChannelPacket>();

            var binaryReader = new BinaryReader(new MemoryStream(buffer));
            var packet = BuildPacketHeaderFromByteArray(binaryReader);
            var timestamp = packet.m_sessionTime;
            switch (packet.m_packetId)
            {
                case 6:

                    channelPackets.AddRange(ReadTelemPacket(binaryReader, timestamp));
                    break;

                case 7:

                    channelPackets.AddRange(ReadCarStatusPacket(binaryReader, timestamp));
                    break;

                default:
                    break;
            }

            return channelPackets;
        }

        private static List<ChannelPacket> ReadTelemPacket(BinaryReader reader, float time)
        {
            var packets = new List<ChannelPacket>();
            for (var i = 0; i < 20; i++)
            {
                packets.Add(new ChannelPacket(time, i, "Speed", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "Throttle", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, i, "Steer", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, i, "Brake", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, i, "Clutch", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, i, "Gear", reader.ReadSByte()));
                packets.Add(new ChannelPacket(time, i, "NEngine", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "DRS", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, i, "RevLights", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, i, "TBrakesRL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TBrakesRR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TBrakesFL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TBrakesFR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TTyreSurfsRL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TTyreSurfsRR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TTyreSurfsFL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TTyreSurfsFR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TTyreInnersRL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TTyreInnersRR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TTyreInnersFL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TTyreInnersFR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "TEngine", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, i, "PTyresRL", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, i, "PTyresRR", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, i, "PTyresFL", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, i, "PTyresFR", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, i, "SurfTyresRL", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, i, "SurfTyresRR", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, i, "SurfTyresFL", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, i, "SurfTyresFR", reader.ReadByte()));
            }
            return packets;
        }

        private static List<ChannelPacket> ReadCarStatusPacket(BinaryReader reader, float time)
        {
            var packets = new List<ChannelPacket>();

            return packets;
        }

        private static PacketHeader BuildPacketHeaderFromByteArray(BinaryReader binaryReader)
        {
            return new PacketHeader
            {
                m_packetFormat = binaryReader.ReadUInt16(),
                m_gameMajorVersion = binaryReader.ReadByte(),
                m_gameMinorVersion = binaryReader.ReadByte(),
                m_packetVersion = binaryReader.ReadByte(),
                m_packetId = binaryReader.ReadByte(),
                m_sessionUID = binaryReader.ReadUInt64(),
                m_sessionTime = binaryReader.ReadSingle(),
                m_frameIdentifier = binaryReader.ReadUInt32(),
                m_playerCarIndex = binaryReader.ReadByte(),
            };
        }

        public class PacketHeader
        {
            public ushort m_packetFormat { get; internal set; }          // 2019
            public byte m_gameMajorVersion { get; internal set; }       // Game major version - "X.00"
            public byte m_gameMinorVersion { get; internal set; }       // Game minor version - "1.XX"
            public byte m_packetVersion { get; internal set; }          // Version of this packet type, all start from 1
            public byte m_packetId { get; internal set; }               // Identifier for the packet type, see below
            public ulong m_sessionUID { get; internal set; }             // Unique identifier for the session
            public float m_sessionTime { get; internal set; }            // Session timestamp
            public uint m_frameIdentifier { get; internal set; }         // Identifier for the frame the data was retrieved on
            public byte m_playerCarIndex { get; internal set; }         // Index of player's car in the array

        }
    }
}