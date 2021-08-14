using System.Net.Http;

namespace ExpensesApp.Client.HttpUtils
{
    public class PublicHttpClient
    {
        public HttpClient Client { get; }

        public PublicHttpClient(HttpClient client) {
            Client = client;
        }
    }
}
