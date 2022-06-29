using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayingGame
{
    class Weapon
    {
        public string name;                 // name of the weapon
        public int power;                       // power of the weapon

        public Weapon(string name, int power)
        {
            this.name = name;
            this.power = power;
        }
    }
}
