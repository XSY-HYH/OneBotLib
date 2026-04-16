using OneBotLib.Models;

namespace OneBotLib.Events
{
    public class MessageEventArgs : EventArgs
    {
        public MessageObject Message { get; set; } = new();
    }

    public class PrivateMessageEventArgs : MessageEventArgs
    {
    }

    public class GroupMessageEventArgs : MessageEventArgs
    {
    }
}
