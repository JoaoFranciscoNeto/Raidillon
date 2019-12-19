using Raidillon.Client.DataStructure;
using System.Collections.Generic;

namespace Raidillon.Client
{
    internal static class ChannelReader
    {
        internal static IEnumerable<ChannelPacket> ReadPacket(BasePacket basePacket)
        {
            var timestamp = basePacket.PacketHeader.m_sessionTime;

            switch (basePacket.DataPacket)
            {
                case CarTelemetryPacket carTelemetry:
                    return ReadTelemetryPacket(basePacket.PacketHeader, carTelemetry);
                default:
                    break;
            }

            return null;
        }

        internal static IEnumerable<ChannelPacket> ReadTelemetryPacket(PacketHeader header, CarTelemetryPacket packet)
        {
            var channels = new List<ChannelPacket>();
            /*
            var timestamp = header.m_sessionTime;

            foreach (var vehicleTelem in packet.m_carTelemetryData)
            {
                channels.AddRange(
                    new ChannelPacket[]
                    {
                        new ChannelPacket() { Name = "Speed", Timestamp = timestamp, Value = vehicleTelem.m_speed },
                        new ChannelPacket() { Name = "Throttle", Timestamp = timestamp, Value = vehicleTelem.m_throttle },
                        new ChannelPacket() { Name = "Steer", Timestamp = timestamp, Value = vehicleTelem.m_steer },
                        new ChannelPacket() { Name = "Brake", Timestamp = timestamp, Value = vehicleTelem.m_brake },
                        new ChannelPacket() { Name = "Clutch", Timestamp = timestamp, Value = vehicleTelem.m_clutch },
                        new ChannelPacket() { Name = "NGear", Timestamp = timestamp, Value = vehicleTelem.m_gear },
                        new ChannelPacket() { Name = "NEngine", Timestamp = timestamp, Value = vehicleTelem.m_engineRPM },
                        new ChannelPacket() { Name = "Drs", Timestamp = timestamp, Value = vehicleTelem.m_drs },
                        new ChannelPacket() { Name = "TEngine", Timestamp = timestamp, Value = vehicleTelem.m_engineTemperature },
                    });
            }*/

            return channels;
        }
    }
}
