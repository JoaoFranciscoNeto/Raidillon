using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raidillon.Client.DataStructure
{
    class LapPacket : DataPacket
    {
        public LapData[] m_lapData { get; internal set; }        // Lap data for all cars on track
    }
}
