using System;
using MidiIO.Devices;

namespace MidiIO.Messages.Devices
{
    public abstract class DeviceMessage
    {
        protected DeviceMessage(Device device) =>
            this.Device = device ?? throw new ArgumentNullException(nameof(device));

        public Device Device { get; }
    }
}