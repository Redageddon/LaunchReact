using System;
using MidiIO;
using MidiIO.Messages.Devices;

namespace LaunchReact
{
    public class LaunchpadProPlayer
    {
        public LaunchpadProPlayer()
        {
            Devices.InputDevice.NoteOn        += this.NoteOn;
        }

        private void NoteOn(MidiMessage midiMessage)
        {
            Devices.OutputDevice.SendNoteOn(Channel.Channel1, midiMessage.Note, midiMessage.Velocity);
            Console.WriteLine(midiMessage.Note);
        }
    }
}