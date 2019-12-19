// <copyright file="Connection.cs" company="FlyingPeacock">
// Copyright (c) FlyingPeacock. All rights reserved.
// </copyright>

namespace Raidillon.Client
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Reactive.Linq;

    public interface IConnection
    {
        IObservable<ChannelPacket> StartConnection();

        bool EndConnection();
    }
}
