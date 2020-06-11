using System;
using System.Runtime.InteropServices;

namespace MidiIO.Win32Api
{
    internal static partial class Api
    {
        private const string DllName = "winmm.dll";

        [DllImport(DllName, SetLastError = true)]
        public static extern uint midiInGetNumDevs();

        [DllImport(DllName, SetLastError = true)]
        public static extern uint midiOutGetNumDevs();

        [DllImport(DllName, SetLastError = true)]
        public static extern int midiInClose(HandleMidiIn hMidiIn);

        [DllImport(DllName, SetLastError = true)]
        public static extern int midiInStart(HandleMidiIn hMidiIn);

        [DllImport(DllName, SetLastError = true)]
        public static extern int midiInStop(HandleMidiIn hMidiIn);

        [DllImport(DllName, SetLastError = true)]
        public static extern int midiOutShortMsg(HandleMidiOut hmo, uint dwMsg);

        [DllImport(DllName, SetLastError = true)]
        private static extern void midiInGetDevCaps(UIntPtr uDeviceId, out MidiInCapabilities caps, uint cbMidiInCaps);

        [DllImport(DllName, SetLastError = true)]
        private static extern void midiOutGetDevCaps(UIntPtr uDeviceId, out MidiOutCapabilities caps, uint cbMidiOutCaps);

        [DllImport(DllName, SetLastError = true)]
        private static extern int midiInOpen(
            out HandleMidiIn lphMidiIn,
            UIntPtr          uDeviceId,
            MidiInProc       dwCallback,
            UIntPtr          dwCallbackInstance,
            MidiOpenFlags    dwFlags);

        [DllImport(DllName)]
        private static extern int midiOutOpen(
            out HandleMidiOut lphMidiOut,
            UIntPtr           uDeviceId,
            MidiOutProc       dwCallback,
            UIntPtr           dwCallbackInstance,
            MidiOpenFlags     dwFlags);
    }
}