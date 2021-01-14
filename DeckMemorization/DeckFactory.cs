using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckMemorization
{
    public class DeckFactory
    {
        private DeckFactory() { }

        public static Deck CreateShuffledDeck()
        {
            return Deck.GetShuffledDeck();
        }

        public static Deck CreateSortedDeck()
        {
            return Deck.GetSortedDeck();
        }
    }
}
