using Deck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
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
                set.Add(dealer.DealACard()).ShouldBeTrue();
            
            dealer.DealACard().IsEmpty().ShouldBeTrue();
        }

        [TestMethod]
        public void DealerDealsCardsWithVariableSpeed()
        {
            var speedMilis = 10;
            var elapsedMilis = GetMethodPerformance(() => GetAllCardsWithDelay(speedMilis));
            elapsedMilis.ShouldBeGreaterThanOrEqualTo(speedMilis * 52);
        }

        private long GetMethodPerformance(Action a)
        {
            var sw = new Stopwatch();
            sw.Start();
            a.Invoke();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private void GetAllCardsWithDelay(int speedMilis)
        {
            foreach (var _ in dealer.DealAllCardsWithDelay(speedMilis)) ;
        }
    }
}
