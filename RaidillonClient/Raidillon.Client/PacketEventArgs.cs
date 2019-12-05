// <copyright file="PacketEventArgs.cs" company="FlyingPeacock">
// Copyright (c) FlyingPeacock. All rights reserved.
// </copyright>

namespace Raidillon.Client
{
    using System;
    using Raidillon.Client.DataStructure;

    public class PacketEventArgs : EventArgs
    {
        public BasePacket Packet { get; internal set; }
    }
}
