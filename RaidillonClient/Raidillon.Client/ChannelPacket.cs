namespace Raidillon.Client
{
    public class ChannelPacket
    {
        public ChannelPacket(double timestamp, int vehicleId, string name, double value)
        {
            this.Value = value;
            this.Name = name;
            this.Timestamp = timestamp;
            this.VehicleId = vehicleId;
        }

        public double Value { get;  set; }

        public string Name { get;  set; }

        public double Timestamp { get; set; }

        public int VehicleId { get; set; }

        public override string ToString()
        {
            return $"{this.Timestamp,10} {this.Name,20} {this.Value,20}";
        }
    }
}
