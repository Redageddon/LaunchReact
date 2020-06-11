using System;
using System.Runtime.InteropServices;

namespace MidiIO.Win32Api
{
    internal static partial class Api
    {
        public static void MidiInGetDevCaps(UIntPtr uDeviceId, out MidiInCapabilities caps) =>
            midiInGetDevCaps(uDeviceId, out caps, (uint)Marshal.SizeOf(typeof(MidiInCapabilities)));

        public static void MidiOutGetDevCaps(UIntPtr uDeviceId, out MidiOutCapabilities caps) =>
            midiOutGetDevCaps(uDeviceId, out caps, (uint)Marshal.SizeOf(typeof(MidiOutCapabilities)));

        public static int MidiInOpen(out HandleMidiIn lphMidiIn, UIntPtr uDeviceId, MidiInProc dwCallback, UIntPtr dwCallbackInstance) =>
            midiInOpen(
                out lphMidiIn,
                uDeviceId,
                dwCallback,
                dwCallbackInstance,
                dwCallback == null ? MidiOpenFlags.CALLBACK_NULL : MidiOpenFlags.CALLBACK_FUNCTION);

        public static int MidiOutOpen(out HandleMidiOut lphMidiOut, UIntPtr uDeviceId, MidiOutProc dwCallback, UIntPtr dwCallbackInstance) =>
            midiOutOpen(
                out lphMidiOut,
                uDeviceId,
                dwCallback,
                dwCallbackInstance,
                dwCallback == null ? MidiOpenFlags.CALLBACK_NULL : MidiOpenFlags.CALLBACK_FUNCTION & MidiOpenFlags.MIDI_IO_STATUS);
    }
}