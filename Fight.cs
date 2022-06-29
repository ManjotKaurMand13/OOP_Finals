using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayingGame
{
    class Fight
    {
        public int HeroTurn(Hero hero, Monster monster)                     // calculates the damage done by hero and returns it
        {
            return hero.baseStrength + hero.equippedWeapon.power;
        }

        public int MonsterTurn(Hero hero, Monster monster)                      // calculates the damage done by monster and returns it
        {
            return monster.baseStrength - (hero.baseDefence + hero.equippedArmour.power);
        }

        public bool Win(Hero hero, Monster monster)                                 // check if the player has won return true
        {
            if(monster.currentHealth <= 0)                                  // check if the monster helath is zero or less
            {
                Game.monsterList.Remove(monster);                               // remove the monster form the list
                hero.wins++;
                hero.coins += 2;
                Console.WriteLine(hero.name + " has won the game!!!");
                return true;
            }
            return false;
        }

        public bool Lost(Hero hero, Monster monster)                                // check if the player has lost return true
        {
            if(hero.currentHealth <= 0)                                                     // check if player health is zero or less
            {
                hero.currentHealth = hero.originalHealth;                               // reset the player health
                hero.loss++;
                Game.createMonsterList();                                               // regenerate the monsters list
                Console.WriteLine(hero.name + " has lost the game!!!");
                return true;
            }
            return false;
        }
    }
}
