using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckMemorization
{
    public enum CardValue
    {
        Ace
    }

    public enum CardKind
    {
        Spades
    }
    
    public class Card
    {
        public Card()
        {
            Value = CardValue.Ace;
            Kind = CardKind.Spades;
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

        public override string ToString()
        {
            return $"{Value} of {Kind}";
        }
    }
}
