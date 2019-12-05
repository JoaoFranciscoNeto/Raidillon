// <copyright file="BasePacket.cs" company="FlyingPeacock">
// Copyright (c) FlyingPeacock. All rights reserved.
// </copyright>

namespace Raidillon.Client.DataStructure
{
    public class BasePacket
    {
        public PacketHeader PacketHeader { get; internal set; }

        public DataPacket DataPacket { get; internal set; }
    }
}
