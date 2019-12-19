namespace Raidillon.Client.F12019
{
    using Raidillon.Client;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Reactive.Linq;
    using System.Reactive.Threading.Tasks;
    using System.Threading.Tasks;

    public class F12019Connection : IConnection
    {
        private static readonly int Port = 20777;

        public IObservable<ChannelPacket> StartConnection()
        {
            //this.ReceiveUDP();

            return ChannelStream();
        }

        public bool EndConnection()
        {
            this.stop = true;

            return true;
        }

        private bool stop = false;



        private void ReceiveUDP()
        {
            Task.Run(() =>
            {
                using (var udpClient = new UdpClient(Port))
                {
                    var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    while (!this.stop)
                    {
                        //IPEndPoint object will allow us to read datagrams sent from any source.
                        var receivedResults = udpClient.Receive(ref remoteEndPoint);
                    }
                }
            });
        }

        private static IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Port);
        public IObservable<ChannelPacket> ChannelStream()
        {
            return Observable.Using(() => new UdpClient(endPoint),
                udpClient => Observable.Defer(() =>
                    udpClient.ReceiveAsync().ToObservable()).Repeat()
                .SelectMany(res => PacketProcessor.ProcessPacket(res.Buffer)));
        }
    }
}
