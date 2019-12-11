namespace Raidillon.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Raidillon.Client;
    using Raidillon.Client.DataStructure;
    using System.Linq;

    [TestClass]
    public class TelemetryTest
    {
        [TestInitialize]
        public void TestInit()
        {

        }

        [TestMethod]
        public void ThatCanGetChannelsFromPacket()
        {
            var packetHeader = new PacketHeader()
            {
                m_sessionTime = 20,
            };

            var telem = new CarTelemetryPacket()
            {
                m_carTelemetryData = new CarTelemetryPacket.CarTelemetryData[]
                {
                    new CarTelemetryPacket.CarTelemetryData()
                    {
                        m_speed = 20,
                        m_throttle = 10,
                        m_brake = 0,
                        m_steer = 0,
                        m_clutch = 0,
                        m_gear = 2,
                        m_engineRPM = 2000,
                        m_drs = 0,
                        m_revLightsPercent = 40,
                        m_brakesTemperature = new ushort[4]
                        {
                            60,60,60,60,
                        },
                        m_tyresSurfaceTemperature = new ushort[4]
                        {
                            60,60,60,60,
                        },
                        m_tyresPressure = new float[4]
                        {
                            2,2,2,2,
                        },
                        m_engineTemperature = 120,
                        m_surfaceType  = new byte[4]
                        {
                            0,0,0,0,
                        },
                        m_tyresInnerTemperature  = new ushort[4]
                        {
                            60,60,60,60,
                        },
                    }
                }
            };

            var packet = new BasePacket()
            {
                PacketHeader = packetHeader,
                DataPacket = telem,
            };

            var channels = ChannelReader.ReadPacket(packet);

            Assert.IsTrue(channels.Any());
        }
    }
}
