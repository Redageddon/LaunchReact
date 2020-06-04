namespace LaunchReact
{
    public struct MidiOutput
    {
        public int Note { get; set; }
        public int Velocity { get; set; }

        public MidiOutput(int note, int velocity)
        {
            this.Note     = note;
            this.Velocity = velocity;
        }
    }
}