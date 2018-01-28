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
        private Mock<IHttpWebClient> _client;
        private const string apiKey = "Test";

        [SetUp]
        public void SetUp()
        {
            _client = new Mock<IHttpWebClient>();
            _client.Setup(c => c.DownloadString(It.IsAny<string>())).Returns("");

            _subject = new SteamApiCaller(_client.Object, apiKey);
        }

        [Test]
        public void GetPlayerSummaries_CallsApiForCorrectCall()
        {
            var steamId = "steamId";
            var url = $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={apiKey}&steamids={steamId}";
            _subject.GetPlayerSummaries(steamId);

            _client.Verify(c => c.DownloadString(url), Times.Once);
        }
    }
}
