using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;

namespace LaunchReact
{
    public static class MidiEventToNoteVelocity
    {
        public static MidiEvent ToNoteVelocity(this MidiEventReceivedEventArgs e)
        {
            MidiEvent midiEvent = new MidiEvent(0, 0);
            switch (e.Event.EventType)
            {
                case MidiEventType.NoteAftertouch:
                {
                    NoteAftertouchEvent atEvent = (NoteAftertouchEvent) e.Event;
                    midiEvent.Note     = atEvent.NoteNumber;
                    midiEvent.Velocity = atEvent.AftertouchValue;
                    break;
                }
                case MidiEventType.NoteOn:
                {
                    NoteOnEvent onEvent = (NoteOnEvent) e.Event;
                    midiEvent.Note     = onEvent.NoteNumber;
                    midiEvent.Velocity = onEvent.Velocity;
                    break;
                }
            }

            return midiEvent;
        }
    }
}