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
        King, 
        None
    }

    public enum CardKind
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs, 
        None
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

        public bool IsEmpty()
        {
            return Value == CardValue.None && Kind == CardKind.None;
        }

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

        public static bool operator ==(Card card1, Card card2)
        {
            return card1.Equals(card2);
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return !card1.Equals(card2);
        }
    }
}
