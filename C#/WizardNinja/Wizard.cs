using System;

namespace WizardNinja
{
    
    public class Wizard : Human 
    {
        public Wizard(string name) : base(name)
        {
            Intelligence =  25;
            health = 50;
        }

        public override int Attack(Human target)
        {
            int dmg  = 5 * Intelligence;
            health += dmg;
            return base.Attack(target, dmg);
        }

    }

    
}