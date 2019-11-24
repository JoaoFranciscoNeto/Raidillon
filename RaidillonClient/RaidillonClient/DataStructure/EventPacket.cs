using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient.DataStructure
{
    class EventPacket : DataPacket
    {
        public abstract class EventData
        {
            public byte vehicleIdx { get; internal set; }
        }

        public class FastestLap : EventData
        {
            public float lapTime { get; internal set; }
        }

        public class Retirement : EventData { }
        public class TeamMateInPits : EventData { }
        public class RaceWinner : EventData { }

        public byte[] m_eventStringCode { get; internal set; }
        public EventData m_eventDetails { get; internal set; }
    }
}
