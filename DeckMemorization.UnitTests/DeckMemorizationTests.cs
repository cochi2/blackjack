using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DeckMemorization.UnitTests
{
    [TestClass]
    public class DeckMemorizationTests
    {
        [TestMethod]
        public void WhenDeckDealsACardACardIsReceived()
        {
            Deck deck = new Deck();
            Card cardReceived = deck.DealCard();
            cardReceived.ShouldNotBeNull();
            cardReceived.Value.ShouldBeOneOf(expected: (CardValue[])Enum.GetValues(typeof(CardValue)).Cast<CardValue>());
            cardReceived.Kind.ShouldBeOneOf(expected: (CardKind[])Enum.GetValues(typeof(CardKind)).Cast<CardKind>());
        }

        [TestMethod]
        public void WhenTwoCardsAreDealtTheyAreDifferent()
        {
            Deck deck = new Deck();
            Card card1 = deck.DealCard();
            Card card2 = deck.DealCard();
            card1.ShouldNotBe(card2);
        }


        [Ignore]
        [TestMethod]
        public void ADeckContains52DifferentCards()
        {
            //var cards = new HashSet<Card>(comparer: new CardComparer());
            //var deck = new Deck();

            //for (int i = 0; i < 52; i++)
            //{
            //    var card = deck.DealCard();
            //    cards.Add(card).ShouldBeTrue();
            //}
        }
    }
}
