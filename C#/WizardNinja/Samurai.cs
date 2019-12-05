using System;

namespace WizardNinja
{
    
    public class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
        }
        public override int Attack(Human target)
        {
            int healthRemain = base.Attack(target);
            if (healthRemain < 50)
            {
                target.Health = 0;
            }
            return healthRemain;
        }

        public void Meditate()
        {
            health = 200;

        }

    }

    
}