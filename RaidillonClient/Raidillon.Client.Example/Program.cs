namespace Client.Example
{
    using Raidillon.Client;
    using Raidillon.Client.F12019;
    using System;
    using System.Collections.Generic;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Linq;
    using Raidillon.Client.DataStructure;

    class Program
    {
        static void Main(string[] args)
        {
            var connection = new F12019Connection();
            connection.StartConnection(20777);

            /*
            var stream = connection.ChannelStream;



            stream.Subscribe(o =>
            {
                foreach (var item in o)
                {
                    Console.WriteLine(item);
                }
            });*/


            Participants par = null;

            var stream = connection.ParticipantStream;
            stream.Subscribe(p =>
            {
                par = p;
                Console.WriteLine(p.nParticipants);
                foreach (var item in p.participants)
                {
                    Console.WriteLine("\t"+item.Name);
                }
            });


            Console.ReadLine();
        }
    }
}
