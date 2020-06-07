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


            Console.ReadLine();
        }
    }
}
