namespace OpenAI.Models.ChatCompletion.Messages
{
    public class SystemMessage : Message
    {
        public SystemMessage(string message) : base(message, Roles.System, null) { }
    }
}
