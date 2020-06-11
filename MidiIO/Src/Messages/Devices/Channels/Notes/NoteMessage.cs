using MidiIO.CustomIntegers;
using MidiIO.Devices;

namespace MidiIO.Messages.Devices.Channels.Notes
{
    public abstract class NoteMessage : ChannelMessage
    {
        protected NoteMessage(Device device, Channel channel, UInt7 note, UInt7 velocity)
            : base(device, channel)
        {
            this.Note     = note;
            this.Velocity = velocity;
        }

        public UInt7 Note { get; }

        public UInt7 Velocity { get; }
    }
}