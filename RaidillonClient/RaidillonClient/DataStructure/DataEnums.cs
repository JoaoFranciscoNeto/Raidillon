using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient.DataStructure
{
    static class DataEnums
    {
        internal enum PacketId
        {
            Motion = 0,
            Session = 1,
            LapData = 2,
            Event = 3,
            Participants = 4,
            CarSetups = 5,
            CarTelemetry = 6,
            CarStatus = 7,
        }
    }
}
