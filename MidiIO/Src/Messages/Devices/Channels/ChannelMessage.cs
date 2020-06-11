using MidiIO.Devices;

namespace MidiIO.Messages.Devices.Channels
{
    public abstract class ChannelMessage : DeviceMessage
    {
        protected ChannelMessage(Device device, Channel channel)
            : base(device) =>
            this.Channel = channel;

        public Channel Channel { get; }
    }
}