using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient.DataStructure
{
    class SessionPacket : DataPacket
    {
        enum Weather
        {
            Clear = 0,
            LightCloud = 1,
            Overcast = 2,
            LightRain = 3,
            HeavyRain = 4,
            Storm = 5,
        }

        enum SessionType
        {
            Unknown = 0,
            P1 = 1,
            P2 = 2,
            P3 = 3,
            ShortP = 4,
            Q1 = 5,
            Q2 = 6,
            Q3 = 7,
            ShortQ = 8,
            OneShotQ = 9,
            Race = 10,
            Race2 = 11,
            TimeTrial = 12,
        }

        enum Track
        {
            Melbourne = 0,
            PaulRicard = 1,
            Shanghai = 2,
            Sakhir = 3,
            Catalunya = 4,
            Monaco = 5,
            Montreal = 6,
            Silverstone = 7,
            Hockenheiim = 8,
            Hungaroring = 9,
            Spa = 10,
            Monza = 11,
            MarinaBay = 12,
            Suzuka = 13,
            YasMarina = 14,
            CircuitOfTheAmericas = 15,
            Interlagos = 16,
            RedBullRing = 17,
            Sochi = 18,
            HermanosRodriguez = 19,
            Baku = 20,
            SakhirShort = 21,
            SilverstoneShort = 22,
            CircuitOfTheAmericasShort = 23,
            SuzukaShort = 24,
        }

        enum Formula
        {
            F1Modern = 0,
            F1Classic = 1,
            F2 = 2,
            F1Generic = 3,
        }

        public byte m_weather { get; internal set; }                // Weather - 0 = clear, 1 = light cloud, 2 = overcast
                                                                    // 3 = light rain, 4 = heavy rain, 5 = storm
        public sbyte m_trackTemperature { get; internal set; }        // Track temp. in degrees celsius
        public sbyte m_airTemperature { get; internal set; }          // Air temp. in degrees celsius
        public byte m_totalLaps { get; internal set; }              // Total number of laps in this race
        public ushort m_trackLength { get; internal set; }               // Track length in metres
        public byte m_sessionType { get; internal set; }            // 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P
                                                                    // 5 = Q1, 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ
                                                                    // 10 = R, 11 = R2, 12 = Time Trial
        public sbyte m_trackId { get; internal set; }                 // -1 for unknown, 0-21 for tracks, see appendix
        public byte m_formula { get; internal set; }                    // Formula, 0 = F1 Modern, 1 = F1 Classic, 2 = F2,
                                                                        // 3 = F1 Generic
        public ushort m_sessionTimeLeft { get; internal set; }       // Time left in session in seconds
        public ushort m_sessionDuration { get; internal set; }       // Session duration in seconds
        public byte m_pitSpeedLimit { get; internal set; }          // Pit speed limit in kilometres per hour
        public byte m_gamePaused { get; internal set; }                // Whether the game is paused
        public byte m_isSpectating { get; internal set; }           // Whether the player is spectating
        public byte m_spectatorCarIndex { get; internal set; }      // Index of the car being spectated
        public byte m_sliProNativeSupport { get; internal set; }    // SLI Pro support, 0 = inactive, 1 = active
        public byte m_numMarshalZones { get; internal set; }            // Number of marshal zones to follow
        public MarshalZoneData[] m_marshalZones { get; internal set; }             // List of marshal zones – max 21
        public byte m_safetyCarStatus { get; internal set; }           // 0 = no safety car, 1 = full safety car, 2 = virtual safety car
        public byte m_networkGame { get; internal set; }               // 0 = offline, 1 = online
    }
}
