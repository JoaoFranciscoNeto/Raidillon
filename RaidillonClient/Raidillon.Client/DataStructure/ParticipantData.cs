using System;
using System.Collections.Generic;
using System.Text;

namespace Raidillon.Client.DataStructure
{
    public class ParticipantData : IEquatable<ParticipantData>
    {
        public int AIControlled;
        public int DriverId;
        public int TeamId;
        public int RaceNumber;
        public int Nationality;
        public string Name;
        public int TelemetryEnabled;

        public override bool Equals(object obj)
        {
            return obj is ParticipantData data &&
                   this.AIControlled == data.AIControlled &&
                   this.DriverId == data.DriverId &&
                   this.TeamId == data.TeamId &&
                   this.RaceNumber == data.RaceNumber &&
                   this.Nationality == data.Nationality &&
                   this.Name == data.Name &&
                   this.TelemetryEnabled == data.TelemetryEnabled;
        }

        public bool Equals(ParticipantData other)
        {
            return other != null &&
                   this.AIControlled == other.AIControlled &&
                   this.DriverId == other.DriverId &&
                   this.TeamId == other.TeamId &&
                   this.RaceNumber == other.RaceNumber &&
                   this.Nationality == other.Nationality &&
                   this.Name == other.Name &&
                   this.TelemetryEnabled == other.TelemetryEnabled;
        }

        public override int GetHashCode()
        {
            var hashCode = 1687001225;
            hashCode = hashCode * -1521134295 + this.AIControlled.GetHashCode();
            hashCode = hashCode * -1521134295 + this.DriverId.GetHashCode();
            hashCode = hashCode * -1521134295 + this.TeamId.GetHashCode();
            hashCode = hashCode * -1521134295 + this.RaceNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + this.Nationality.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Name);
            hashCode = hashCode * -1521134295 + this.TelemetryEnabled.GetHashCode();
            return hashCode;
        }
    }

    public class Participants : IEquatable<Participants>
    {
        public int nParticipants;

        public ParticipantData[] participants;

        public override bool Equals(object obj)
        {
            if (obj is Participants participants)
            {
                if (this.nParticipants.Equals(participants.nParticipants))
                {
                    bool sameParticipants = true;
                    for (int i = 0; i < this.nParticipants; i++)
                    {
                        sameParticipants = sameParticipants && (this.participants[i].Equals(participants.participants[i]));
                    }
                    return sameParticipants;
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

        public bool Equals(Participants other)
        {
            if (this.nParticipants.Equals(other.nParticipants))
            {
                bool sameParticipants = true;
                for (int i = 0; i < this.nParticipants; i++)
                {
                    sameParticipants = sameParticipants && (this.participants[i].Equals(other.participants[i]));
                }
                return sameParticipants;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -1202958022;
            hashCode = hashCode * -1521134295 + this.nParticipants.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ParticipantData[]>.Default.GetHashCode(this.participants);
            return hashCode;
        }
    }

    internal class ParticipantsComparer : IEqualityComparer<Participants>
    {
        public bool Equals(Participants x, Participants y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(Participants obj)
        {
            throw new NotImplementedException();
        }
    }
}
