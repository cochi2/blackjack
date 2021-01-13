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
        Deck deck;

        [TestInitialize]
        public void Setup()
        {
            deck = new Deck();
        }
        [TestMethod]
        public void WhenDeckDealsACardACardIsReceived()
        {
            Card cardReceived = deck.DealCard();
            cardReceived.ShouldNotBeNull();
            cardReceived.Value.ShouldBeOneOf(expected: (CardValue[])Enum.GetValues(typeof(CardValue)).Cast<CardValue>());
            cardReceived.Kind.ShouldBeOneOf(expected: (CardKind[])Enum.GetValues(typeof(CardKind)).Cast<CardKind>());
        }

        [TestMethod]
        public void WhenMultipleCardsAreDealtTheyAreDifferent()
        {
            int numberOfCards = Deck.MaxNumberOfCards;
            Card[] cards = GetAsManyCardsOfDeck(numberOfCards);

            AssertCardsAreUnique(cards);
            AssertDeckCardsValuesAreDefined(cards);
        }

        private void AssertDeckCardsValuesAreDefined(Card[] cards)
        {
            foreach (var card in cards)
            {
                AssertCardValuesAreDefined(card);
            }
        }
        
        private void AssertCardValuesAreDefined(Card card)
        {
            Enum.IsDefined(typeof(CardValue), card.Value).ShouldBeTrue();
            Enum.IsDefined(typeof(CardKind), card.Kind).ShouldBeTrue();
        }
        
        private void AssertCardsAreUnique(Card[] cards)
        {
            var set = new HashSet<Card>();
            foreach (var card in cards)
            {
                set.Add(card).ShouldBeTrue();
            }
        }

        private Card[] GetAsManyCardsOfDeck(int numberOfCards)
        {
            var cards = new Card[numberOfCards];
            for (int i = 0; i < numberOfCards; i++)
            {
                cards[i] = deck.DealCard();
            }

            return cards;
        }

        [TestMethod]
        public void WhenAskedForMoreThan52CardsReceiveException()
        {
            for (int i = 0; i < Deck.MaxNumberOfCards; i++)
            {
                deck.DealCard();
            }
            deck.DealCard().ShouldBeNull();
        }

        
    }
}
