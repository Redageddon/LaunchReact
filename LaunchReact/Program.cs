using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MidiIO;
using MidiIO.CustomIntegers;

namespace LaunchReact
{
    public static class Program
    {
        public static async Task Main()
        {
            new LaunchpadProPlayer();
            SetConsoleCtrlHandler(OnAppExit);
            await Task.Delay(-1);
        }

        [DllImport("Kernel32")]
        private static extern void SetConsoleCtrlHandler(Action a);

        private static void OnAppExit()
        {
            for (UInt7 i = 0; i < 127; i++)
            {
                Devices.OutputDevice.SendNoteOff(Channel.Channel1, i, 0);
            }
        }
    }
}