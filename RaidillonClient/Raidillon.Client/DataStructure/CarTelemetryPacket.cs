using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raidillon.Client.DataStructure
{
    class CarTelemetryPacket : DataPacket
    {
        public class CarTelemetryData
        {
            public ushort m_speed { get; internal set; }                    // Speed of car in kilometres per hour
            public float m_throttle { get; internal set; }                 // Amount of throttle applied (0.0 to 1.0)
            public float m_steer { get; internal set; }                    // Steering (-1.0 (full lock left) to 1.0 (full lock right))
            public float m_brake { get; internal set; }                    // Amount of brake applied (0.0 to 1.0)
            public byte m_clutch { get; internal set; }                   // Amount of clutch applied (0 to 100)
            public sbyte m_gear { get; internal set; }                     // Gear selected (1-8, N=0, R=-1)
            public ushort m_engineRPM { get; internal set; }                // Engine RPM
            public byte m_drs { get; internal set; }                      // 0 = off, 1 = on
            public byte m_revLightsPercent { get; internal set; }         // Rev lights indicator (percentage)
            public ushort[] m_brakesTemperature { get; internal set; }     // Brakes temperature (celsius)
            public ushort[] m_tyresSurfaceTemperature { get; internal set; } // Tyres surface temperature (celsius)
            public ushort[] m_tyresInnerTemperature { get; internal set; } // Tyres inner temperature (celsius)
            public ushort m_engineTemperature { get; internal set; }        // Engine temperature (celsius)
            public float[] m_tyresPressure { get; internal set; }         // Tyres pressure (PSI)
            public byte[] m_surfaceType { get; internal set; }           // Driving surface, see appendices 
        }

        public CarTelemetryData[] m_carTelemetryData { get; internal set; }
        public uint m_buttonStatus { get; internal set; }
    }
}
