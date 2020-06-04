using System;
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
            Console.WriteLine($"Note: {e.ToNoteVelocity().Note}, Velocity: {e.ToNoteVelocity().Velocity}");
        }
    }
}