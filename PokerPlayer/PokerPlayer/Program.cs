using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }
    class PokerPlayer
    {
        public List<Card> Hand { get; set; }

        public void DrawHand(List<Card> cards)
        {
            this.Hand = cards;
        }
        // Enum of different hand types
        public enum HandType
        {
            // Prority
            HighCard = 1,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }
        // Rank of hand that player holds
        public HandType HandRank
        {
            get
            {
                if (HasRoyalFlush()) {return HandType.RoyalFlush; }
                else if (HasStraightFlush()) { return HandType.StraightFlush; }
                else if (HasFourOfAKind()) { return HandType.FourOfAKind; }
                else if (HasFullHouse()) { return HandType.FullHouse; }
                else if (HasFlush()) { return HandType.Flush; }
                else if (HasStraight()) { return HandType.Straight; }
                else if (HasThreeOfAKind()) { return HandType.ThreeOfAKind; }
                else if (HasTwoPair()) { return HandType.TwoPair; }
                else if (HasPair()) { return HandType.OnePair; }
                else { return HandType.HighCard; }
            }
        }
        // Constructor that isn't used
        public PokerPlayer() { }
        public bool HasPair()
        {
            return this.Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 1;
        }
        public bool HasTwoPair()
        {
            return this.Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2;
        }
        public bool HasThreeOfAKind()
        {
            return this.Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 3).Count() == 1;
        }
        public bool HasStraight()
        {
            var handInOrder = this.Hand.OrderBy(x => x.Rank).ToList();
            // Checks if its a A2345 first
            if (handInOrder.Last().Rank == Rank.Ace)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (handInOrder[i].Rank != handInOrder[i + 1].Rank - 1)
                    {
                        return false;
                    }
                }
            }
                // Other cases
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (handInOrder[i].Rank != handInOrder[i + 1].Rank - 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool HasFlush()
        {
            return this.Hand.Select(x => x.Suit).Distinct().Count() == 1;
        }
        public bool HasFullHouse()
        {
            return this.Hand.GroupBy(x => x.Rank).Count(x => x.Count() == 3) == 1 && this.Hand.GroupBy(x => x.Rank).Count(x => x.Count() == 2) == 1;
        }
        public bool HasFourOfAKind()
        {
            return this.Hand.GroupBy(x => x.Rank).Count(x => x.Count() == 4) == 1 && this.Hand.Select(x => x.Suit).Distinct().Count() == 4;
        }
        public bool HasStraightFlush()
        {
            return HasStraight() && HasFlush();
        }
        public bool HasRoyalFlush()
        {
            return HasStraightFlush() && this.Hand.OrderBy(x => x.Rank).Last().Rank == Rank.Ace;
        }
        public string ShowHand()
        {
            if (HasRoyalFlush()) { return "Royal Flush"; }
            else if (HasStraightFlush()) { return "Straight Flush"; }
            else if (HasFourOfAKind()) { return "Four of a Kind"; }
            else if (HasFullHouse()) { return "Full House"; }
            else if (HasFlush()) { return "Flush"; }
            else if (HasStraight()) { return "Straight"; }
            else if (HasThreeOfAKind()) { return "Three of a Kind"; }
            else if (HasTwoPair()) { return "Two Pair"; }
            else if (HasPair()) { return "One Pair"; }
            else
            {
                return "High Card";
            }
        }
    }
    //Guides to pasting your Deck and Card class

    //  *****Deck Class Start*****
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
                    this.DeckOfCards.Add(new Card(r, s));
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
                        this.DeckOfCards.Add(new Card(r, s));
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
        public void Discard(Card card)
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
        Spade = 1,
        Diamond,
        Heart,
        Club
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


    //  *****Deck Class End*******

    //  *****Card Class Start*****
    class Card
    {
        // Properties
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        // Constructor
        public Card(int cRank,int cSuit)
        {
            this.Suit = (Suit)cSuit;
            this.Rank = (Rank)cRank;
        }
    }


    //  *****Card Class End*******
}
