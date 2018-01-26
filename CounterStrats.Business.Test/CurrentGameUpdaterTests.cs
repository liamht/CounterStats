using NUnit;
using CounterStats.Business;
using CSGSI;
using Moq;
using NUnit.Framework;

namespace CounterStrats.Business.Test
{
    public class CurrentGameUpdaterTests
    {
        private CurrentGameUpdater _subject;

        [SetUp]
        public void SetUp()
        {
            //todo: Make PR to CSGSI on github to give CurrentGameUpdater an interface that can be mocked.
            //_subject = new CurrentGameUpdater();
        }
    }
}
