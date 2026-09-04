namespace Tsukumo.OpenAI.Models.ChatCompletion
{
public partial class Request
    {
        /// <summary>
        /// Static class defining the reasoning effort levels for reasoning models.
        /// </summary>
        public static class ReasoningEfforts
        {
            /// <summary>
            /// No reasoning. The model does not spend tokens on reasoning.
            /// </summary>
            public static string None = "none";
            /// <summary>
            /// Minimal reasoning effort. Fastest responses among reasoning levels that still reason.
            /// </summary>
            public static string Minimal = "minimal";
            /// <summary>
            /// Low reasoning effort. Faster responses, fewer tokens on reasoning.
            /// </summary>
            public static string Low = "low";
            /// <summary>
            /// Medium reasoning effort (default for reasoning models).
            /// </summary>
            public static string Medium = "medium";
            /// <summary>
            /// High reasoning effort. More thorough reasoning, higher latency and token usage.
            /// </summary>
            public static string High = "high";
            /// <summary>
            /// Extra high reasoning effort. Most thorough reasoning, highest latency and token usage.
            /// </summary>
            public static string XHigh = "xhigh";

            /// <summary>
            /// All supported reasoning effort values, in increasing order of effort.
            /// </summary>
            public static readonly string[] All = [None, Minimal, Low, Medium, High, XHigh];
        }
    }
}
