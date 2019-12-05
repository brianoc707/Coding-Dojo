using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        public bool IsFull
        {
            get
            {
                if(calorieIntake > 1200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        
        }   
        
        // add a constructor
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();


        }
        
        // add a public "getter" property called "IsFull"
        
        // build out the Eat method
        public void Eat(Food item)
        {
            if(IsFull != true)
            {
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.WriteLine(item.Name);
                
                if(item.IsSweet == true)
                {
                    Console.WriteLine("This is Sweet");
                }
                if(item.IsSpicy == true)
                {
                    Console.WriteLine("This is Spicy");
                }
                
            }
            else
            {
                Console.WriteLine("Your Ninja is Full");
            }
        }
    }
}
