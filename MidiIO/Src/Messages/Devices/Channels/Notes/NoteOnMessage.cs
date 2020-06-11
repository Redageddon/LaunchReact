using MidiIO.CustomIntegers;
using MidiIO.Devices;

namespace MidiIO.Messages.Devices.Channels.Notes
{
    public class NoteOnMessage : NoteMessage, IMessage
    {
        public NoteOnMessage(Device device, Channel channel, UInt7 note, UInt7 velocity)
            : base(device, channel, note, velocity)
        {
        }

        public void SendNow() => ((OutputDevice)this.Device).SendNoteOn(this.Channel, this.Note, this.Velocity);
    }
}