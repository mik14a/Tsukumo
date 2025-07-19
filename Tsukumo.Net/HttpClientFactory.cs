using System.Net.Http;

#if NET8_0_OR_GREATER
using System;
using System.Net;
using System.Net.Sockets;
#endif

namespace Tsukumo
{
    public static class HttpClientFactory
    {
        public static HttpClient CreateHttpClient() {
#if NET8_0_OR_GREATER
            var handler = new SocketsHttpHandler {
                ConnectCallback = async (context, cancellationToken) => {
                    var addresses = await Dns.GetHostAddressesAsync(context.DnsEndPoint.Host, cancellationToken);
                    var ipv4 = Array.Find(addresses, a => a.AddressFamily == AddressFamily.InterNetwork)
                               ?? throw new Exception("IPv4アドレスが見つかりません");
                    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    await socket.ConnectAsync(ipv4, context.DnsEndPoint.Port, cancellationToken);
                    return new NetworkStream(socket, ownsSocket: true);
                }
            };
            return new HttpClient(handler);
#else
            return new HttpClient();
#endif
        }
    }
}
