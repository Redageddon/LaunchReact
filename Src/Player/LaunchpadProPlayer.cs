using System;
using System.IO;
using System.Text.Json;
using Melanchall.DryWetMidi.Devices;

namespace LaunchReact
{
    public class LaunchpadProPlayer
    {
        public LaunchpadProPlayer()
        {
            Devices.InputDevice.EventReceived += this.OnEventReceived;
            Devices.InputDevice.StartEventsListening();
            
            FramePlayer player = JsonSerializer.Deserialize<FramePlayer>(File.ReadAllText("AAA.txt"));
            player.StartPlayingFrames();
        }

        private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
        {
            Console.WriteLine(e.ToNoteVelocity().Note);
        }
    }
}