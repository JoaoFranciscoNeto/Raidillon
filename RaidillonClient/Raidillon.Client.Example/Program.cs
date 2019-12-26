namespace Client.Example
{
    using Raidillon.Client;
    using Raidillon.Client.F12019;
    using System;
    using System.Collections.Generic;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var connection = new F12019Connection();

            var stream = connection.StartConnection(20777);

            stream.Subscribe(o =>
            {
                
            });


            Console.ReadLine();
        }
    }
}
