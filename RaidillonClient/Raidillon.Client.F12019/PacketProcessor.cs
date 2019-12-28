using Raidillon.Client.DataStructure;
using System.Collections.Generic;
using System.IO;

namespace Raidillon.Client.F12019
{
    internal static partial class PacketProcessor
    {
        internal static Participants ProcessParticipantPackets(PacketHeader header, byte[] buffer)
        {
            var binaryReader = new BinaryReader(new MemoryStream(buffer));

            int nParticipants = binaryReader.ReadByte();
            List<ParticipantData> pData = new List<ParticipantData>();
            for (int i = 0; i < nParticipants; i++)
            {
                pData.Add(new ParticipantData()
                {
                    AIControlled = binaryReader.ReadByte(),
                    DriverId = binaryReader.ReadByte(),
                    TeamId = binaryReader.ReadByte(),
                    RaceNumber = binaryReader.ReadByte(),
                    Nationality = binaryReader.ReadByte(),
                    Name = System.Text.Encoding.UTF8.GetString(binaryReader.ReadBytes(48)),
                    TelemetryEnabled = binaryReader.ReadByte(),
                });
            }

            return new Participants()
            {
                nParticipants = nParticipants,
                participants = pData.ToArray(),
            };
        }

        internal static List<ChannelPacket> ProcessChannelPackets(PacketHeader header, byte[] buffer)
        {
            var channelPackets = new List<ChannelPacket>();

            var binaryReader = new BinaryReader(new MemoryStream(buffer));
            //var packet = BuildPacketHeaderFromByteArray(binaryReader);
            var timestamp = header.m_sessionTime;
            switch (header.m_packetId)
            {
                case 0:
                    channelPackets.AddRange(ReadMotionPacket(binaryReader, timestamp));
                    break;

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

        private static List<ChannelPacket> ReadMotionPacket(BinaryReader reader, float time)
        {
            var packets = new List<ChannelPacket>();
            for (var vIndex = 0; vIndex < 20; vIndex++)
            {
                packets.Add(new ChannelPacket(time, vIndex, "WorldPosX", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldPosY", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldPosZ", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldVelX", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldVelY", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldVelZ", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldFwdX", reader.ReadInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldFwdY", reader.ReadInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldFwdZ", reader.ReadInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldRytX", reader.ReadInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldRytY", reader.ReadInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "WorldRytZ", reader.ReadInt16()));
                packets.Add(new ChannelPacket(time, vIndex, "GForceX", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "GForceY", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "GForceZ", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "Yaw", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "Pitch", reader.ReadSingle()));
                packets.Add(new ChannelPacket(time, vIndex, "Roll", reader.ReadSingle()));
            }

            return packets;
        }

        internal static PacketHeader BuildPacketHeaderFromByteArray(BinaryReader binaryReader)
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
    }
}