using System;

namespace WizardNinja
{
    
    public class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }

        public override int Attack(Human target)
        {
            Random r = new Random();
            int dmg = 5 * Dexterity;
            if (r.Next(1, 5) == 1)
            {
                dmg += 10;
            }

            return base.Attack(target, dmg);
        }

        public void Steal(Human target)
        {
            target.Health -= 5;
            health += 5;
        }

    }

    
}