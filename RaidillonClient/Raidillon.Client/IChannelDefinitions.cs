namespace Raidillon.Client
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IChannelDefinitions
    {
        IEnumerable<ChannelDefinition> Channels { get; }
    }
}
