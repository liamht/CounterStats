using System;
using System.Threading.Tasks;

namespace CounterStats.UI.Views.Elements
{
    public interface ISteamBrowserAuthenticator
    {
        Task<string> GetUsersSteamId();
    }
}