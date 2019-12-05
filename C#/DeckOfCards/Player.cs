using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Player
    {
        public string name;

        public List<Card> hand = new List<Card>();


       public Card Draw(Card card)
        {
            
            hand.Add(card);
            Console.WriteLine($"Card drawn is {card.stringVal} of {card.suit}");
            return card;
        }
        public void Discard(int card)
        {
            hand.RemoveAt(card);
            Console.WriteLine($"You have removed {hand[card].stringVal} {hand[card].suit}");
            Console.WriteLine(hand.Count);
        }
    }

    
}