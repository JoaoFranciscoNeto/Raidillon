namespace Client.Example
{
    using Raidillon.Client;
    using Raidillon.Client.F12019;
    using System;
    using System.Reactive;
    using System.Reactive.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var telemetryObserver = new MyConsoleObserver<ChannelPacket>();

            F12019Connection connection = new Raidillon.Client.F12019.F12019Connection();

            var stream = connection.StartConnection();

            //stream.Subscribe(Console.WriteLine);

            Console.WriteLine("Subscribing");
            stream
                .GroupBy(
                    p => new { p.Timestamp, p.VehicleId })
                 .SelectMany(g => g.TakeUntil(Observable.Timer(TimeSpan.FromSeconds(1))).ToList())
                .Subscribe( o=>
                {
                    Console.WriteLine(o[0].Timestamp + " " + o[0].VehicleId);
                });
            

            Console.ReadLine();
        }
    }

    public class MyConsoleObserver<T> : IObserver<T>
    {
        public void OnNext(T value)
        {
            Console.WriteLine("Received value {0}", value);
        }
        public void OnError(Exception error)
        {
            Console.WriteLine("Sequence faulted with {0}", error);
        }
        public void OnCompleted()
        {
            Console.WriteLine("Sequence terminated");
        }
    }
}
