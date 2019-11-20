using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient
{
    class Program
    {
        static void Main(string[] args)
        {
            new TelemetryClient("127.0.0.1", 20777);
        }
    }
}
