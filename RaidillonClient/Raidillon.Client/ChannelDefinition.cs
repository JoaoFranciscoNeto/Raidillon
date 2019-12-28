using System;

namespace Raidillon.Client
{
    public class ChannelDefinition
    {
        private string name;
        private string units;
        private Tuple<int, int> range;

        public string Units { get => this.units; internal set => this.units = value; }

        public string Name { get => this.name; internal set => this.name = value; }

        public Tuple<int,int> Range { get => this.range; internal set => this.range = value; }

        public ChannelDefinition(string name, string units, int min, int max)
        {
            this.name = name;
            this.units = units;
            this.range = new Tuple<int, int>(min, max);
        }

        public override bool Equals(object obj)
        {
            var other = (ChannelDefinition)obj;

            if (other == null)
                return false;

            return this.name.Equals(other.name, StringComparison.OrdinalIgnoreCase)
                && this.units.Equals(other.units, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{this.name,20} {this.units,-5}";
        }
    }
}
