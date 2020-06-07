using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;

namespace LaunchReact
{
    public static class Program
    {
        [DllImport("Kernel32")]
        private static extern void SetConsoleCtrlHandler(Action a);

        public static async Task Main()
        {
            new LaunchpadProPlayer();
            SetConsoleCtrlHandler(OnAppExit);
            await Task.Delay(-1);
        }

        private static void OnAppExit()
        {
            NoteOnEvent noteOnEvent = new NoteOnEvent(SevenBitNumber.MinValue, SevenBitNumber.MinValue);
            foreach (int note in GlobalVariables.AllNotes)
            {
                noteOnEvent.NoteNumber = new SevenBitNumber((byte) note);
                Devices.OutputDevice.SendEvent(noteOnEvent);
            }
        }
    }
}