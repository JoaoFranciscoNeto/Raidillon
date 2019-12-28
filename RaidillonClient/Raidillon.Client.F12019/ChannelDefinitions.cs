using System;
using System.Collections.Generic;
using System.Text;

namespace Raidillon.Client.F12019
{
    public static class ChannelDefinitions
    {
        public static IEnumerable<ChannelDefinition> Channels { get; } = new List<ChannelDefinition>()
        {
            new ChannelDefinition("Speed", "kmh", 0, 400),
            new ChannelDefinition("Throttle", "%", 0, 1),
            new ChannelDefinition("Steer", "%", 0, 1),
            new ChannelDefinition("Brake", "%", 0, 1),
            new ChannelDefinition("Clutch", "%", 0, 1),
            new ChannelDefinition("NGear", "-", 0, 8),
            new ChannelDefinition("NEngine", "rpm", 0, 15000),
            new ChannelDefinition("Drs", "%", 0, 100),
            new ChannelDefinition("TEngine", "°C", 0, 200),
        };
    }
}
