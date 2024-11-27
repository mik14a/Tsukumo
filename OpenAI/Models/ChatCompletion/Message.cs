using Newtonsoft.Json;
using Tsukumo.OpenAI.Models.ChatCompletion.Messages;

namespace Tsukumo.OpenAI.Models.ChatCompletion
{
    public class Message
    {
        public static class Roles
        {
            public static readonly string System = "system";
            public static readonly string User = "user";
            public static readonly string Assistant = "assistant";
            public static readonly string Tool = "tool";
        }

        public static SystemMessage System(string message) { return new SystemMessage(message); }
        public static UserMessage User(string message) { return new UserMessage(message); }
        public static AssistantMessage Assistant(string message) { return new AssistantMessage(message); }

        /// <summary>The contents of the system message.</summary>
        [JsonProperty("content")]
        public string Content { get; }
        /// <summary>The role of the messages author.</summary>
        [JsonProperty("role")]
        public string Role { get; }
        /// <summary>
        /// An optional name for the participant.
        /// Provides the model information to differentiate between participants of the same role.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        public Message(string content, string role, string name) {
            Content = content;
            Role = role;
            Name = name;
        }
    }
}
