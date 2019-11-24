using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient.DataStructure
{
    class LapData
    {
        public float m_lastLapTime { get; internal set; }            // Last lap time in seconds
        public float m_currentLapTime { get; internal set; } // Current time around the lap in seconds
        public float m_bestLapTime { get; internal set; }        // Best lap time of the session in seconds
        public float m_sector1Time { get; internal set; }        // Sector 1 time in seconds
        public float m_sector2Time { get; internal set; }        // Sector 2 time in seconds
        public float m_lapDistance { get; internal set; }        // Distance vehicle is around current lap in metres – could
                                                                 // be negative if line hasn’t been crossed yet
        public float m_totalDistance { get; internal set; }      // Total distance travelled in session in metres – could
                                                                 // be negative if line hasn’t been crossed yet
        public float m_safetyCarDelta { get; internal set; }        // Delta in seconds for safety car
        public byte m_carPosition { get; internal set; }    // Car race position
        public byte m_currentLapNum { get; internal set; }      // Current lap number
        public byte m_pitStatus { get; internal set; }              // 0 = none, 1 = pitting, 2 = in pit area
        public byte m_sector { get; internal set; }                 // 0 = sector1, 1 = sector2, 2 = sector3
        public byte m_currentLapInvalid { get; internal set; }      // Current lap invalid - 0 = valid, 1 = invalid
        public byte m_penalties { get; internal set; }              // Accumulated time penalties in seconds to be added
        public byte m_gridPosition { get; internal set; }           // Grid position the vehicle started the race in
        public byte m_driverStatus { get; internal set; }           // Status of driver - 0 = in garage, 1 = flying lap
                                                                    // 2 = in lap, 3 = out lap, 4 = on track
        public byte m_resultStatus { get; internal set; }          // Result status - 0 = invalid, 1 = inactive, 2 = active
                                       // 3 = finished, 4 = disqualified, 5 = not classified
                                       // 6 = retired
    }
}
