using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.Completion
{
    /// <summary>
    /// Completions
    /// Given a prompt, the model will return one or more predicted completions along with the probabilities of alternative tokens at each position.
    /// Most developer should use our Chat Completions API to leverage our best and newest models.
    /// </summary>
    /// <remarks>https://platform.openai.com/docs/api-reference/completions</remarks>
    public class Request
    {
        /// <summary>
        /// ID of the model to use.
        /// You can use the List models API to see all of your available models,
        /// or see our Model overview for descriptions of them.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// The prompt(s) to generate completions for, encoded as a string, array of strings, array of tokens, or array of token arrays.
        /// Note that <|endoftext|> is the document separator that the model sees during training,
        /// so if a prompt is not specified the model will generate as if from the beginning of a new document.
        /// </summary>
        [JsonProperty("prompt")]
        public object Prompt { get; set; }

        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far,
        /// decreasing the model's likelihood to repeat the same line verbatim.
        /// </summary>
        /// <remarks>Optional. Defaults to 0.</remarks>
        [JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
        public float? FrequencyPenalty { get; set; }

        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far,
        /// increasing the model's likelihood to talk about new topics.
        /// </summary>
        /// <remarks>Optional. Defaults to 0.</remarks>
        [JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
        public float? PresencePenalty { get; set; }

        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.
        /// </summary>
        /// <value>Optional.</value>
        [JsonProperty("repetition_penalty", NullValueHandling = NullValueHandling.Ignore)]
        public float? RepetitionPenalty { get; set; }

        /// <summary>
        /// What sampling temperature to use, between 0 and 2.
        /// Higher values like 0.8 will make the output more random,
        /// while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        /// <remarks>We generally recommend altering this or top_p but not both.</remarks>
        /// <value>Optional. Defaults to 1.</value>
        [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
        public float? Temperature { get; set; }

        /// <summary>
        /// The maximum number of tokens to generate in the completion.
        /// The token count of your prompt plus max_tokens cannot exceed the model's context length.
        /// </summary>
        /// <remarks>Optional. Defaults to 16.</remarks>
        [JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxTokens { get; set; }

        /// <summary>
        /// Whether to stream back partial progress.
        /// If set, tokens will be sent as data-only server-sent events as they become available,
        /// with the stream terminated by a data: [DONE] message.
        /// </summary>
        /// <remarks>Optional. Defaults to false.</remarks>
        [JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Stream { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? BestOf { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Echo { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, float> LogitBias { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? LogProbs { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? N { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Seed { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] Stop { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object StreamOptions { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Suffix { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? TopP { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }
    }
}
