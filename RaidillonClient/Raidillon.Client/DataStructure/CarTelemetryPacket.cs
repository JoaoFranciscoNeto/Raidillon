namespace Raidillon.Client.DataStructure
{
    internal class CarTelemetryPacket : DataPacket
    {
        internal class CarTelemetryData
        {
            internal ushort m_speed { get; set; }                    // Speed of car in kilometres per hour

            internal float m_throttle { get; set; }                 // Amount of throttle applied (0.0 to 1.0)

            internal float m_steer { get; set; }                    // Steering (-1.0 (full lock left) to 1.0 (full lock right))

            internal float m_brake { get; set; }                    // Amount of brake applied (0.0 to 1.0)

            internal byte m_clutch { get; set; }                   // Amount of clutch applied (0 to 100)

            internal sbyte m_gear { get; set; }                     // Gear selected (1-8, N=0, R=-1)

            internal ushort m_engineRPM { get; set; }                // Engine RPM

            internal byte m_drs { get; set; }                      // 0 = off, 1 = on

            internal byte m_revLightsPercent { get; set; }         // Rev lights indicator (percentage)

            internal ushort[] m_brakesTemperature { get; set; }     // Brakes temperature (celsius)

            internal ushort[] m_tyresSurfaceTemperature { get; set; } // Tyres surface temperature (celsius)

            internal ushort[] m_tyresInnerTemperature { get; set; } // Tyres inner temperature (celsius)

            internal ushort m_engineTemperature { get; set; }        // Engine temperature (celsius)

            internal float[] m_tyresPressure { get; set; }         // Tyres pressure (PSI)

            internal byte[] m_surfaceType { get; set; }           // Driving surface, see appendices 
        }

        internal CarTelemetryData[] m_carTelemetryData { get; set; }

        internal uint m_buttonStatus { get; set; }
    }
}
