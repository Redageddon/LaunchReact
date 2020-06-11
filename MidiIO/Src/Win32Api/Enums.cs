using System;

namespace MidiIO.Win32Api
{
    internal static partial class Api
    {
        public enum MidiInMessage : uint
        {
            MIM_DATA      = 0x3C3,
        }

        [Flags]
        private enum MidiOpenFlags : uint
        {
            CALLBACK_NULL     = 0x00000,
            CALLBACK_FUNCTION = 0x30000,
            MIDI_IO_STATUS    = 0x00020,
        }
    }
}