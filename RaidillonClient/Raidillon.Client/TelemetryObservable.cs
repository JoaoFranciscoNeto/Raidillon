using System;
using System.Collections.Generic;
using System.Text;

namespace Raidillon.Client
{
    class TelemetryObservable : IObservable<ChannelPacket>
    {
        public IDisposable Subscribe(IObserver<ChannelPacket> observer)
        {
            throw new NotImplementedException();
        }
    }
}
