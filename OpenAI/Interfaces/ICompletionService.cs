using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tsukumo.OpenAI.Models.Completion;

namespace Tsukumo.OpenAI.Interfaces
{
    /// <summary>
    /// 完成処理を提供するインターフェースです。
    /// </summary>
    public interface ICompletionService
    {
        /// <summary>
        /// 指定されたリクエストに基づいて、非同期に完成処理を生成し、結果を返します。
        /// </summary>
        /// <param name="request">完成リクエストの詳細。</param>
        /// <param name="modelId">使用するモデルのID（オプション）。</param>
        /// <param name="cancellationToken">処理のキャンセルを監視するためのトークン。</param>
        /// <returns>非同期操作を表すタスクオブジェクト。</returns>
        Task<Response> CreateCompletion(Request request,
                                        string modelId = null,
                                        CancellationToken cancellationToken = default);

        /// <summary>
        /// 指定されたリクエストに基づいて、非同期に完成処理をストリームとして生成し、結果を返します。
        /// </summary>
        /// <param name="request">完成リクエストの詳細。</param>
        /// <param name="modelId">使用するモデルのID（オプション）。</param>
        /// <param name="cancellationToken">処理のキャンセルを監視するためのトークン。</param>
        /// <returns>レスポンスオブジェクトの非同期列挙可能なシーケンス。</returns>
        IAsyncEnumerable<Response> CreateCompletionAsStream(Request request,
                                                            string modelId = null,
                                                            CancellationToken cancellationToken = default);
    }
}
