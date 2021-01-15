using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dealer
{
    using Deck;
    using System.Threading;

    public class Dealer
    {
        Deck deck;

        public Dealer()
        {
            deck = Deck.GetShuffledDeck();
        }

        public Card DealACard()
        {
            return deck.DealCard();
        }

        public IEnumerable<Card> DealAllCardsWithDelay(int dealingSpeedInMilis)
        {
            for (int i = 0; i < 52; i++)
            {
                Thread.Sleep(dealingSpeedInMilis);
                yield return deck.DealCard();
            }
        }
    }
}
