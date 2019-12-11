using Raidillon.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            var connection = Connection.Connect(20777);


            connection.OnMotionPacketReceived += Connection_OnMotionPacketReceived;

            connection.Start();
            */

            foreach (var item in ChannelDefinitions.Channels)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        private static void Connection_OnMotionPacketReceived(object sender, EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            var packet = ((PacketEventArgs)e).Packet;

            Console.WriteLine(packet.PacketHeader.m_frameIdentifier);
        }
    }
}
