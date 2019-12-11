namespace Raidillon.Client
{
    using System.Collections.Generic;
    using System.Linq;

    public class ChannelDefinitions
    {
        public static IEnumerable<ChannelDefinition> Channels = new List<ChannelDefinition>()
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

        public static IEnumerable<string> ChannelNames;

        static ChannelDefinitions()
        {
            ChannelNames = Channels.Select(c => c.Name);
        }
    }
}
