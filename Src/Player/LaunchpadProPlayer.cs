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
            
            FramePlayer player = new FramePlayer
            {
                Fps = 10,
                Frames = new List<Frame>
                {
                    new Frame
                    {
                        Events = new List<MidiEvent>
                        {
                            new MidiEvent(3, 3, 20),
                            new MidiEvent(3, 4, 20),
                            new MidiEvent(4, 3, 20),
                            new MidiEvent(4, 4, 20)
                        }
                    },
                    new Frame
                    {
                        Events = new List<MidiEvent>
                        {
                            new MidiEvent(3, 3, 30),
                            new MidiEvent(3, 4, 30),
                            new MidiEvent(4, 3, 30),
                            new MidiEvent(4, 4, 30)
                        }
                    }
                }
            };
        }

        private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
        {
            Console.WriteLine(e.ToNoteVelocity().ToString());
        }
    }
}