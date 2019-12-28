namespace Raidillon.Client.F12019
{
    using Raidillon.Client;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Reactive.Linq;
    using System.Reactive.Threading.Tasks;
    using System.Threading.Tasks;

    public class F12019Connection
    {
        public IObservable<IList<ChannelPacket>> StartConnection(int port)
        {
            this.port = port;

            return ChannelStream();
        }

        public bool EndConnection()
        {
            return true;
        }


        private int port;
        public IObservable<IList<ChannelPacket>> ChannelStream()
        {
            var endPoint = new IPEndPoint(IPAddress.Any, port);
            return Observable.Using(() => new UdpClient(endPoint),
                udpClient => Observable.Defer(() =>
                    udpClient.ReceiveAsync().ToObservable()).Repeat()
                .SelectMany(res => PacketProcessor.ProcessPacket(res.Buffer)))
                .GroupBy(
                    p => new { p.Timestamp, p.VehicleId })
                .SelectMany(g => g.TakeUntil(Observable.Timer(TimeSpan.FromMilliseconds(10))).ToList());
        }
    }
}
