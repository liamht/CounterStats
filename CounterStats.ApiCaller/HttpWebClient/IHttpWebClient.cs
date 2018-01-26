using System;

namespace CounterStats.ApiCaller.HttpWebClient
{
    public interface IHttpWebClient
    {
        string DownloadString(string address);
    }
}