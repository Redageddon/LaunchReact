namespace MidiIO.Devices
{
    public class Device
    {
        protected Device(string name) => this.Name = name;

        public string Name { get; }
    }
}