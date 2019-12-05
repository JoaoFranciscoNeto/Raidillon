using RaidillonClient.DataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient
{
    class TelemetryClient
    {
        int port;

        Dictionary<Type, int> packets;

        public TelemetryClient(string ip, int port)
        {
            this.port = port;

            this.Connect();
        }
        private void Connect()
        {
            packets = new Dictionary<Type, int>();
            foreach (var item in typeof(DataPacket).Assembly.GetTypes().Where(t=>t.IsSubclassOf(typeof(DataPacket))))
            {
                packets.Add(item, 0);
            }
            using (var udpClient = new UdpClient(this.port))
            {
                while (true)
                {
                    var remoteEndpoint = new IPEndPoint(IPAddress.Any, 0);
                    var received = udpClient.Receive(ref remoteEndpoint);

                    //Console.WriteLine($"Message: {received.Length} bytes");

                    var packet = PacketBuilder.BuildFromByteArray(received);

                    packets[packet.DataPacket.GetType()]++;

                    Console.WriteLine(string.Join("\t",packets.Values));
                }
            }
        }
    }
}
