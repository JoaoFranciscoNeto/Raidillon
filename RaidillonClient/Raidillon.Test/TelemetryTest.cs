namespace Raidillon.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Raidillon.Client;
    using Raidillon.Client.DataStructure;
    using System.Diagnostics;
    using System.Linq;
    using System.Reactive.Linq;

    [TestClass]
    public class TelemetryTest
    {
        [TestInitialize]
        public void TestInit()
        {

        }

        [TestMethod]
        public void ThatCanGroupByTimestamp()
        {
            PacketProcessor observer = new PacketProcessor();
            observer.SendPacket(new ChannelPacket() { });

        }
    }
}
