using System;
using MidiIO;
using MidiIO.Messages.Devices.Channels;
using MidiIO.Messages.Devices.Channels.Notes;

namespace LaunchReact
{
    public class LaunchpadProPlayer
    {
        public LaunchpadProPlayer()
        {
            Devices.InputDevice.NoteOn        += this.NoteOn;
            Devices.InputDevice.ControlChange += this.ControlChange;
        }

        private void NoteOn(NoteOnMessage message)
        {
            Devices.OutputDevice.SendNoteOn(Channel.Channel1, message.Note, message.Velocity);
            Console.WriteLine(message.Note);
        }

        private void ControlChange(ControlChangeMessage message)
        {
            Devices.OutputDevice.SendNoteOn(Channel.Channel1, message.Note, message.Velocity);
            Console.WriteLine(message.Note);
        }
    }
}