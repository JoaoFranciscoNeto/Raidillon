namespace Raidillon.Client.F12019
{
    using Client;
    using DataStructure;
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

        private readonly List<int> _channelPackets = new List<int>() { 0, 6, 7 };

        public void StartConnection(int port)
        {
            Task.Run(async () =>
            {
                using (var udpClient = new UdpClient(port))
                {
                    while (true)
                    {
                        var receivedResults = await udpClient.ReceiveAsync();

                        var memStream = new MemoryStream(receivedResults.Buffer);
                        var reader = new BinaryReader(memStream);

                        var dataBuffer = receivedResults.Buffer.Skip(23).Take(receivedResults.Buffer.Length - 23).ToArray();

                        var packet = new UdpPacket()
                        {
                            header = PacketProcessor.BuildPacketHeaderFromByteArray(reader), buffer = dataBuffer,
                        };

                        Console.WriteLine(packet.header.m_packetId);
                    }
                }
            });

        }

        private void HandleChannelPacket()
        {

        }


        /*
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
            ParticipantStream = CreateParticipantStream(udpStream);
        }

        public bool EndConnection()
        {
            return true;
        }

        public IObservable<IList<ChannelPacket>> ChannelStream;
        public IObservable<Participants> ParticipantStream;

        private IObservable<IList<ChannelPacket>> CreateChannelStream(IObservable<UdpPacket> udpStream)
        {
            return
                udpStream
                .Where(p => this._channelPackets.Contains(p.header.m_packetId))
                .SelectMany(res => PacketProcessor.ProcessChannelPackets(res.header, res.buffer))
                .GroupBy(p => new { p.Timestamp, p.VehicleId })
                .SelectMany(g => g.TakeUntil(Observable.Timer(TimeSpan.FromMilliseconds(100)))
                .ToList());
        }

        private IObservable<Participants> CreateParticipantStream(IObservable<UdpPacket> udpStream)
        {
            return udpStream
                .Where(p=> p.header.m_packetId.Equals(4))
                .Select(p => PacketProcessor.ProcessParticipantPackets(p.header, p.buffer))
                .DistinctUntilChanged();
        }*/
    }
}
