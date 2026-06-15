using System.Net.Sockets;
using System.Text;

namespace Client;

internal class Program
{
    static void Main(string[] args)
    {
        using var client = new TcpClient();
        client.Connect("127.0.0.1", 8080);
        Console.WriteLine("Connected to server!");

        using var stream = client.GetStream();
        var buffer = new byte[1024];

        while (true)
        {
            Console.WriteLine("\n1 - Get Quote\n0 - Disconnect");
            string choice = Console.ReadLine() ?? "";

            if (choice == "0")
            {
                byte[] exitMessage = Encoding.UTF8.GetBytes("EXIT");
                stream.Write(exitMessage, 0, exitMessage.Length);
                break;
            }

            if (choice == "1")
            {
                byte[] request = Encoding.UTF8.GetBytes("QUOTE");
                stream.Write(request, 0, request.Length);

                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string quote = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine($"\nQuote:\n{quote}");
            }
        }

        Console.WriteLine("Disconnected.");
    }
}
