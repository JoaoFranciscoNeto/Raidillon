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
            var packet = new BasePacket();

            packet.PacketHeader = BuildPacketHeaderFromByteArray(binaryReader);

            var packetId = Enum.Parse(typeof(DataEnums.PacketId), packet.PacketHeader.m_packetId.ToString());
            switch (packetId)
            {
                case DataEnums.PacketId.Motion:
                    packet.DataPacket = BuildMotionPacketFromByteArray(binaryReader);
                    break;
                case DataEnums.PacketId.Session:
                    packet.DataPacket = BuildSessionPacketFromByteArray(binaryReader);
                    break;
                default:
                    return null;
            }

            binaryReader.Dispose();
            return packet;
        }

        private static PacketHeader BuildPacketHeaderFromByteArray(BinaryReader binaryReader)
        {
            return new PacketHeader
            {
                m_packetFormat = binaryReader.ReadUInt16(),
                m_gameMajorVersion = binaryReader.ReadByte(),
                m_gameMinorVersion = binaryReader.ReadByte(),
                m_packetVersion = binaryReader.ReadByte(),
                m_packetId =  binaryReader.ReadByte(),
                m_sessionUID = binaryReader.ReadUInt64(),
                m_sessionTime = binaryReader.ReadSingle(),
                m_frameIdentifier = binaryReader.ReadUInt32(),
                m_playerCarIndex = binaryReader.ReadByte()
            };
        }

        private static MotionPacket BuildMotionPacketFromByteArray(BinaryReader binaryReader)
        {
            var packet = new MotionPacket();
            packet.m_carMotionData = new CarMotionData[MotionPacket.nCars];

            for (int carIndex = 0; carIndex < MotionPacket.nCars; carIndex++)
            {
                packet.m_carMotionData[carIndex] = new CarMotionData
                {
                    m_worldPositionX = binaryReader.ReadSingle(),
                    m_worldPositionY = binaryReader.ReadSingle(),
                    m_worldPositionZ = binaryReader.ReadSingle(),
                    m_worldVelocityX = binaryReader.ReadSingle(),
                    m_worldVelocityY = binaryReader.ReadSingle(),
                    m_worldVelocityZ = binaryReader.ReadSingle(),
                    m_worldForwardDirX = binaryReader.ReadInt16(),
                    m_worldForwardDirY = binaryReader.ReadInt16(),
                    m_worldForwardDirZ = binaryReader.ReadInt16(),
                    m_worldRightDirX = binaryReader.ReadInt16(),
                    m_worldRightDirY = binaryReader.ReadInt16(),
                    m_worldRightDirZ = binaryReader.ReadInt16(),
                    m_gForceLateral = binaryReader.ReadSingle(),
                    m_gForceLongitudinal = binaryReader.ReadSingle(),
                    m_gForceVertical = binaryReader.ReadSingle(),
                    m_yaw = binaryReader.ReadSingle(),
                    m_pitch = binaryReader.ReadSingle(),
                    m_roll = binaryReader.ReadSingle()
                };
            }

            packet.m_suspensionPosition = new float[MotionPacket.nPoints];
            for (int point = 0; point < MotionPacket.nPoints; point++)
            {
                packet.m_suspensionPosition[point] = binaryReader.ReadSingle();
            }

            packet.m_suspensionVelocity = new float[MotionPacket.nPoints];
            for (int point = 0; point < MotionPacket.nPoints; point++)
            {
                packet.m_suspensionVelocity[point] = binaryReader.ReadSingle();
            }

            packet.m_suspensionAcceleration = new float[MotionPacket.nPoints];
            for (int point = 0; point < MotionPacket.nPoints; point++)
            {
                packet.m_suspensionAcceleration[point] = binaryReader.ReadSingle();
            }

            packet.m_wheelSpeed = new float[MotionPacket.nPoints];
            for (int point = 0; point < MotionPacket.nPoints; point++)
            {
                packet.m_wheelSpeed[point] = binaryReader.ReadSingle();
            }

            packet.m_wheelSlip = new float[MotionPacket.nPoints];
            for (int point = 0; point < MotionPacket.nPoints; point++)
            {
                packet.m_wheelSlip[point] = binaryReader.ReadSingle();
            }

            packet.m_localVelocityX = binaryReader.ReadSingle();
            packet.m_localVelocityY = binaryReader.ReadSingle();
            packet.m_localVelocityZ = binaryReader.ReadSingle();
            packet.m_angularVelocityX = binaryReader.ReadSingle();
            packet.m_angularVelocityY = binaryReader.ReadSingle();
            packet.m_angularVelocityZ = binaryReader.ReadSingle();
            packet.m_angularAccelerationX = binaryReader.ReadSingle();
            packet.m_angularAccelerationY = binaryReader.ReadSingle();
            packet.m_angularAccelerationZ = binaryReader.ReadSingle();
            packet.m_frontWheelsAngle = binaryReader.ReadSingle();

            return packet;
        }

        private static SessionPacket BuildSessionPacketFromByteArray(BinaryReader binaryReader)
        {
            var packet = new SessionPacket();

            packet.m_weather = binaryReader.ReadByte();
            packet.m_trackTemperature = binaryReader.ReadSByte();
            packet.m_airTemperature = binaryReader.ReadSByte();
            packet.m_totalLaps = binaryReader.ReadByte();
            packet.m_trackLength = binaryReader.ReadUInt16();
            packet.m_sessionType = binaryReader.ReadByte();
            packet.m_trackId = binaryReader.ReadSByte();
            packet.m_formula = binaryReader.ReadByte();
            packet.m_sessionTimeLeft = binaryReader.ReadUInt16();
            packet.m_sessionDuration = binaryReader.ReadUInt16();
            packet.m_pitSpeedLimit = binaryReader.ReadByte();
            packet.m_gamePaused = binaryReader.ReadByte();
            packet.m_isSpectating = binaryReader.ReadByte();
            packet.m_sliProNativeSupport = binaryReader.ReadByte();
            packet.m_numMarshalZones = binaryReader.ReadByte();

            packet.m_marshalZones = new MarshalZoneData[21];
            for (int i = 0; i < 21; i++)
            {
                packet.m_marshalZones[i] = new MarshalZoneData()
                {
                    m_zoneStart = binaryReader.ReadSingle(),
                    m_zoneFlag = binaryReader.ReadSByte(),
                };
            }

            packet.m_safetyCarStatus = binaryReader.ReadByte();
            packet.m_networkGame = binaryReader.ReadByte();

            return packet;
        }

    }
}
