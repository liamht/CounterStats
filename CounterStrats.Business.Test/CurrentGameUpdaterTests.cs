using NUnit;
using CounterStats.Business;
using NUnit.Framework;

namespace CounterStrats.Business.Test
{
    public class CurrentGameUpdaterTests
    {
        private CurrentGameUpdater _subject;

        [SetUp]
        public void SetUp()
        {
            _subject = new CurrentGameUpdater();
        }
    }
}
