using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient.DataStructure
{
    static class PacketBuilder
    {
        public static BasePacket BuildFromByteArray(byte[] array)
        {
            BinaryReader binaryReader = new BinaryReader(new MemoryStream(array));

            PacketHeader packetHeader = BuildPacketHeaderFromByteArray(binaryReader);

            var packetId = Enum.Parse(typeof(DataEnums.PacketId), packetHeader.m_packetId.ToString());

            Console.WriteLine(packetId);
            switch (packetId)
            {
                case DataEnums.PacketId.Motion:

                    break;
                default:
                    break;
            }

            //Console.WriteLine( TimeSpan.FromSeconds(packetHeader.m_sessionTime));

            return new MotionPacket();
        }

        private static PacketHeader BuildPacketHeaderFromByteArray(BinaryReader binaryReader)
        {
            PacketHeader packetHeader = new PacketHeader();

            packetHeader.m_packetFormat = binaryReader.ReadUInt16();
            packetHeader.m_gameMajorVersion = binaryReader.ReadByte();
            packetHeader.m_gameMinorVersion = binaryReader.ReadByte();
            packetHeader.m_packetVersion = binaryReader.ReadByte();
            packetHeader.m_packetId = binaryReader.ReadByte();
            packetHeader.m_sessionUID = binaryReader.ReadUInt64();
            packetHeader.m_sessionTime = binaryReader.ReadSingle();
            packetHeader.m_frameIdentifier = binaryReader.ReadUInt32();
            packetHeader.m_playerCarIndex = binaryReader.ReadByte();

            return packetHeader;
        }
    }
}
