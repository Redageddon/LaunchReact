using System.Collections.Generic;

namespace LaunchReact
{
    public class Frame
    {
        public Frame()
        {
        }

        public Frame(List<MidiEvent> events) => this.Events = events;

        public List<MidiEvent> Events { get; set; }

        /*public List<NoteOnEvent> GetNoteOnEvents()
        {
            List<NoteOnEvent> onEvents = new List<NoteOnEvent>();
            foreach (MidiEvent midiEvent in this.Events)
            {
                onEvents.Add(new NoteOnEvent(new SevenBitNumber((byte) midiEvent.Note), new SevenBitNumber((byte) midiEvent.Velocity)));
            }

            return onEvents;
        }

        public void Play()
        {
            foreach (NoteOnEvent noteOnEvent in this.GetNoteOnEvents())
            {
                Devices.OutputDevice.SendEvent(noteOnEvent);
            }
        }*/
    }
}