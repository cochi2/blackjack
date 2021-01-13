using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckMemorization
{
    public class Deck
    {
        public const int MaxNumberOfCards = 52;
        int currentCard;
        
        public Deck()
        {
            currentCard = 0;
        }

        public Card DealCard()
        {
            if (currentCard >= MaxNumberOfCards)
                return null;

            var card = new Card(currentCard%13, currentCard/13);
            currentCard++;
            return card;
        }
    }
}
