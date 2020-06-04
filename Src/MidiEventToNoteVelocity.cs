using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;

namespace LaunchReact
{
    public static class MidiEventToNoteVelocity
    {
        public static MidiOutput ToNoteVelocity(this MidiEventReceivedEventArgs e)
        {
            MidiOutput midiOutput = new MidiOutput(0,0);
            switch (e.Event.EventType)
            {
                case MidiEventType.NoteAftertouch:
                {
                    NoteAftertouchEvent atEvent = (NoteAftertouchEvent) e.Event;
                    midiOutput.Note     = atEvent.NoteNumber;
                    midiOutput.Velocity = atEvent.AftertouchValue;
                    break;
                }
                case MidiEventType.NoteOn:
                {
                    NoteOnEvent onEvent = (NoteOnEvent) e.Event;
                    midiOutput.Note     = onEvent.NoteNumber;
                    midiOutput.Velocity = onEvent.Velocity;
                    break;
                }
            }
            return midiOutput;
        }
    }
}