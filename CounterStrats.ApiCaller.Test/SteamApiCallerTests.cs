using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStats.ApiCaller;
using CounterStats.ApiCaller.HttpWebClient;
using Moq;
using NUnit.Framework;

namespace CounterStrats.ApiCaller.Test
{
    public class SteamApiCallerTests
    {
        private SteamApiCaller _subject;
        private Mock<HttpWebClient> _client;

        [SetUp]
        public void SetUp()
        {
            _client = new Mock<HttpWebClient>();
            
            _subject = new SteamApiCaller(_client.Object);
        }
    }
}
