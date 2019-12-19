using System;
using System.Collections.Generic;
using System.Text;

namespace Raidillon.Client.F12019
{
    class ChannelDefinitions : IChannelDefinitions
    {
        public IEnumerable<ChannelDefinition> Channels { get; } = new List<ChannelDefinition>()
        {
            new ChannelDefinition("Speed", "kmh"),
            new ChannelDefinition("Throttle", "%"),
            new ChannelDefinition("Steer", "%"),
            new ChannelDefinition("Brake", "%"),
            new ChannelDefinition("Clutch", "%"),
            new ChannelDefinition("NGear", "-"),
            new ChannelDefinition("NEngine", "rpm"),
            new ChannelDefinition("Drs", "%"),
            new ChannelDefinition("TEngine", "°C"),
        };
    }
}
