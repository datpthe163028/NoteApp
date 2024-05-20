using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace NoteApp.Module.Note.Service
{
    public interface INoteWebSocketService
    {
        Task ProcessWebSocketSession(WebSocket webSocket);
    }

    public class NoteWebSocketService : INoteWebSocketService
    {
        public async Task ProcessWebSocketSession(WebSocket webSocket)
        {
            var inputSegment = new ArraySegment<byte>(new byte[1024]);

            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(inputSegment, CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                else
                {
                    // Xử lý dữ liệu nhận được tại đây
                }
            }
        }
    }
}
