using System;
using System.Collections.Generic;
using System.Text;

namespace Raidillon.Client.DataStructure
{
    public class ParticipantData
    {
        bool AIControlled;
        int DriverId;
        int TeamId;
        int RaceNumber;
        int Nationality;
        string Name;
        bool TelemetryEnabled;
    }

    public class Participants
    {
        int nParticipants;

        ParticipantData[] participants;
    }
}
