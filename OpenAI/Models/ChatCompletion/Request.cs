using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.ChatCompletion
{
    /// <summary>
    /// Creates a model response for the given chat conversation.
    /// </summary>
    /// <remarks>https://platform.openai.com/docs/api-reference/chat/create</remarks>
    public class Request
    {
        /// <summary>
        /// ID of the model to use.
        /// See the model endpoint compatibility table for details on which models work with the Chat API.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// A list of messages comprising the conversation.
        /// </summary>
        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }

        /// <summary>
        /// Number between -2.0 and 2.0.
        /// Positive values penalize new tokens based on their existing frequency in the text so far,
        /// decreasing the model's likelihood to repeat the same line verbatim.
        /// </summary>
        /// <value>Optional. Defaults to 0.</value>
        [JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
        public double? FrequencyPenalty { get; set; }

        /// <summary>
        /// Number between -2.0 and 2.0.
        /// Positive values penalize new tokens based on whether they appear in the text so far,
        /// increasing the model's likelihood to talk about new topics.
        /// </summary>
        /// <value>Optional. Defaults to 0.</value>
        [JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
        public double? PresencePenalty { get; set; }

        /// <summary>
        /// Sets how strongly to penalize repetitions. A higher value (e.g., 1.5) will penalize repetitions more strongly,
        /// while a lower value (e.g., 0.9) will be more lenient. (Default: 1.1)
        /// </summary>
        /// <value>Optional.</value>
        [JsonProperty("repeat_penalty", NullValueHandling = NullValueHandling.Ignore)]
        public float? RepeatPenalty { get; set; }

        /// <summary>
        /// Sets how far back for the model to look back to prevent repetition. (Default: 64, 0 = disabled, -1 = num_ctx)
        /// </summary>
        /// <value>Optional.</value>
        [JsonProperty("repeat_last_n", NullValueHandling = NullValueHandling.Ignore)]
        public int? RepeatLastN { get; set; }

        /// <summary>
        /// What sampling temperature to use, between 0 and 2.
        /// Higher values like 0.8 will make the output more random,
        /// while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        /// <remarks>We generally recommend altering this or top_p but not both.</remarks>
        /// <value>Optional. Defaults to 1.</value>
        [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
        public double? Temperature { get; set; }

        /// <summary>
        /// An alternative to sampling with temperature,
        /// called nucleus sampling, where the model considers the results of the tokens with top_p probability mass.
        /// So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// </summary>
        /// <remarks>We generally recommend altering this or temperature but not both.</remarks>
        /// <value>Optional. Defaults to 1.</value>
        [JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
        public double? TopP { get; set; }

        /// <summary>
        /// How many chat completion choices to generate for each input message.
        /// Note that you will be charged based on the number of generated tokens across all of the choices.
        /// Keep n as 1 to minimize costs.
        /// </summary>
        /// <value>Optional. Defaults to 1.</value>
        [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
        public int? N { get; set; }

        /// <summary>
        /// The maximum number of tokens that can be generated in the chat completion.
        /// </summary>
        /// <value>Optional.</value>
        [JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxTokens { get; set; }

        /// <summary>
        /// An object specifying the format that the model must output. Compatible with gpt-4-1106-preview and gpt-3.5-turbo-1106.
        /// </summary>
        /// <remarks>
        /// Setting to { "type": "json_object" } enables JSON mode, which guarantees the message the model generates is valid JSON.
        /// Important: when using JSON mode,
        /// you must also instruct the model to produce JSON yourself via a system or user message.Without this,
        /// the model may generate an unending stream of whitespace until the generation reaches the token limit,
        /// resulting in a long-running and seemingly "stuck" request.Also note that the message content may be partially cut off if finish_reason= "length",
        /// which indicates the generation exceeded max_tokens or the conversation exceeded the max context length.
        /// </remarks>
        /// <value>Optional.</value>
        [JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
        public ResponseFormat ResponseFormat { get; set; }

        /// <summary>
        /// Modify the likelihood of specified tokens appearing in the completion.
        /// </summary>
        /// <remarks>
        /// Accepts a JSON object that maps tokens (specified by their token ID in the tokenizer) to an associated bias value from -100 to 100.
        /// Mathematically, the bias is added to the logits generated by the model prior to sampling.
        /// The exact effect will vary per model, but values between -1 and 1 should decrease or increase likelihood of selection;
        /// values like -100 or 100 should result in a ban or exclusive selection of the relevant token.
        /// </remarks>
        /// <value>Optional. Defaults to null</value>
        [JsonProperty("logit_bias", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<int, int> LogitBias { get; set; }

        /// <summary>
        /// Whether to return log probabilities of the output tokens or not. If true, returns the log probabilities of each output token returned in the content of message. This option is currently not available on the gpt-4-vision-preview model.
        /// </summary>
        /// <value>Optional. Defaults to false</value>
        [JsonProperty("logprobs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Logprobs { get; set; }

        /// <summary>
        /// An integer between 0 and 5 specifying the number of most likely tokens to return at each token position, each with an associated log probability.
        /// Logprobs must be set to true if this parameter is used.
        /// </summary>
        /// <value>Optional.</value>
        [JsonProperty("top_logprobs", NullValueHandling = NullValueHandling.Ignore)]
        public int? TopLogprobs { get; set; }

        /// <summary>
        /// This feature is in Beta. If specified, our system will make a best effort to sample deterministically,
        /// such that repeated requests with the same seed and parameters should return the same result.
        /// Determinism is not guaranteed, and you should refer to the system_fingerprint response parameter to monitor changes in the backend.
        /// </summary>
        /// <value>Optional.</value>
        [JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
        public int? Seed { get; set; }

        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens.
        /// </summary>
        /// <value>Optional. Defaults to null.</value>
        [JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Stop { get; set; }

        /// <summary>
        /// If set, partial message deltas will be sent, like in ChatGPT. Tokens will be sent as data-only server-sent events as they become available, with the stream terminated by a data: [DONE]
        /// </summary>
        /// <value>Optional. Defaults to false.</value>
        [JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Stream { get; set; }

        /// <summary>
        /// Options for streaming response. Only set this when you set stream: true.
        /// </summary>
        /// <value>Optional. Defaults to null.</value>
        [JsonProperty("stream_options", NullValueHandling = NullValueHandling.Ignore)]
        public StreamOptions StreamOptions { get; set; }

        /// <summary>
        /// A list of tools the model may call. Currently, only functions are supported as a tool. Use this to provide a list of functions the model may generate JSON inputs for.
        /// </summary>
        /// <value>Optional.</value>
        [JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
        public List<Tool> Tools { get; set; }

        /// <summary>
        /// Controls which (if any) function is called by the model. none means the model will not call a function and instead generates a message. auto means the model can pick between generating a message or calling a function. Specifying a particular function via {"type": "function", "function": {"name": "my_function"}} forces the model to call that function.
        /// </summary>
        /// <remarks>none is the default when no functions are present. auto is the default if functions are present.</remarks>
        /// <value>Optional.</value>
        [JsonProperty("tool_choice", NullValueHandling = NullValueHandling.Ignore)]
        public ToolChoice ToolChoice { get; set; }

        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        /// <value>Optional.</value>
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }
    }
}
