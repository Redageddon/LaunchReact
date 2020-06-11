using System;

namespace MidiIO.CustomIntegers
{
    public readonly struct UInt4
    {
        public const     byte MinValue = 0;
        public const     byte MaxValue = 15;
        private readonly byte data;

        public UInt4(byte value) => this.data = GetValue(value);

        public static implicit operator byte(UInt4 d) => d.data;

        public static implicit operator UInt4(byte b) => new UInt4(b);

        public static explicit operator UInt4(int i) => new UInt4((byte)i);

        public static explicit operator UInt4(Enum e) => new UInt4((byte)(int)(object)e);

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