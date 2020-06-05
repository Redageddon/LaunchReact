using System;
using Melanchall.DryWetMidi.Devices;

namespace LaunchReact
{
    public static class Devices
    {
        public static InputDevice  InputDevice  { get; } = InputDevice.GetById(GetOption("input"));
        public static OutputDevice OutputDevice { get; } = OutputDevice.GetById(GetOption("output"));

        private static int GetOption(string optionName)
        {
            Console.WriteLine("Pick a midi " + optionName + " device.\n");
            foreach (InputDevice device in InputDevice.GetAll())
            {
                Console.Write($"{device.Id}: {device}\n");
            }

            int option = int.Parse(Console.ReadLine());
            Console.Clear();
            return option;
        }
    }
}