using MidiIO.CustomIntegers;
using MidiIO.Devices;

namespace MidiIO.Messages.Devices.Channels.Notes
{
    public class NoteOffMessage : NoteMessage, IMessage
    {
        public NoteOffMessage(Device device, Channel channel, UInt7 note, UInt7 velocity)
            : base(device, channel, note, velocity)
        {
        }

        public void SendNow() => ((OutputDevice)this.Device).SendNoteOff(this.Channel, this.Note, this.Velocity);
    }
}