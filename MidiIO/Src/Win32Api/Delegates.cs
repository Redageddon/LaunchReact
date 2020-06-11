using System;

namespace MidiIO.Win32Api
{
    internal static partial class Api
    {
        public delegate void MidiInProc(HandleMidiIn hMidiIn, MidiInMessage wMsg, UIntPtr dwInstance, UIntPtr dwParam1, UIntPtr dwParam2);

        public delegate void MidiOutProc(HandleMidiOut hmo, UIntPtr dwInstance, UIntPtr dwParam1, UIntPtr dwParam2);
    }
}