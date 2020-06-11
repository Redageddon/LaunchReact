using System;
using MidiIO.Devices;

namespace LaunchReact
{
    public static class Devices
    {
        static Devices()
        {
            InputDevice  = InputDevice.InstalledDevices[GetInput()];
            OutputDevice = OutputDevice.InstalledDevices[GetOutput()];

            InputDevice.Open();
            OutputDevice.Open();

            InputDevice.StartReceiving();
        }

        public static InputDevice InputDevice { get; }

        public static OutputDevice OutputDevice { get; }

        private static int GetInput()
        {
            Console.WriteLine("Pick a midi input device.\n");
            for (int i = 0; i < InputDevice.InstalledDevices.Count; i++)
            {
                Console.Write($"{i}: {InputDevice.InstalledDevices[i].Name}\n");
            }

            int option = int.Parse(Console.ReadLine());
            Console.Clear();
            return option;
        }

        private static int GetOutput()
        {
            Console.WriteLine("Pick a midi output device.\n");
            for (int i = 0; i < OutputDevice.InstalledDevices.Count; i++)
            {
                Console.Write($"{i}: {OutputDevice.InstalledDevices[i].Name}\n");
            }

            int option = int.Parse(Console.ReadLine());
            Console.Clear();
            return option;
        }
    }
}