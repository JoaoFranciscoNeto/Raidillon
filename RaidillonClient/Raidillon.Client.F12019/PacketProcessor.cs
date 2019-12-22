﻿using System.Collections.Generic;
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
            for (var vIndex = 0; vIndex < 20; vIndex++)
            {
                packets.Add(new ChannelPacket(time, vIndex, "Speed", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "Throttle", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "Steer", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "Brake", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "Clutch", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "Gear", reader.ReadSByte()));
                packets.Add(new ChannelPacket(time, vIndex, "NEngine", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "DRS", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "RevLights", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "TBrakesRL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TBrakesRR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TBrakesFL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TBrakesFR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TTyreSurfsRL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TTyreSurfsRR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TTyreSurfsFL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TTyreSurfsFR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TTyreInnersRL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TTyreInnersRR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TTyreInnersFL", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TTyreInnersFR", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "TEngine", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "PTyresRL", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "PTyresRR", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "PTyresFL", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "PTyresFR", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "SurfTyresRL", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "SurfTyresRR", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "SurfTyresFL", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "SurfTyresFR", reader.ReadByte()));
            }
            return packets;
        }

        private static List<ChannelPacket> ReadCarStatusPacket(BinaryReader reader, float time)
        {
            var packets = new List<ChannelPacket>();
            for (var vIndex = 0; vIndex < 20; vIndex++)
            {
                packets.Add(new ChannelPacket(time, vIndex, "TractionControl", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "AntiLockBrakes", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "FuelMix", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "FrontBrakeBias", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "PitLimiter", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "FuelInTank", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "FuelCapacity", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "FuelRemainingLaps", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "MaxRPM", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "IdleRPM", reader.ReadUInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "MaxGear", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "DRSAllowed", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "TyresWearRL", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "TyresWearRR", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "TyresWearFL", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "TyresWearFR", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "TyreCompound", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "VisualTyreCompound", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "TyresDamageRL", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "TyresDamageRR", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "TyresDamageFL", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "TyresDamageFR", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "FrontLeftWingDamage", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "FrontRightWingDamage", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "RearWingDamage", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "EngineDamage", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "GearBoxDamage", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "FIAFlags", reader.ReadSByte()));
                packets.Add(new ChannelPacket(time, vIndex, "ERSStored", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "ERSMode", reader.ReadByte()));
                packets.Add(new ChannelPacket(time, vIndex, "ERSHarvestedLapMGUK", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "ERSHarvestedLapMGUH", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "ERSDeployedLap", reader.ReadSingle()));
            }
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