using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
        }
       
    }


    // When a new deck is created, you’ll create a card of each rank for each suit and add them to the deck of cards, 
    //      which in this case will be a List of Card objects.
    //
    // A deck can perform the following actions:
    //     void Shuffle() -- Merges the discarded pile with the deck and shuffles the cards
    //     List<card> Deal(int numberOfCards) - returns a number of cards from the top of the deck
    //     void Discard(Card card) / void Discard(List<Card> cards) - returns a card from a player to the 
    //         discard pile	
    // 
    // A deck knows the following information about itself:
    //     int CardsRemaining -- number of cards left in the deck
    //     List<Card> DeckOfCards -- cards waiting to be dealt
    //     List<Card> DiscardedCards -- cards that have been played

    class Deck
    {
        // Properties
        public List<Card> DeckOfCards { get; set; }
        public List<Card> DiscardedCards { get; set; }

        public Deck()
        {
            // Populates the list
            this.DeckOfCards = new List<Card>();
            this.DiscardedCards = new List<Card>();
            for (int r = 2; r < 15; r++)
            {
                for (int s = 1; s < 5; s++)
                {
                    this.DeckOfCards.Add(new Card((Rank)r, (Suit)s));
                }
            }
        }
        // In case of more than one decks used for a game
        public Deck(int decksUsed)
        {
            this.DeckOfCards = new List<Card>();
            this.DiscardedCards = new List<Card>();
            while (decksUsed > 0)
            {
            for (int r = 2; r < 15; r++)
            {
                for (int s = 1; s < 5; s++)
                {
                    this.DeckOfCards.Add(new Card((Rank)r, (Suit)s));
                }
            }
            decksUsed--;
            }
        }
        public void Shuffle()
        {
        Card temp;
            // Adds all cards that not in the hands to one list for shuffling
        DeckOfCards.AddRange(DiscardedCards);
        DiscardedCards.Clear();
        Random random = new Random();
            // Cards will be shuffled
        int timesToShuffle = random.Next(300, 600);
        int cardToShuffle1, cardToShuffle2; 
            // Chnges place of 2 random cards 
        for (int x = 0; x < timesToShuffle; x++)
        {
            cardToShuffle1 = random.Next(this.DeckOfCards.Count());
            cardToShuffle2 = random.Next(this.DeckOfCards.Count());
            if (cardToShuffle1 != cardToShuffle2)
            {
                temp = this.DeckOfCards[cardToShuffle1];
                this.DeckOfCards[cardToShuffle1] = this.DeckOfCards[cardToShuffle2];
                this.DeckOfCards[cardToShuffle2] = temp;
            } 
        }
        }
        public List<Card> Deal(int numberOfCards)
        {
            // Will be dealt (numberOfCards)
            List<Card> cardsWillBeDealed = new List<Card>();
            for (int i = 0; i < numberOfCards; i++)
            {
                // Card taken
                Card tempCard = this.DeckOfCards.Last();
                cardsWillBeDealed.Add(tempCard);
                this.DeckOfCards.Remove(tempCard);
            }
            return cardsWillBeDealed;
        }
        public void Discard (Card card)
        {
            this.DiscardedCards.Add(card);
        }
        public void Discard(List<Card> cardsToDiscard)
        {
            DiscardedCards.AddRange(cardsToDiscard);
        }
    }
        public enum Suit
        {
            Spades = 1,
            Diamonds,
            Hearts,
            Clubs
        }

        public enum Rank
        {
            // Priority
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14
        }
        // What makes a card?
        //     A card is comprised of it’s suit and its rank.  Both of which are enumerations.
        //     These enumerations should be "Suit" and "Rank"
        class Card
        {
            // Properties
            public Suit Suit { get; set; }
            public Rank Rank { get; set; }
            // Constructor
            public Card(Rank r, Suit s)
            {
                this.Suit = s;
                this.Rank = r;
            }
        }
    }
