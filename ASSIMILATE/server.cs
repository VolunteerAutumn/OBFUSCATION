using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server;

internal class Program
{
    static async Task Main(string[] args)
    {
        var listener = new TcpListener(IPAddress.Loopback, 8080);
        listener.Start();
        Console.WriteLine("Quote Server Started!");

        string[] quotes = [
            "Knowledge is power.",
            "Never give up.",
            "Stay hungry, stay foolish.",
            "Practice makes perfect.",
            "Eevee is adorable."
        ];

        var random = Random.Shared; 

        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();

            _ = Task.Run(async () =>
            {
                string endpoint = client.Client.RemoteEndPoint?.ToString() ?? "Unknown";
                Console.WriteLine($"[{DateTime.Now}] Connected: {endpoint}");

                using (client)
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                using (var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                {
                    try
                    {
                        string? request;
                        while ((request = await reader.ReadLineAsync()) != null)
                        {
                            request = request.Trim().ToUpperInvariant();

                            if (request == "EXIT") 
                                break;

                            if (request == "QUOTE")
                            {
                                string quote = quotes[random.Next(quotes.Length)];
                                Console.WriteLine($"[{DateTime.Now}] Sent quote to {endpoint}: {quote}");
                                
                                await writer.WriteLineAsync(quote);
                            }
                        }
                    }
                    catch
                    {
                    }

                    Console.WriteLine($"[{DateTime.Now}] Disconnected: {endpoint}");
                }
            });
        }
    }
}
