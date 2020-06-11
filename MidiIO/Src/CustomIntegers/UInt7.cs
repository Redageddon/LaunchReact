using System;

namespace MidiIO.CustomIntegers
{
    public readonly struct UInt7
    {
        public const     byte MinValue = 0;
        public const     byte MaxValue = 127;
        private readonly byte data;

        public UInt7(byte value) => this.data = GetValue(value);

        public static implicit operator byte(UInt7 d) => d.data;

        public static implicit operator UInt7(byte b) => new UInt7(b);

        public static explicit operator UInt7(int i) => new UInt7((byte)i);

        public static explicit operator UInt7(Enum e) => new UInt7((byte)(int)(object)e);

        private static byte GetValue(byte value)
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} cannot be greater than {MaxValue} or less than {MinValue}.");
            }

            return value;
        }
    }
}