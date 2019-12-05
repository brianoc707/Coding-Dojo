using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Deck
    {
        public List<Card> cards = new List<Card>();
        

        public Deck()
        {
            string stringVal = "";
            string suit = "";
            
            for(int j = 1; j <= 4; j++)
            {
                if(j == 1)
                {
                   suit = "Hearts"; 
                }
                if(j == 2)
                {
                    suit = "Clubs";
                }
                if(j == 3)
                {
                    suit = "Spades";
                }
                if(j == 4)
                {
                    suit = "Diamonds";
                }
                for(int i = 1; i <= 13; i++)
                    {
                    stringVal = i.ToString();
                    if(i == 1)
                    {
                        stringVal = "Ace";
                    }
                    if(i == 11)
                    {
                        stringVal = "Jack";
                    }
                    if( i == 12)
                    {
                        stringVal = "Queen";
                    }
                    if(i == 13)
                    {
                        stringVal = "King";
                    }
                    Card newCard = new Card(stringVal, suit, i);
                    cards.Add(newCard);
                    
                    }
            }
        
        
              
        }
        public Card Deal()
        {
            Card topcard = cards[0];
            Console.WriteLine($"{topcard.stringVal} of {topcard.suit} val {topcard.val}");
            cards.Remove(topcard);
            return topcard;
        }
        public Deck Reset()
        {
            Deck d1 = new Deck();
            return d1;
            
        }
        public void Shuffle()
        {
            Random r = new Random();

            for (var i = cards.Count - 1; i > 0; i--)
            {
                var temp = cards[i];
                var index = r.Next(0, i + 1);
                cards[i] = cards[index];
                cards[index] = temp;
            }
        }
        public void showDeck()
        {
              foreach(Card i in cards)
                {
                    Console.WriteLine($"{i.stringVal} of {i.suit} val {i.val}");
                }
        
        }
    }
}