namespace OpenAI.Models.ChatCompletion.Messages
{
    public class UserMessage : Message
    {
        public UserMessage(string content) : base(content, Roles.User, null) { }
    }
}
