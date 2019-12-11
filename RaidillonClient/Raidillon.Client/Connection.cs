// <copyright file="Connection.cs" company="FlyingPeacock">
// Copyright (c) FlyingPeacock. All rights reserved.
// </copyright>

namespace Raidillon.Client
{
    using Raidillon.Client.DataStructure;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Text;

    public class Connection
    {
        public static Connection Connect(int port)
        {
            return new Connection(port);
        }

        IPEndPoint endPoint;

        private Connection(int port)
        {
            this.port = port;
            endPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        int port;

        bool on;

        public event EventHandler OnMotionPacketReceived;

        public event EventHandler OnSessionUpdated;

        public event EventHandler OnLapDataPacketReceived;

        public event EventHandler OnEventPacketReceived;

        // Session start end?

        public event EventHandler OnParticipantsChanged;

        public event EventHandler OnCarSetupPacketReceived;

        public event EventHandler OnCarTelemetryPacketReceived;

        public event EventHandler OnCarStatusPacketReceived;

        public void Start()
        {
            this.on = true;
            this.ReceiveMessages();
        }

        private void ReceiveMessages()
        {
            using (var udpClient = new UdpClient(this.port))
            {
                double speed = 0.0;


                while (this.on)
                {
                    var received = udpClient.Receive(ref this.endPoint);
                    var packet = PacketBuilder.BuildFromByteArray(received);


                }
            }
        }

    }
}
