using System;
using System.Collections.Generic;

namespace ironNinja
{
        class Buffet
    {
        public List<Food> Menu;
        
        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Veggie Burger", 500, false, false),
                new Food("Kung Pao Chicken", 800, true, true),
                new Food("Carrot Cake", 900, false, true),
                new Food("Fried Rice", 800, true, false),
                new Food("Buffalo Wings", 700, true, false),
                new Food("Burrito", 1000, true, false),
                new Food("Ramen", 800, true, false)
            };
        }
        
        public Food Serve()
        {
            Random rand = new Random();
           
            return Menu[(rand.Next(0, Menu.Count))];
            


        
        }   
    
    }
}