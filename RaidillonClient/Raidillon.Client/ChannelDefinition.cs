namespace Raidillon.Client
{
    public class ChannelDefinition
    {
        private string name;
        private string units;

        public string Units { get => this.units; internal set => this.units = value; }

        public string Name { get => this.name; internal set => this.name = value; }

        public ChannelDefinition(string name, string units)
        {
            this.name = name;
            this.units = units;
        }

        public override bool Equals(object obj)
        {
            var other = (ChannelDefinition)obj;

            return this.name.Equals(other.name)
                && this.units.Equals(other.units);
        }

        public override string ToString()
        {
            return $"{this.name,20} {this.units,-5}";
        }
    }
}
