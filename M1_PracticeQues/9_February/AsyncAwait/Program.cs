using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient _http = new HttpClient();

    static async Task Main(string[] args)
    {
        ServicePointManager.SecurityProtocol =
            SecurityProtocolType.Tls12 |
            SecurityProtocolType.Tls13;

        Console.WriteLine("Fetching JSON...");
        await FetchJsonAsync();
        Console.WriteLine("Done");
    }

    private static async Task FetchJsonAsync()
    {
        try
        {
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            string json = await _http.GetStringAsync(url);

            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
