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
        private ClientWebSocket? client = new ClientWebSocket();
        public static CancellationTokenSource? _cts = new CancellationTokenSource();
        public IntifaceClient intifaceClient;

        public async Task ConnectSFMToyClient(string url = "ws://localhost:11451/ws/")
        {

            try
            {
                await client.ConnectAsync(new Uri(url), _cts.Token);
            }
            catch 
            {
                Console.WriteLine(
                    $"Can't connect, exiting!");
            }
        }

        public async void ReceiveMessages()
        {
            while (client.State == WebSocketState.Open)
            {
                ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await client.ReceiveAsync(buffer, CancellationToken.None);
                string message = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                TriggerToys(message);
            }
        }

        private async void TriggerToys(string message)
        {
            if (message != null || message != "")
            {
                message = new string(message.Where(Char.IsDigit).ToArray());
                int vibeStatus = int.Parse(message[0].ToString());
                int pistonStatus = int.Parse(message[1].ToString());
                double scalar = 0;

                if (intifaceClient.vibratorStf != null)
                {
                    if (vibeStatus == 1)
                    {
                        scalar = 0.5;
                    }
                    else if (vibeStatus == 2)
                    {
                        scalar = 1;
                    }
                    else
                    {
                        scalar = 0;
                    }

                    intifaceClient.TriggerSexToy(intifaceClient.vibratorStf, scalar);
                }

                if (intifaceClient.pistonStf != null)
                {
                    if (pistonStatus == 1)
                    {
                        scalar = 0.33;
                    }
                    else if (pistonStatus == 2)
                    {
                        scalar = 0.66;
                    }
                    else if (pistonStatus == 3)
                    {
                        scalar = 1;
                    }
                    else
                    {
                        scalar = 0;
                    }

                    intifaceClient.TriggerSexToy(intifaceClient.pistonStf, scalar);
                }
            }
        }
    }
}
