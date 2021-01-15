using Deck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dealer.UnitTests
{
    [TestClass]
    public class DealerTests
    {
        Dealer dealer;

        [TestInitialize]
        public void setup()
        {
            dealer = new Dealer();
        }

        [TestMethod]
        public void DealerDealsACard()
        {
            var card = dealer.DealACard();
            card.ShouldNotBeNull();
            card.IsEmpty().ShouldBeFalse();
        }

        [TestMethod]
        public void DealerWithOneDeckDealsUpTo52Cards()
        {
            var set = new HashSet<Card>();
            for(int i = 0; i < 52; i++)
            {
                set.Add(dealer.DealACard()).ShouldBeTrue();
            }
            dealer.DealACard().IsEmpty().ShouldBeTrue();
        }

        [TestMethod]
        public void DealerDealsCardsWithVariableSpeed()
        {
            var speedMilis = 10;
            var sw = new Stopwatch();
            sw.Start();
            foreach(var _ in dealer.DealAllCardsWithDelay(speedMilis)) ;
            sw.Stop();
            sw.ElapsedMilliseconds.ShouldBeGreaterThanOrEqualTo(speedMilis * 52);
        }
    }
}
