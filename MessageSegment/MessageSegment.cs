using System.Text.Json.Serialization;

namespace OneBotLib.MessageSegment
{
    public class MessageSegment
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public Dictionary<string, object> Data { get; set; } = new();

        public static MessageSegment Text(string text)
        {
            return new MessageSegment
            {
                Type = "text",
                Data = new Dictionary<string, object> { { "text", text } }
            };
        }

        public static MessageSegment At(long userId)
        {
            return new MessageSegment
            {
                Type = "at",
                Data = new Dictionary<string, object> { { "qq", userId } }
            };
        }

        public static MessageSegment AtAll()
        {
            return new MessageSegment
            {
                Type = "at",
                Data = new Dictionary<string, object> { { "qq", "all" } }
            };
        }

        public static MessageSegment Face(int id)
        {
            return new MessageSegment
            {
                Type = "face",
                Data = new Dictionary<string, object> { { "id", id } }
            };
        }

        public static MessageSegment Image(string file, bool? cache = null, bool? proxy = null, int? timeout = null)
        {
            var data = new Dictionary<string, object> { { "file", file } };
            if (cache.HasValue) data["cache"] = cache.Value ? 1 : 0;
            if (proxy.HasValue) data["proxy"] = proxy.Value ? 1 : 0;
            if (timeout.HasValue) data["timeout"] = timeout.Value;
            return new MessageSegment { Type = "image", Data = data };
        }

        public static MessageSegment Record(string file, bool? magic = null, bool? cache = null, bool? proxy = null, int? timeout = null)
        {
            var data = new Dictionary<string, object> { { "file", file } };
            if (magic.HasValue) data["magic"] = magic.Value ? 1 : 0;
            if (cache.HasValue) data["cache"] = cache.Value ? 1 : 0;
            if (proxy.HasValue) data["proxy"] = proxy.Value ? 1 : 0;
            if (timeout.HasValue) data["timeout"] = timeout.Value;
            return new MessageSegment { Type = "record", Data = data };
        }

        public static MessageSegment Video(string file, bool? cache = null, bool? proxy = null, int? timeout = null)
        {
            var data = new Dictionary<string, object> { { "file", file } };
            if (cache.HasValue) data["cache"] = cache.Value ? 1 : 0;
            if (proxy.HasValue) data["proxy"] = proxy.Value ? 1 : 0;
            if (timeout.HasValue) data["timeout"] = timeout.Value;
            return new MessageSegment { Type = "video", Data = data };
        }

        public static MessageSegment Reply(long messageId)
        {
            return new MessageSegment
            {
                Type = "reply",
                Data = new Dictionary<string, object> { { "id", messageId } }
            };
        }

        public static MessageSegment Forward(string id)
        {
            return new MessageSegment
            {
                Type = "forward",
                Data = new Dictionary<string, object> { { "id", id } }
            };
        }

        public static MessageSegment Node(long userId, string nickname, List<MessageSegment> content)
        {
            return new MessageSegment
            {
                Type = "node",
                Data = new Dictionary<string, object>
                {
                    { "user_id", userId },
                    { "nickname", nickname },
                    { "content", content }
                }
            };
        }

        public static MessageSegment Xml(string data)
        {
            return new MessageSegment
            {
                Type = "xml",
                Data = new Dictionary<string, object> { { "data", data } }
            };
        }

        public static MessageSegment Json(string data)
        {
            return new MessageSegment
            {
                Type = "json",
                Data = new Dictionary<string, object> { { "data", data } }
            };
        }

        public static MessageSegment Location(double lat, double lon, string? title = null, string? content = null)
        {
            var data = new Dictionary<string, object>
            {
                { "lat", lat },
                { "lon", lon }
            };
            if (!string.IsNullOrEmpty(title)) data["title"] = title;
            if (!string.IsNullOrEmpty(content)) data["content"] = content;
            return new MessageSegment { Type = "location", Data = data };
        }

        public static MessageSegment Share(string url, string title, string? content = null, string? image = null)
        {
            var data = new Dictionary<string, object>
            {
                { "url", url },
                { "title", title }
            };
            if (!string.IsNullOrEmpty(content)) data["content"] = content;
            if (!string.IsNullOrEmpty(image)) data["image"] = image;
            return new MessageSegment { Type = "share", Data = data };
        }

        public static MessageSegment Contact(long userId)
        {
            return new MessageSegment
            {
                Type = "contact",
                Data = new Dictionary<string, object> { { "type", "qq" }, { "id", userId } }
            };
        }

        public static MessageSegment ContactGroup(long groupId)
        {
            return new MessageSegment
            {
                Type = "contact",
                Data = new Dictionary<string, object> { { "type", "group" }, { "id", groupId } }
            };
        }

        public static MessageSegment Dice()
        {
            return new MessageSegment
            {
                Type = "dice",
                Data = new Dictionary<string, object>()
            };
        }

        public static MessageSegment Rps()
        {
            return new MessageSegment
            {
                Type = "rps",
                Data = new Dictionary<string, object>()
            };
        }

        public static MessageSegment Shake()
        {
            return new MessageSegment
            {
                Type = "shake",
                Data = new Dictionary<string, object>()
            };
        }

        public static MessageSegment Poke(long type, long id)
        {
            return new MessageSegment
            {
                Type = "poke",
                Data = new Dictionary<string, object> { { "type", type }, { "id", id } }
            };
        }

        public static MessageSegment Anonymous(bool? ignore = null)
        {
            var data = new Dictionary<string, object>();
            if (ignore.HasValue) data["ignore"] = ignore.Value;
            return new MessageSegment { Type = "anonymous", Data = data };
        }

        public static MessageSegment Music(long id, string type = "qq")
        {
            return new MessageSegment
            {
                Type = "music",
                Data = new Dictionary<string, object> { { "type", type }, { "id", id } }
            };
        }

        public static MessageSegment MusicCustom(string url, string audio, string title, string? content = null, string? image = null)
        {
            var data = new Dictionary<string, object>
            {
                { "type", "custom" },
                { "url", url },
                { "audio", audio },
                { "title", title }
            };
            if (!string.IsNullOrEmpty(content)) data["content"] = content;
            if (!string.IsNullOrEmpty(image)) data["image"] = image;
            return new MessageSegment { Type = "music", Data = data };
        }

        public static MessageSegment File(string file, string name)
        {
            return new MessageSegment
            {
                Type = "file",
                Data = new Dictionary<string, object> { { "file", file }, { "name", name } }
            };
        }

        public static MessageSegment Mface(int emojiPackageId, string emojiId, string key, string? summary = null)
        {
            var data = new Dictionary<string, object>
            {
                { "emoji_package_id", emojiPackageId },
                { "emoji_id", emojiId },
                { "key", key }
            };
            if (!string.IsNullOrEmpty(summary)) data["summary"] = summary;
            return new MessageSegment { Type = "mface", Data = data };
        }

        public static MessageSegment Markdown(string content)
        {
            return new MessageSegment
            {
                Type = "markdown",
                Data = new Dictionary<string, object> { { "content", content } }
            };
        }
    }
}
