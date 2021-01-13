using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckMemorization
{
    public enum CardValue
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public enum CardKind
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }
    
    public class Card
    {
        public Card(int value, int kind)
        {
            Value = (CardValue)value;
            Kind = (CardKind)kind;
        }

        public CardValue Value { get; }
        public CardKind Kind { get; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            Card otherCard = (Card)obj;
            return otherCard.Value == Value && otherCard.Kind == Kind;
        }

        public override int GetHashCode()
        {
            return (int)Value + (int)Kind;
        }
    }
}
