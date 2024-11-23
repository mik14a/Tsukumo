namespace OpenAI.Models.Completion
{
    /// <summary>
    /// Usage statistics for the completion request.
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// Number of tokens in the generated completion.
        /// </summary>
        public int CompletionTokens { get; set; }

        /// <summary>
        /// Number of tokens in the prompt.
        /// </summary>
        public int PromptTokens { get; set; }

        /// <summary>
        /// Total number of tokens used in the request (prompt + completion).
        /// </summary>
        public int TotalTokens { get; set; }
    }
}
