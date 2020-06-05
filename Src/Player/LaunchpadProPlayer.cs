using System;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;

namespace LaunchReact
{
    public class LaunchpadProPlayer
    {
        public LaunchpadProPlayer()
        {
            Devices.InputDevice.EventReceived += this.OnEventReceived;
            Devices.InputDevice.StartEventsListening();
        }

        private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
        {
            Console.WriteLine(e.ToNoteVelocity().ToString());

            Frame frame = new Frame
            {
                Events = new List<MidiEvent>
                {
                    new MidiEvent(3, 3, 20),
                    new MidiEvent(3, 4, 20),
                    new MidiEvent(4, 3, 20),
                    new MidiEvent(4, 4, 20)
                }
            };

            List<NoteOnEvent> events = frame.GetNoteOnEvents();

            foreach (NoteOnEvent noteOnEvent in events)
            {
                Devices.OutputDevice.SendEvent(noteOnEvent);
            }
        }
    }
}