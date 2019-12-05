using System;

namespace WizardNinja
{
    public abstract class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;

        public string Race;

       // add a public "getter" property to access healtha
        public int Health
        {
            get {return health;}
            set { health = value;}
        }
        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Human(string n)
        {
            Name = n;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
            Race  = "Human";
        }
        
        // Add a constructor to assign custom values to all fields
         public Human(string n, int s, int i, int d, int h)
        {
            Name = n;
            Strength = s;
            Intelligence = i;
            Dexterity = d;
            health = h;
        }
        public void GetStats()
        {
            Console.WriteLine($"Name:         {Name}");
            Console.WriteLine($"Strength:     {Strength}");
            Console.WriteLine($"Intelligence: {Intelligence}");
            Console.WriteLine($"Dexterity:    {Dexterity}");
            Console.WriteLine($"Health:       {health}");
        }
        
        // Build Attack method
        public virtual int Attack(Human target)
        {
            int damage = 5 * Strength;
            target.health -= damage;
            return target.health;              
        }
        public virtual int Attack(Human target, int dmg)
        {
            target.health -= dmg;
            return target.health;
        }
    }
    
    
}