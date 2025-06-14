using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Tsukumo.VoiceVox.Interfaces
{
    /// <summary>
    /// Defines the interface for VoiceVox text-to-speech service operations.
    /// </summary>
    public interface IVoiceVoxService
    {
        /// <summary>
        /// Converts text to speech using the specified speaker and speed settings.
        /// </summary>
        /// <param name="text">The text to be converted to speech.</param>
        /// <param name="speaker">The speaker ID to use for voice synthesis.</param>
        /// <param name="speedScale">The speed scale factor for speech playback (1.0 is normal speed).</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous speech synthesis operation.</returns>
        Task<Stream> Speak(string text, int speaker, float speedScale, CancellationToken cancellationToken);
    }
}
