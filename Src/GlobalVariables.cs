using System.Collections.Generic;
using System.Linq;

namespace LaunchReact
{
    public static class GlobalVariables
    {
        public enum NoteSide
        {
            Inner,
            Top,
            Bottom,
            Right,
            Left
        }

        public static int[,] InnerNotes { get; } =
        {
            {81, 82, 83, 84, 85, 86, 87, 88},
            {71, 72, 73, 74, 75, 76, 77, 78},
            {61, 62, 63, 64, 65, 66, 67, 68},
            {51, 52, 53, 54, 55, 56, 57, 58},
            {41, 42, 43, 44, 45, 46, 47, 48},
            {31, 32, 33, 34, 35, 36, 37, 38},
            {21, 22, 23, 24, 25, 26, 27, 28},
            {11, 12, 13, 14, 15, 16, 17, 18}
        };

        public static IEnumerable<int> TopNotes    { get; } = Enumerable.Range(91, 8);
        public static IEnumerable<int> BottomNotes { get; } = Enumerable.Range(1,  8);
        public static IEnumerable<int> RightNotes  { get; } = Enumerable.Range(1, 8).Select(n => n * 10 + 9).Reverse();
        public static IEnumerable<int> LeftNotes   { get; } = Enumerable.Range(10, 71).Where(e => e % 10 == 0).Reverse();
        public static IEnumerable<int> AllNotes    { get; } = Enumerable.Range(1, 98).Where(n => n != 9 && n != 90);
    }
}
