using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ManakaIntiface.WebClient
{
    public class SFMToyWebsocketClient
    {
        private ClientWebSocket client = new ClientWebSocket();

        public async Task ConnectSFMToyClient(string url = "ws://localhost:11451/ws/")
        {
            await client.ConnectAsync(new Uri(url), CancellationToken.None);
        }

        public async Task ReceiveMessages()
        {
            if (client.State == WebSocketState.Open)
            {
                ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await client.ReceiveAsync(buffer, CancellationToken.None);
                string message = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                Console.WriteLine($"Received message: {message}");
            }
        }
    }
}
