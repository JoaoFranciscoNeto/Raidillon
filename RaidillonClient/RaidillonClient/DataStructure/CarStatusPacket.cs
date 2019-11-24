namespace RaidillonClient.DataStructure
{
    class CarStatusPacket : DataPacket
    {
        public class CarStatusData
        {
            public byte m_tractionControl{ get; internal set;}          // 0 (off) - 2 (high)
            public byte m_antiLockBrakes{ get; internal set;}           // 0 (off) - 1 (on)
            public byte m_fuelMix{ get; internal set;}                  // Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
            public byte m_frontBrakeBias{ get; internal set;}           // Front brake bias (percentage)
            public byte m_pitLimiterStatus{ get; internal set;}         // Pit limiter status - 0 = off, 1 = on
            public float m_fuelInTank{ get; internal set;}               // Current fuel mass
            public float m_fuelCapacity{ get; internal set;}             // Fuel capacity
            public float m_fuelRemainingLaps{ get; internal set;}        // Fuel remaining in terms of laps (value on MFD)
            public ushort m_maxRPM{ get; internal set;}                   // Cars max RPM, point of rev limiter
            public ushort m_idleRPM{ get; internal set;}                  // Cars idle RPM
            public byte m_maxGears{ get; internal set;}                 // Maximum number of gears
            public byte m_drsAllowed{ get; internal set;}               // 0 = not allowed, 1 = allowed, -1 = unknown
            public byte[] m_tyresWear{ get; internal set;}             // Tyre wear percentage
            public byte m_actualTyreCompound{ get; internal set;}    // F1 Modern - 16 = C5, 17 = C4, 18 = C3, 19 = C2, 20 = C1
                                           // 7 = inter, 8 = wet
                                           // F1 Classic - 9 = dry, 10 = wet
                                           // F2 – 11 = super soft, 12 = soft, 13 = medium, 14 = hard
                                           // 15 = wet
            public byte m_tyreVisualCompound{ get; internal set;}       // F1 visual (can be different from actual compound)
                                              // 16 = soft, 17 = medium, 18 = hard, 7 = inter, 8 = wet
                                              // F1 Classic – same as above
                                              // F2 – same as above
            public byte[] m_tyresDamage{ get; internal set;}           // Tyre damage (percentage)
            public byte m_frontLeftWingDamage{ get; internal set;}      // Front left wing damage (percentage)
            public byte m_frontRightWingDamage{ get; internal set;}     // Front right wing damage (percentage)
            public byte m_rearWingDamage{ get; internal set;}           // Rear wing damage (percentage)
            public byte m_engineDamage{ get; internal set;}             // Engine damage (percentage)
            public byte m_gearBoxDamage{ get; internal set;}            // Gear box damage (percentage)
            public sbyte m_vehicleFiaFlags{ get; internal set;}    // -1 = invalid/unknown, 0 = none, 1 = green
                                       // 2 = blue, 3 = yellow, 4 = red
            public float m_ersStoreEnergy{ get; internal set;}           // ERS energy store in Joules
            public byte m_ersDeployMode{ get; internal set;}            // ERS deployment mode, 0 = none, 1 = low, 2 = medium
                                              // 3 = high, 4 = overtake, 5 = hotlap
            public float m_ersHarvestedThisLapMGUK{ get; internal set;}  // ERS energy harvested this lap by MGU-K
            public float m_ersHarvestedThisLapMGUH{ get; internal set;}  // ERS energy harvested this lap by MGU-H
            public float m_ersDeployedThisLap{ get; internal set;}       // ERS energy deployed this lap
        }

        public CarStatusData[] m_carStatusData { get; internal set; }
    }
}
