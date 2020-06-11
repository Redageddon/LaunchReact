using MidiIO.CustomIntegers;
using MidiIO.Devices;

namespace MidiIO.Messages.Devices.Channels
{
    public class ControlChangeMessage : ChannelMessage, IMessage
    {
        public ControlChangeMessage(Device device, Channel channel, UInt7 note, UInt7 velocity)
            : base(device, channel)
        {
            this.Note  = note;
            this.Velocity = velocity;
        }

        public UInt7 Note { get; }

        public UInt7 Velocity { get; }

        public void SendNow() => ((OutputDevice)this.Device).SendControlChange(this.Channel, this.Note, this.Velocity);
    }
}