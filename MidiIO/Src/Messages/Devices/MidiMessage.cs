using MidiIO.CustomIntegers;
using MidiIO.Devices;

namespace MidiIO.Messages.Devices
{
    public class MidiMessage : DeviceMessage
    {
        public MidiMessage(Device device, Channel channel, UInt7 note, UInt7 velocity)
            : base(device)
        {
            this.Channel = channel;
            this.Note = note;
            this.Velocity = velocity;
        }

        public Channel Channel { get; }
        
        public UInt7 Note { get; }

        public UInt7 Velocity { get; }
    }
}