namespace OpenAI.Models
{
    /// <summary>
    /// This class contains the models and their respective token and request limits.
    /// </summary>
    public class OpenAI
    {
        /// <summary>
        /// Gpt-3.5-turbo model with 80,000 TPM, 5,000 RPM
        /// </summary>
        public const string Gpt35Turbo = "gpt-3.5-turbo";

        /// <summary>
        /// Gpt-3.5-turbo-0301 model with 80,000 TPM, 5,000 RPM
        /// </summary>
        public const string Gpt35Turbo0301 = "gpt-3.5-turbo-0301";

        /// <summary>
        /// Gpt-3.5-turbo-0613 model with 80,000 TPM, 5,000 RPM
        /// </summary>
        public const string Gpt35Turbo0613 = "gpt-3.5-turbo-0613";

        /// <summary>
        /// Gpt-3.5-turbo-1106 model with 80,000 TPM, 5,000 RPM
        /// </summary>
        public const string Gpt35Turbo1106 = "gpt-3.5-turbo-1106";

        /// <summary>
        /// Gpt-3.5-turbo-16k model with 80,000 TPM, 5,000 RPM
        /// </summary>
        public const string Gpt35Turbo16k = "gpt-3.5-turbo-16k";

        /// <summary>
        /// Gpt-3.5-turbo-16k-0613 model with 80,000 TPM, 5,000 RPM
        /// </summary>
        public const string Gpt35Turbo16k0613 = "gpt-3.5-turbo-16k-0613";

        /// <summary>
        /// Gpt-3.5-turbo-instruct model with 250,000 TPM, 3,000 RPM
        /// </summary>
        public const string Gpt35TurboInstruct = "gpt-3.5-turbo-instruct";

        /// <summary>
        /// Gpt-3.5-turbo-instruct-0914 model with 250,000 TPM, 3,000 RPM
        /// </summary>
        public const string Gpt35TurboInstruct0914 = "gpt-3.5-turbo-instruct-0914";

        /// <summary>
        /// Gpt-4 model with 40,000 TPM, 5,000 RPM
        /// </summary>
        public const string Gpt4 = "gpt-4";

        /// <summary>
        /// Gpt-4-0314 model with 40,000 TPM, 5,000 RPM
        /// </summary>
        public const string Gpt40314 = "gpt-4-0314";

        /// <summary>
        /// Gpt-4-0613 model with 40,000 TPM, 5,000 RPM
        /// </summary>
        public const string Gpt40613 = "gpt-4-0613";

        /// <summary>
        /// Gpt-4-1106-preview model with 300,000 TPM, 1,500,000 TPD, 500 RPM
        /// </summary>
        public const string Gpt41106Preview = "gpt-4-1106-preview";

        /// <summary>
        /// Gpt-4-vision-preview model with 20,000 TPM, 100 RPM, 1,000 RPD
        /// </summary>
        public const string Gpt4VisionPreview = "gpt-4-vision-preview";
    }
}
