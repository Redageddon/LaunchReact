using System;
using System.Runtime.InteropServices;

namespace MidiIO.Win32Api
{
    internal static partial class Api
    {
        public readonly struct HandleMidiIn
        {
            private readonly IntPtr handle;
        }

        public readonly struct HandleMidiOut
        {
            private readonly IntPtr handle;
        }

        public struct MidiInCapabilities
        {
            private ushort manufacturerId;
            private uint   driverVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string Name;
        }

        public struct MidiOutCapabilities
        {
            private ushort manufacturerId;
            private uint   driverVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string Name;
        }
    }
}