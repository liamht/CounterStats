using System.Net;

namespace CounterStats.ApiCaller.HttpWebClient
{
    public class HttpWebClient : IHttpWebClient
    {
        public string DownloadString(string address)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(address);
            }
        }
    }
}
