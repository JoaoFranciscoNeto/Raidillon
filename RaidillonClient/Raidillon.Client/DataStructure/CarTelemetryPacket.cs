namespace Raidillon.Client.DataStructure
{
    internal class CarTelemetryPacket : DataPacket
    {
        private class CarTelemetryData
        {
            private ushort m_speed { get; set; }                    // Speed of car in kilometres per hour

            private float m_throttle { get; set; }                 // Amount of throttle applied (0.0 to 1.0)

            private float m_steer { get; set; }                    // Steering (-1.0 (full lock left) to 1.0 (full lock right))

            private float m_brake { get; set; }                    // Amount of brake applied (0.0 to 1.0)

            private byte m_clutch { get; set; }                   // Amount of clutch applied (0 to 100)

            private sbyte m_gear { get; set; }                     // Gear selected (1-8, N=0, R=-1)

            private ushort m_engineRPM { get; set; }                // Engine RPM

            private byte m_drs { get; set; }                      // 0 = off, 1 = on

            private byte m_revLightsPercent { get; set; }         // Rev lights indicator (percentage)

            private ushort[] m_brakesTemperature { get; set; }     // Brakes temperature (celsius)

            private ushort[] m_tyresSurfaceTemperature { get; set; } // Tyres surface temperature (celsius)

            private ushort[] m_tyresInnerTemperature { get; set; } // Tyres inner temperature (celsius)

            private ushort m_engineTemperature { get; set; }        // Engine temperature (celsius)

            private float[] m_tyresPressure { get; set; }         // Tyres pressure (PSI)

            private byte[] m_surfaceType { get; set; }           // Driving surface, see appendices 
        }

        private CarTelemetryData[] m_carTelemetryData { get; set; }

        private uint m_buttonStatus { get; set; }
    }
}
