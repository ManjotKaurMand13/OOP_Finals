using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayingGame
{
    class Hero
    {
        public string name;                         // name of the hero
        public int baseStrength;                    // strength value of the hero
        public int baseDefence;                     // defence value of the hero
        public int originalHealth;                  // the total health of the hero
        public int currentHealth;                   // current health of the hero
        public Weapon equippedWeapon;               // weapon equipped by the hero
        public Armour equippedArmour;               // armour equipped by the hero
        public int wins;               // number of wins by the hero
        public int loss;               // number of loss by the hero
        public int coins;               // number of coins by the hero

        public Hero(string name, int baseStrength, int baseDefence, int originalHealth, int currentHealth, Weapon equippedWeapon, Armour equippedArmour, int wins, int loss, int coins)
        {
            this.name = name;
            this.baseStrength = baseStrength;
            this.baseDefence = baseDefence;
            this.originalHealth = originalHealth;
            this.currentHealth = currentHealth;
            this.equippedWeapon = equippedWeapon;
            this.equippedArmour = equippedArmour;
            this.wins = wins;
            this.loss = loss;
            this.coins = coins;
        }

        public void ShowStats()                     // a method that shows the stats of the player
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Base Strength: " + baseStrength);
            Console.WriteLine("Base Defence: " + baseDefence);
            Console.WriteLine("Original Health: " + originalHealth);
            Console.WriteLine("Current Health: " + currentHealth);
            Console.WriteLine("Coins: " + coins);
            Console.WriteLine("Wins: " + wins);
            Console.WriteLine("Loss: " + loss);
        }

        public void ShowInventory()                                     // a method that display the inventory
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Equipped Weapon: "+equippedWeapon.name);
            Console.WriteLine("Equipped Armour: "+equippedArmour.name);
        }

        public void EquipWeapon(Weapon weapon)
        {
            equippedWeapon = weapon;
        }
        public void EquipArmour(Armour armour)
        {
            equippedArmour = armour;
        }

        public void Upgrade(string upgradeName)                                         // (Bonus) upgrade the player powers using coins
        {
            if (coins < 2)                              // if the user has enough coins
            {
                Console.WriteLine("Not Enough Coins!!!");
                return;
            }
            if(upgradeName.Equals("Strength") && coins > 2)                 // if the user has to buy strength
            {
                this.coins -= 2;                                            // deduct the coins
                this.baseStrength += 10;                            // increase the strength
            }
            else if(upgradeName.Equals("Defence") && coins > 2)
            {
                this.coins -= 2;
                this.baseDefence += 10;                                             // increase the defence
            }
            else if(upgradeName.Equals("Health") && coins > 2)
            {
                this.coins -= 2;
                this.currentHealth += 20;                                   // increase the healths
            }
        }


    }
}
