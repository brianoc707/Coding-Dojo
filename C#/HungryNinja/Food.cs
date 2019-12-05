using System;

namespace HungryNinja
{
        class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy; 
        public bool IsSweet; 
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food(string n, int c, bool sp, bool sw)
        {
            Name = n;
            Calories = c;
            IsSpicy = sp;
            IsSweet = sw;
    
        }
    }

}
