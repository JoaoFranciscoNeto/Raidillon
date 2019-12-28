namespace Raidillon.Client.F12019
{
    using Raidillon.Client;
    using Raidillon.Client.DataStructure;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Reactive.Threading.Tasks;
    using System.Threading.Tasks;

    public class F12019Connection
    {
        public void StartConnection(int port)
        {
            var endPoint = new IPEndPoint(IPAddress.Any, port);

            var udpStream = Observable.Using(() => new UdpClient(endPoint),
                udpServer =>
                Observable.Defer(() =>
                    Observable
                    .FromAsync(() => udpServer.ReceiveAsync()))
                .Repeat())
                .Select(res =>
                {
                    var memStream = new MemoryStream(res.Buffer);
                    var reader = new BinaryReader(memStream);

                    var dataBuffer = res.Buffer.Skip(23).Take(res.Buffer.Length - 23).ToArray();

                    return new UdpPacket()
                    {
                        header = PacketProcessor.BuildPacketHeaderFromByteArray(reader),
                        buffer = dataBuffer,
                    };
                });

            ChannelStream = CreateChannelStream(udpStream);
        }

        public bool EndConnection()
        {
            return true;
        }

        public IObservable<IList<ChannelPacket>> ChannelStream;
        public IObservable<Participants> ParticipantStream;

        private List<int> channelPackets = new List<int>() { 0, 6, 7 };

        private IObservable<IList<ChannelPacket>> CreateChannelStream(IObservable<UdpPacket> udpStream)
        {

            return
                udpStream
                .Where(p => this.channelPackets.Contains(p.header.m_packetId))
                .SelectMany(res => PacketProcessor.ProcessChannelPackets(res.header, res.buffer))
                .GroupBy(p => new { p.Timestamp, p.VehicleId })
                .SelectMany(g => g.TakeUntil(Observable.Timer(TimeSpan.FromMilliseconds(100)))
                .ToList());
        }

        private IObservable<Participants> CreateParticipantStream(IObservable<UdpPacket> udpStream)
        {
            return null;
        }
    }
}
