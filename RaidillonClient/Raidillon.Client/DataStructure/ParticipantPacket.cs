using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raidillon.Client.DataStructure
{
    class ParticipantPacket : DataPacket
    {
        public class ParticipantData
        {
            public byte m_aiControlled { get; internal set; }           // Whether the vehicle is AI (1) or Human (0) controlled
            public byte m_driverId { get; internal set; }       // Driver id - see appendix
            public byte m_teamId { get; internal set; }                 // Team id - see appendix
            public byte m_raceNumber { get; internal set; }             // Race number of the car
            public byte m_nationality { get; internal set; }            // Nationality of the driver
            public byte[] m_name { get; internal set; }               // Name of participant in UTF-8 format – null terminated
                                                // Will be truncated with … (U+2026) if too long
            public byte m_yourTelemetry { get; internal set; }          // The player's UDP setting, 0 = restricted, 1 = public
        }

        public byte m_numActiveCar { get; internal set; }

        public ParticipantData[] m_participants { get; internal set; }
    }
}
