using System.Linq;

namespace LaunchReact
{
    public struct MidiEvent
    {
        public int Note     { get; set; }
        public int Velocity { get; set; }

        public MidiEvent(int note, int velocity)
        {
            this.Note     = note;
            this.Velocity = velocity;
        }

        public MidiEvent(int x, int y, int velocity)
        {
            this.Note     = GlobalVariables.InnerNotes[x, y];
            this.Velocity = velocity;
        }

        public MidiEvent(int index, int velocity, GlobalVariables.NoteSide side)
        {
            this.Note = side switch
            {
                GlobalVariables.NoteSide.Top    => GlobalVariables.TopNotes.ElementAt(index),
                GlobalVariables.NoteSide.Bottom => GlobalVariables.BottomNotes.ElementAt(index),
                GlobalVariables.NoteSide.Right  => GlobalVariables.RightNotes.ElementAt(index),
                GlobalVariables.NoteSide.Left   => GlobalVariables.LeftNotes.ElementAt(index),
                _                               => 0
            };
            this.Velocity = velocity;
        }

        public override string ToString() => $"Note: {this.Note}, Velocity: {this.Velocity}";
    }
}