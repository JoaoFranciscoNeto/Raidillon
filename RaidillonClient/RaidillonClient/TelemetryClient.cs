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

        public TelemetryClient(string ip, int port)
        {
            this.port = port;

            this.Connect();
        }
        private void Connect()
        {
            using (var udpClient = new UdpClient(this.port))
            {
                while (true)
                {
                    var remoteEndpoint = new IPEndPoint(IPAddress.Any, 0);
                    var received = udpClient.Receive(ref remoteEndpoint);

                    //Console.WriteLine($"Message: {received.Length} bytes");

                    var packet = PacketBuilder.BuildFromByteArray(received);
                }
            }
        }


        public T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }
    }
}
