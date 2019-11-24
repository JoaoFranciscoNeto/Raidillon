using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient.DataStructure
{
    class MarshalZoneData
    {
        public float m_zoneStart { get; internal set; }   // Fraction (0..1) of way through the lap the marshal zone starts
        public sbyte m_zoneFlag { get; internal set; }    // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
    }
}
