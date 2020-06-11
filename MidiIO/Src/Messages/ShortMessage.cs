using System;
using MidiIO.CustomIntegers;

namespace MidiIO.Messages
{
    internal static class ShortMessage
    {
        public static ShortMessageType GetMessageType(UIntPtr dwParam1) =>
            ((int)dwParam1 & 0xf0) switch
            {
                0x90 => ShortMessageType.NoteOn,
                0x80 => ShortMessageType.NoteOff,
                0xB0 => ShortMessageType.ControlChange,
                0xA0 => ShortMessageType.NoteOn,
                _    => throw new NotSupportedException(nameof(dwParam1))
            };

        public static void DecodeMessage(UIntPtr dwParam1, ShortMessageType messageType, out Channel channel, out UInt7 note, out UInt7 velocity)
        {
            if (GetMessageType(dwParam1) != messageType)
            {
                throw new ArgumentException($"Not a {messageType} message.");
            }

            channel   = (Channel)((int)dwParam1 & 0x0f);
            note      = (UInt7)(((int)dwParam1 & 0xff00) >> 8);
            velocity  = (UInt7)(((int)dwParam1 & 0xff0000) >> 16);
        }

        public static uint EncodeMessage(Channel channel, UInt7 note, UInt7 velocity, ShortMessageType messageType) =>
            messageType switch
            {
                ShortMessageType.NoteOn        => (uint)(0x90 | (int)channel | (note << 8) | (velocity << 16)),
                ShortMessageType.NoteOff       => (uint)(0x80 | (int)channel | (note << 8) | 0),
                ShortMessageType.ControlChange => (uint)(0xB0 | (int)channel | (note << 8) | (velocity << 16)),
                _                              => throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null)
            };
    }
}