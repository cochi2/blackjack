using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deck.UnitTests
{
    [TestClass]
    public class DeckMemorizationTests
    {
        const int MaxNumberOfCards = 52;
        Deck Deck;

        [TestInitialize]
        public void Setup()
        {
            Deck = Deck.GetSortedDeck();
        }

        [TestMethod]
        public void WhenDeckDealsACardACardIsReceived()
        {
            Card cardReceived = Deck.DealCard();
            cardReceived.ShouldNotBeNull();
            cardReceived.Value.ShouldBeOneOf(expected: (CardValue[])Enum.GetValues(typeof(CardValue)).Cast<CardValue>());
            cardReceived.Kind.ShouldBeOneOf(expected: (CardKind[])Enum.GetValues(typeof(CardKind)).Cast<CardKind>());
        }

        [TestMethod]
        public void WhenMultipleCardsAreDealtTheyAreDifferent()
        {
            int numberOfCards = MaxNumberOfCards;
            Card[] cards = GetAsManyCardsOfDeck(numberOfCards);

            AssertCardsAreUnique(cards);
            AssertDeckCardsValuesAreDefined(cards);
        }

        private Card[] GetAsManyCardsOfDeck(int numberOfCards)
        {
            var cards = new Card[numberOfCards];
            for (int i = 0; i < numberOfCards; i++)
                cards[i] = Deck.DealCard();

            return cards;
        }

        private void AssertCardsAreUnique(Card[] cards)
        {
            var set = new HashSet<Card>();
            foreach (var card in cards)
                set.Add(card).ShouldBeTrue();
        }

        private void AssertDeckCardsValuesAreDefined(Card[] cards)
        {
            foreach (var card in cards)
                AssertCardValuesAreDefined(card);
        }

        private void AssertCardValuesAreDefined(Card card)
        {
            Enum.IsDefined(typeof(CardValue), card.Value).ShouldBeTrue();
            Enum.IsDefined(typeof(CardKind), card.Kind).ShouldBeTrue();
        }

        [TestMethod]
        public void WhenAskedForMoreThan52CardsReceiveEmptyCard()
        {
            GetAsManyCardsOfDeck(MaxNumberOfCards);
            Deck.DealCard().IsEmpty().ShouldBeTrue();
        }

        [TestMethod]
        public void WhenDeckIsShuffledCardsAreNotInOrder()
        {
            var shuffledDeck = Deck.GetShuffledDeck();
            var cardsInPosition = 0;
            for (int i = 0; i < MaxNumberOfCards; i++)
            {
                var sortedCard = Deck.DealCard();
                var shuffledCard = shuffledDeck.DealCard();
                AssertCardsAreNotEmpty(sortedCard, shuffledCard);
                if (sortedCard == shuffledCard)
                    cardsInPosition++;
            }
            cardsInPosition.ShouldBeLessThan(MaxNumberOfCards);
        }

        private static void AssertCardsAreNotEmpty(params Card[] cards)
        {
            foreach (var card in cards)
            {
                card.IsEmpty().ShouldBeFalse();
            }
        }

    }
}
