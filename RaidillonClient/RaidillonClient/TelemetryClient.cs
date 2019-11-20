using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static RaidillonClient.DataStructure.TelemetryDataStructures;

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

                    Console.WriteLine($"Message: {received.Length} bytes");

                    var packet = ReadPacketHeader(received);
                    PacketId id = (PacketId)Enum.ToObject(typeof(PacketId), packet.m_packetId);
                    Console.WriteLine($"{id}");


                }
            }
        }

        private PacketHeader ReadPacketHeader(byte[] data)
        {
            GCHandle pinnedPacket = GCHandle.Alloc(data, GCHandleType.Pinned);
            PacketHeader packet = (PacketHeader)Marshal.PtrToStructure(
                pinnedPacket.AddrOfPinnedObject(),
                typeof(PacketHeader));
            pinnedPacket.Free();
            return packet;
        }
    }
}
