using System.Collections.Generic;
using Melanchall.DryWetMidi.Devices;

namespace LaunchReact
{
    public class LaunchpadProPlayer
    {
        public LaunchpadProPlayer()
        {
            Devices.InputDevice.EventReceived += this.OnEventReceived;
            Devices.InputDevice.StartEventsListening();

            //Todo: chang this so that it loads from file
            FramePlayer player = new FramePlayer
            (
                5,
                new List<Frame>
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
                    },
                    new Frame
                    {
                        Events = new List<MidiEvent>
                        {
                            new MidiEvent(3, 3, 40),
                            new MidiEvent(3, 4, 40),
                            new MidiEvent(4, 3, 40),
                            new MidiEvent(4, 4, 40)
                        }
                    },
                    new Frame
                    {
                        Events = new List<MidiEvent>
                        {
                            new MidiEvent(3, 3, 50),
                            new MidiEvent(3, 4, 50),
                            new MidiEvent(4, 3, 50),
                            new MidiEvent(4, 4, 50)
                        }
                    },
                    new Frame
                    {
                        Events = new List<MidiEvent>
                        {
                            new MidiEvent(3, 3, 60),
                            new MidiEvent(3, 4, 60),
                            new MidiEvent(4, 3, 60),
                            new MidiEvent(4, 4, 60)
                        }
                    }
                }
            );
            player.StartPlayingFrames();
        }

        private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
        {
            //Console.WriteLine(e.ToNoteVelocity().ToString());
        }
    }
}