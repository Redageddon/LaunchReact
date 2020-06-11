using System;
using System.Collections.ObjectModel;
using MidiIO.CustomIntegers;
using MidiIO.Messages;

namespace MidiIO.Devices
{
    public class OutputDevice : Device
    {
        private static readonly object            StaticLock = new object();
        private static          OutputDevice[]    installedDevices;
        private readonly        UIntPtr           deviceId;
        private                 Win32Api.Api.HandleMidiOut handle;

        private bool isOpen;

        private OutputDevice(UIntPtr deviceId, Win32Api.Api.MidiOutCapabilities caps)
            : base(caps.Name)
        {
            this.deviceId = deviceId;
            this.isOpen   = false;
        }

        public static ReadOnlyCollection<OutputDevice> InstalledDevices
        {
            get
            {
                lock (StaticLock)
                {
                    installedDevices ??= MakeDeviceList();
                    return new ReadOnlyCollection<OutputDevice>(installedDevices);
                }
            }
        }

        public bool IsOpen
        {
            get
            {
                lock (this)
                {
                    return this.isOpen;
                }
            }
        }

        public static void UpdateInstalledDevices()
        {
            lock (StaticLock)
            {
                installedDevices = null;
            }
        }

        public void Open()
        {
            lock (this)
            {
                this.CheckNotOpen();
                CheckReturnCode(Win32Api.Api.MidiOutOpen(out this.handle, this.deviceId, null, (UIntPtr)0));
                this.isOpen = true;
            }
        }

        public void SendNoteOn(Channel channel, UInt7 note, UInt7 velocity)
        {
            lock (this)
            {
                this.CheckOpen();
                CheckReturnCode(Win32Api.Api.midiOutShortMsg(this.handle, ShortMessage.EncodeMessage(channel, note, velocity, ShortMessageType.NoteOn)));
            }
        }

        public void SendNoteOff(Channel channel, UInt7 note, UInt7 velocity)
        {
            lock (this)
            {
                this.CheckOpen();
                CheckReturnCode(Win32Api.Api.midiOutShortMsg(this.handle, ShortMessage.EncodeMessage(channel, note, velocity, ShortMessageType.NoteOff)));
            }
        }

        public void SendControlChange(Channel channel, UInt7 note, UInt7 value)
        {
            lock (this)
            {
                this.CheckOpen();
                CheckReturnCode(Win32Api.Api.midiOutShortMsg(this.handle, ShortMessage.EncodeMessage(channel, note, value, ShortMessageType.ControlChange)));
            }
        }

        private static void CheckReturnCode(int returnCode)
        {
            if (returnCode != 0)
            {
                throw new Exception("Device Error");
            }
        }

        private static OutputDevice[] MakeDeviceList()
        {
            uint           outDevs = Win32Api.Api.midiOutGetNumDevs();
            OutputDevice[] result  = new OutputDevice[outDevs];
            for (uint deviceId = 0; deviceId < outDevs; deviceId++)
            {
                Win32Api.Api.MidiOutGetDevCaps((UIntPtr)deviceId, out Win32Api.Api.MidiOutCapabilities caps);
                result[deviceId] = new OutputDevice((UIntPtr)deviceId, caps);
            }

            return result;
        }

        private void CheckOpen()
        {
            if (!this.isOpen)
            {
                throw new InvalidOperationException("device not open");
            }
        }

        private void CheckNotOpen()
        {
            if (this.isOpen)
            {
                throw new InvalidOperationException("device open");
            }
        }
    }
}