using System.Collections.Generic;
using System.Timers;

namespace LaunchReact
{
    public class FramePlayer
    {
        private readonly Timer timer = new Timer(1000);
        private          float fps;

        public FramePlayer() => this.timer.Elapsed += this.OnElapsed;

        public FramePlayer(float fps, List<Frame> frames)
        {
            this.Fps            =  fps;
            this.Frames         =  frames;
            this.timer.Interval =  1000f / this.Fps;
            this.timer.Elapsed  += this.OnElapsed;
        }

        public float Fps
        {
            get => this.fps;
            set
            {
                this.timer.Interval = 1000f / value;
                this.fps            = value;
            }
        }

        public List<Frame> Frames       { get; set; }

        public int         CurrentFrame { get; set; }

        private void OnElapsed(object sender, ElapsedEventArgs e)
        {
            this.PlayFrame(this.CurrentFrame);
            this.CurrentFrame++;
        }

        public void StartPlayingFrames() => this.timer.Start();

        public void StopPlayingFrames() => this.timer.Stop();

        public void ResetPlayer() => this.CurrentFrame = 0;

        public void PlayFrame(int frameToPlay)
        {
        }
    }
}