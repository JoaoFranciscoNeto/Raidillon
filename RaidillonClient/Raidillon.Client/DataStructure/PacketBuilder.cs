﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raidillon.Client.DataStructure
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
                case DataEnums.PacketId.LapData:
                    packet.DataPacket = BuildLapPacketFromByteArray(binaryReader);
                    break;
                case DataEnums.PacketId.Event:
                    packet.DataPacket = BuildEventPacketFromByteArray(binaryReader);
                    break;
                case DataEnums.PacketId.Participants:
                    packet.DataPacket = BuildParticipantPacketFromByteArray(binaryReader);
                    break;
                case DataEnums.PacketId.CarSetups:
                    packet.DataPacket = BuildCarSetupPacketFromByteArray(binaryReader);
                    break;
                case DataEnums.PacketId.CarTelemetry:
                    packet.DataPacket = BuildCarTelemetryPacketFromByteArray(binaryReader);
                    break;
                case DataEnums.PacketId.CarStatus:
                    packet.DataPacket = BuildCarStatusPacketFromByteArray(binaryReader);
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

        private static LapPacket BuildLapPacketFromByteArray(BinaryReader binaryReader)
        {
            var packet = new LapPacket();

            packet.m_lapData = new LapData[20];

            for (int i = 0; i < 20; i++)
            {
                packet.m_lapData[i] = new LapData()
                {
                    m_lastLapTime = binaryReader.ReadSingle(),
                    m_currentLapTime = binaryReader.ReadSingle(),
                    m_bestLapTime = binaryReader.ReadSingle(),
                    m_sector1Time = binaryReader.ReadSingle(),
                    m_sector2Time = binaryReader.ReadSingle(),
                    m_lapDistance = binaryReader.ReadSingle(),
                    m_totalDistance = binaryReader.ReadSingle(),
                    m_safetyCarDelta = binaryReader.ReadSingle(),
                    m_carPosition = binaryReader.ReadByte(),
                    m_currentLapNum = binaryReader.ReadByte(),
                    m_pitStatus = binaryReader.ReadByte(),
                    m_sector = binaryReader.ReadByte(),
                    m_currentLapInvalid = binaryReader.ReadByte(),
                    m_penalties = binaryReader.ReadByte(),
                    m_gridPosition = binaryReader.ReadByte(),
                    m_driverStatus = binaryReader.ReadByte(),
                    m_resultStatus = binaryReader.ReadByte(),
                };
            }

            return packet;
        }

        private static EventPacket BuildEventPacketFromByteArray(BinaryReader binaryReader)
        {
            var packet = new EventPacket();

            packet.m_eventStringCode = binaryReader.ReadBytes(4);

            switch (Encoding.Default.GetString(packet.m_eventStringCode))
            {
                case "FTLP":
                    packet.m_eventDetails = new EventPacket.FastestLap()
                    {
                        vehicleIdx = binaryReader.ReadByte(),
                        lapTime = binaryReader.ReadSingle(),
                    };
                    break;
                case "RTMT":
                    packet.m_eventDetails = new EventPacket.Retirement()
                    {
                        vehicleIdx = binaryReader.ReadByte(),
                    };
                    break;
                case "TMPT":
                    packet.m_eventDetails = new EventPacket.FastestLap()
                    {
                        vehicleIdx = binaryReader.ReadByte(),
                    };
                    break;
                case "RCWN":
                    packet.m_eventDetails = new EventPacket.FastestLap()
                    {
                        vehicleIdx = binaryReader.ReadByte(),
                    };
                    break;

                default:
                    break;
            }

            return packet;
        }

        private static ParticipantPacket BuildParticipantPacketFromByteArray(BinaryReader binaryReader)
        {
            var packet = new ParticipantPacket();

            packet.m_numActiveCar = binaryReader.ReadByte();

            packet.m_participants = new ParticipantPacket.ParticipantData[20];
            for (int i = 0; i < 20; i++)
            {
                packet.m_participants[i] = new ParticipantPacket.ParticipantData()
                {
                    m_aiControlled = binaryReader.ReadByte(),
                    m_driverId = binaryReader.ReadByte(),
                    m_teamId = binaryReader.ReadByte(),
                    m_raceNumber = binaryReader.ReadByte(),
                    m_nationality = binaryReader.ReadByte(),
                    m_name = binaryReader.ReadBytes(48),
                    m_yourTelemetry = binaryReader.ReadByte(),
                };
            }

            return packet;
        }

        private static CarSetupPacket BuildCarSetupPacketFromByteArray(BinaryReader binaryReader)
        {
            var packet = new CarSetupPacket();

            packet.m_carSetups = new CarSetupPacket.CarSetupData[20];
            for (int i = 0; i < 20; i++)
            {
                packet.m_carSetups[i] = new CarSetupPacket.CarSetupData()
                {
                    m_frontWing = binaryReader.ReadByte(),
                    m_rearWing = binaryReader.ReadByte(),
                    m_onThrottle = binaryReader.ReadByte(),
                    m_offThrottle = binaryReader.ReadByte(),
                    m_frontCamber = binaryReader.ReadByte(),
                    m_rearCamber = binaryReader.ReadByte(),
                    m_frontToe = binaryReader.ReadByte(),
                    m_rearToe = binaryReader.ReadByte(),
                    m_frontSuspension = binaryReader.ReadByte(),
                    m_rearSuspension = binaryReader.ReadByte(),
                    m_frontAntiRollBar = binaryReader.ReadByte(),
                    m_rearAntiRollBar = binaryReader.ReadByte(),
                    m_frontSuspensionHeight = binaryReader.ReadByte(),
                    m_rearSuspensionHeight = binaryReader.ReadByte(),
                    m_brakePressure = binaryReader.ReadByte(),
                    m_brakeBias = binaryReader.ReadByte(),
                    m_frontTyrePressure = binaryReader.ReadSingle(),
                    m_rearTyrePressure = binaryReader.ReadSingle(),
                    m_ballast = binaryReader.ReadByte(),
                    m_fuelLoad = binaryReader.ReadSingle(),
                };
            }

            return packet;
        }

        private static CarTelemetryPacket BuildCarTelemetryPacketFromByteArray(BinaryReader binaryReader)
        {
            var packet = new CarTelemetryPacket();

            packet.m_carTelemetryData = new CarTelemetryPacket.CarTelemetryData[20];
            for (int i = 0; i < 20; i++)
            {
                packet.m_carTelemetryData[i] = new CarTelemetryPacket.CarTelemetryData()
                {
                    m_speed = binaryReader.ReadUInt16(),
                    m_throttle = binaryReader.ReadSingle(),
                    m_steer = binaryReader.ReadSingle(),
                    m_brake = binaryReader.ReadSingle(),
                    m_clutch = binaryReader.ReadByte(),
                    m_gear = binaryReader.ReadSByte(),
                    m_engineRPM = binaryReader.ReadUInt16(),
                    m_drs = binaryReader.ReadByte(),
                    m_revLightsPercent = binaryReader.ReadByte(),
                    m_brakesTemperature = new ushort[4],
                    m_tyresSurfaceTemperature = new ushort[4],
                    m_tyresInnerTemperature = new ushort[4],
                    m_tyresPressure = new float[4],
                    m_surfaceType = new byte[4],
                };

                for (int j = 0; j < 4; j++)
                {
                    packet.m_carTelemetryData[i].m_brakesTemperature[j] = binaryReader.ReadUInt16();
                }

                for (int j = 0; j < 4; j++)
                {
                    packet.m_carTelemetryData[i].m_tyresSurfaceTemperature[j] = binaryReader.ReadUInt16();
                }

                for (int j = 0; j < 4; j++)
                {
                    packet.m_carTelemetryData[i].m_tyresInnerTemperature[j] = binaryReader.ReadUInt16();
                }

                packet.m_carTelemetryData[i].m_engineTemperature = binaryReader.ReadUInt16();

                for (int j = 0; j < 4; j++)
                {
                    packet.m_carTelemetryData[i].m_tyresPressure[j] = binaryReader.ReadSingle();
                }

                packet.m_carTelemetryData[i].m_surfaceType = binaryReader.ReadBytes(4);
            }

            return packet;
        }

        private static CarStatusPacket BuildCarStatusPacketFromByteArray(BinaryReader binaryReader)
        {
            var packet = new CarStatusPacket();

            packet.m_carStatusData = new CarStatusPacket.CarStatusData[20];
            for (int i = 0; i < 20; i++)
            {
                packet.m_carStatusData[i] = new CarStatusPacket.CarStatusData()
                {
                    m_tractionControl = binaryReader.ReadByte(),
                    m_antiLockBrakes = binaryReader.ReadByte(),
                    m_fuelMix = binaryReader.ReadByte(),
                    m_frontBrakeBias = binaryReader.ReadByte(),
                    m_pitLimiterStatus = binaryReader.ReadByte(),
                    m_fuelInTank = binaryReader.ReadSingle(),
                    m_fuelCapacity = binaryReader.ReadSingle(),
                    m_fuelRemainingLaps = binaryReader.ReadSingle(),
                    m_maxRPM = binaryReader.ReadUInt16(),
                    m_idleRPM = binaryReader.ReadUInt16(),
                    m_maxGears = binaryReader.ReadByte(),
                    m_drsAllowed = binaryReader.ReadByte(),
                    m_tyresWear = binaryReader.ReadBytes(4),
                    m_actualTyreCompound = binaryReader.ReadByte(),
                    m_tyreVisualCompound = binaryReader.ReadByte(),
                    m_tyresDamage = binaryReader.ReadBytes(4),
                    m_frontLeftWingDamage = binaryReader.ReadByte(),
                    m_frontRightWingDamage = binaryReader.ReadByte(),
                    m_rearWingDamage = binaryReader.ReadByte(),
                    m_engineDamage = binaryReader.ReadByte(),
                    m_gearBoxDamage = binaryReader.ReadByte(),
                    m_vehicleFiaFlags = binaryReader.ReadSByte(),
                    m_ersStoreEnergy = binaryReader.ReadSingle(),
                    m_ersDeployMode = binaryReader.ReadByte(),
                    m_ersHarvestedThisLapMGUK = binaryReader.ReadSingle(),
                    m_ersHarvestedThisLapMGUH = binaryReader.ReadSingle(),
                    m_ersDeployedThisLap = binaryReader.ReadSingle(),
                };
            }

            return packet;
        }
    }
}
