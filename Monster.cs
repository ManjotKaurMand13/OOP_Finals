using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayingGame
{
    class Monster       
    {
        public string name;                 // name of the monster
        public int baseStrength;                // strength value of the monster
        public int baseDefence;                // defence value of the monster
        public int originalHealth;                // total health value of the monster
        public int currentHealth;                // currenth health value of the monster

        public Monster(string name, int baseStrength, int baseDefence, int originalHealth, int currentHealth)
        {
            this.name = name;
            this.baseStrength = baseStrength;
            this.baseDefence = baseDefence;
            this.originalHealth = originalHealth;
            this.currentHealth = currentHealth;
        }
    }
}
