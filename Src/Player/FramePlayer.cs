using System;
using System.Collections.Generic;
using System.Threading;

namespace LaunchReact
{
    public class FramePlayer
    {
        public float Fps { get; set; }
        public List<Frame> Frames { get; set; } = new List<Frame>();

        public FramePlayer()
        {
        }

        public FramePlayer(string path)
        {
            //Todo: load frames from path
        }

        public FramePlayer(float fps, List<Frame> frames)
        {
            this.Fps = fps;
            this.Frames = frames;
        }

        public void PlayFrames()
        {
            for (int i = 0; i < this.Frames.Count; i++)
            {
                this.Frames[i].Play();
                Console.WriteLine("Played frame");
                Thread.Sleep((int)(1f/ this.Fps * 1000));
            }
        }
    }
}