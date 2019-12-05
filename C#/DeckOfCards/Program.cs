using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Deck newDeck = new Deck();
            Player p1 = new Player();
            newDeck.Deal();
            newDeck.Deal();
            newDeck.Deal();
            p1.Draw(newDeck.Deal());
            p1.Draw(newDeck.Deal());
            p1.Draw(newDeck.Deal());
            p1.Discard(0);
            
            
          
            
            
            
            

        }
    }
}
