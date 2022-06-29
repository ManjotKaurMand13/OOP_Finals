using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayingGame
{
    class Armour
    {
        public string name;                       // name of the armour
        public int power;                       // power of the armour

        public Armour(string name, int power)
        {
            this.name = name;
            this.power = power;
        }
    }
}
