using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckMemorization
{
    public abstract class Deck
    {
        protected const int MaxNumberOfCards = 52;
        protected const int CardsOfSameKind = 13;
        protected readonly Card EmptyCard = new Card((int)CardValue.None, (int)CardKind.None);
        protected int currentCard;
        protected int[] cards;
        
        private Deck()
        {
            currentCard = 0;
            cards = Enumerable.Range(0, MaxNumberOfCards).ToArray();
        }

        public Card DealCard()
        {
            if (currentCard >= MaxNumberOfCards)
                return EmptyCard;

            var card = new Card(cards[currentCard] % CardsOfSameKind, cards[currentCard] / CardsOfSameKind);
            currentCard++;
            return card;
        }

        public static Deck GetShuffledDeck()
        {
            return new ShuffledDeck();
        }

        public static Deck GetSortedDeck()
        {
            return new SortedDeck();
        }

        private class SortedDeck : Deck
        {
            public SortedDeck() : base()
            {
            }
        }

        private class ShuffledDeck : Deck
        {
            public ShuffledDeck() : base()
            {
                var rand = new Random();
                
                for (int swappedCard = 0; swappedCard < MaxNumberOfCards; swappedCard++)
                {
                    var pickedValue = rand.Next(swappedCard, MaxNumberOfCards);
                    SwapCards(swappedCard, pickedValue);
                }
            }

            private void SwapCards(int pos1, int pos2)
            {
                var temp = cards[currentCard];
                cards[currentCard] = cards[pos2];
                cards[pos2] = temp;
            }
        }
    }
}
