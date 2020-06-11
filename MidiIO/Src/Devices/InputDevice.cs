using System;
using System.Collections.ObjectModel;
using MidiIO.CustomIntegers;
using MidiIO.Messages;
using MidiIO.Messages.Devices.Channels;
using MidiIO.Messages.Devices.Channels.Notes;

namespace MidiIO.Devices
{
    public class InputDevice : Device
    {
        private static readonly       object        StaticLock = new object();
        [ThreadStatic] private static bool          isInsideInputHandler;
        private static                InputDevice[] installedDevices;

        private readonly UIntPtr             deviceId;
        private readonly Win32Api.Api.MidiInProc inputCallbackDelegate;
        private          Win32Api.Api.HandleMidiIn    handle;
        private          bool                isOpen;
        private          bool                isReceiving;

        private InputDevice(UIntPtr deviceId, Win32Api.Api.MidiInCapabilities caps)
            : base(caps.Name)
        {
            this.deviceId              = deviceId;
            this.inputCallbackDelegate = this.InputCallback;
            this.isOpen                = false;
        }

        public delegate void ControlChangeHandler(ControlChangeMessage msg);

        public delegate void NoteOffHandler(NoteOffMessage msg);

        public delegate void NoteOnHandler(NoteOnMessage msg);

        public event ControlChangeHandler ControlChange;

        public event NoteOffHandler NoteOff;

        public event NoteOnHandler NoteOn;

        public static ReadOnlyCollection<InputDevice> InstalledDevices
        {
            get
            {
                lock (StaticLock)
                {
                    installedDevices ??= MakeDeviceList();
                    return new ReadOnlyCollection<InputDevice>(installedDevices);
                }
            }
        }

        public bool IsOpen
        {
            get
            {
                if (isInsideInputHandler)
                {
                    return true;
                }

                lock (this)
                {
                    return this.isOpen;
                }
            }
        }

        public bool IsReceiving
        {
            get
            {
                if (isInsideInputHandler)
                {
                    return true;
                }

                lock (this)
                {
                    return this.isReceiving;
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
            if (isInsideInputHandler)
            {
                throw new InvalidOperationException("Device is open.");
            }

            lock (this)
            {
                this.CheckNotOpen();
                CheckReturnCode(Win32Api.Api.MidiInOpen(out this.handle, this.deviceId, this.inputCallbackDelegate, (UIntPtr)0));
                this.isOpen = true;
            }
        }

        public void Close()
        {
            if (isInsideInputHandler)
            {
                throw new InvalidOperationException("Device is receiving.");
            }

            lock (this)
            {
                this.CheckOpen();

                CheckReturnCode(Win32Api.Api.midiInClose(this.handle));
                this.isOpen = false;
            }
        }

        public void StartReceiving()
        {
            if (isInsideInputHandler)
            {
                throw new InvalidOperationException("Device is receiving.");
            }

            lock (this)
            {
                this.CheckOpen();
                this.CheckNotReceiving();

                CheckReturnCode(Win32Api.Api.midiInStart(this.handle));
                this.isReceiving = true;
            }
        }

        public void StopReceiving()
        {
            if (isInsideInputHandler)
            {
                throw new InvalidOperationException("Can't call StopReceiving() from inside an input handler.");
            }

            lock (this)
            {
                this.CheckReceiving();
                CheckReturnCode(Win32Api.Api.midiInStop(this.handle));
                this.isReceiving = false;
            }
        }

        private static void CheckReturnCode(int returnCode)
        {
            if (returnCode != 0)
            {
                throw new Exception("Device Error");
            }
        }

        private static InputDevice[] MakeDeviceList()
        {
            uint          inputDeviceCount = Win32Api.Api.midiInGetNumDevs();
            InputDevice[] result           = new InputDevice[inputDeviceCount];
            for (uint deviceId = 0; deviceId < inputDeviceCount; deviceId++)
            {
                Win32Api.Api.MidiInGetDevCaps((UIntPtr)deviceId, out Win32Api.Api.MidiInCapabilities caps);
                result[deviceId] = new InputDevice((UIntPtr)deviceId, caps);
            }

            return result;
        }

        private void CheckOpen()
        {
            if (!this.isOpen)
            {
                throw new InvalidOperationException("Device is not open.");
            }
        }

        private void CheckNotOpen()
        {
            if (this.isOpen)
            {
                throw new InvalidOperationException("Device is open.");
            }
        }

        private void CheckReceiving()
        {
            if (!this.isReceiving)
            {
                throw new Exception("device not receiving");
            }
        }

        private void CheckNotReceiving()
        {
            if (this.isReceiving)
            {
                throw new Exception("device receiving");
            }
        }

        private void InputCallback(Win32Api.Api.HandleMidiIn hMidiIn, Win32Api.Api.MidiInMessage wMsg, UIntPtr dwInstance, UIntPtr dwParam1, UIntPtr dwParam2)
        {
            isInsideInputHandler = true;
            try
            {
                if (wMsg == Win32Api.Api.MidiInMessage.MIM_DATA)
                {
                    ShortMessageType messageType = ShortMessage.GetMessageType(dwParam1);
                    ShortMessage.DecodeMessage(dwParam1, messageType, out Channel channel, out UInt7 note, out UInt7 velocity);
                    switch (messageType)
                    {
                        case ShortMessageType.NoteOn:
                            this.NoteOn?.Invoke(new NoteOnMessage(this, channel, note, velocity));
                            break;
                        case ShortMessageType.NoteOff:
                            this.NoteOff?.Invoke(new NoteOffMessage(this, channel, note, velocity));
                            break;
                        case ShortMessageType.ControlChange:
                            this.ControlChange?.Invoke(new ControlChangeMessage(this, channel, note, velocity));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            finally
            {
                isInsideInputHandler = false;
            }
        }
    }
}