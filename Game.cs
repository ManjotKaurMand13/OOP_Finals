using System;
using System.Collections.Generic;

namespace RolePlayingGame
{
    class Game                      // Game Class handles the main interface of the overall game
    {
        public static List<Monster> monsterList = new List<Monster>();          // a static list of monsters to fight with

        static void Main(string[] args)             // main method
        {
            Start();                // Calling the Start method to start the game.
        }

        public static void Start()                      // method which defines the controls of the overall game.
        {
            createArmorList();                                                      // creates a predefined list of Armour
            createWeaponList();                                                     // creates a predefined list of Weapons
            createMonsterList();                                                    // creates a predefined list of Monsters
            
            Console.WriteLine("Welcome to the Game");
            Console.Write("Please Enter the Name: ");
            string playerName = Console.ReadLine();                                  // takes user input
            Random random = new Random();                                            // Random class object to create random number

            

            int gamesPlayed = 0;                                                     // counts the number of games played

            Hero player = new Hero(playerName, 30, 30, 100, 100, WeaponList.weaponList[0], ArmourList.armourList[0], 0, 0, 5);      // creates a player object with 1st weapon and 1st armour from the list as default and 5 coins.


            do                                                                  // do loop to display menu again and again
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Main Menu");
                Console.WriteLine("1 -> Statistics");
                Console.WriteLine("2 -> Inventory");
                Console.WriteLine("3 -> Fight");
                Console.WriteLine("");
                Console.Write("Your Choice: ");

                switch (Console.ReadLine())                                                 // using switch on user input.
                {
                    case "1":                                                                   // if user press 1
                        player.ShowStats();                                                     // display player information
                        Console.WriteLine("Number of Games Played: " + gamesPlayed);            // show the number of games played
                        break; 
                    case "2":                                                               // if the user press 2
                        Console.WriteLine("");
                        Console.WriteLine("");  
                        Console.WriteLine("1 -> Equip Weapon");
                        Console.WriteLine("2 -> Equip Armour");
                        Console.WriteLine("3 -> Show Inventory");
                        Console.WriteLine("4 -> Go Back!");
                        Console.Write("Your Choice: ");

                        switch (Console.ReadLine())                                             // using switch on user input
                        {
                            case "1":                                                           // if user press 1
                                Console.WriteLine("");
                                Console.WriteLine("");
                                int i = 1;
                                foreach (Weapon w in WeaponList.weaponList)                     // for each loop to iterate one by one on the weapon list
                                {
                                    Console.WriteLine(i + " -> Name: " + w.name + ", Power: " + w.power);                   // display the weapon name and power
                                    i++;                                                                                    // update the weapon count.
                                }
                                Console.Write("Your Choice: ");
                                int weaponchoice = Int32.Parse(Console.ReadLine()) - 1;                                     // Taking user input to select a weapon
                                player.EquipWeapon(WeaponList.weaponList[weaponchoice]);                                    // equiping the weapon of choice
                                break;
                            case "2":                                                               // if user press 2
                                Console.WriteLine("");
                                Console.WriteLine("");
                                i = 1;
                                foreach (Armour a in ArmourList.armourList)                                     // for each loop to iterate one by one on the armour list
                                {
                                    Console.WriteLine(i + " -> Name: " + a.name + ", Power: " + a.power);           // display the armour name and power
                                    i++;                                                                            // update the armour count.
                                }
                                Console.Write("Your Choice: ");
                                int armourchoice = Int32.Parse(Console.ReadLine()) - 1;                             // Taking user input to select a armour
                                player.EquipArmour(ArmourList.armourList[armourchoice]);                            // equiping the armour of choice
                                break;
                            case "3":                                                                           // if user presses 3
                                player.ShowInventory();                                                             // display the players current inventory
                                break;
                            case "4":                                                                           // if user presses 4
                                break;                                                                          // breaks out the main menu
                        }
                        break;
                    case "3":                                                                               // if the user presses 3
                        Fight f = new Fight();                                                              // create an object to instantiate fight
                        Monster m = monsterList[random.Next(0, monsterList.Count - 1)];                     // Selecting a monster to fight with
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Fight Begins: "+player.name+" VS "+m.name);                      // Display the player name and VS the monster name

                        int turn = 0;                                                                       // to detect who's turn it is. 0 means player's turn 1 means monster's turn
                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("");
                            if (turn == 0)                                                          // if it is player's turn
                            {
                                Console.WriteLine("It's " + player.name + "'s Turn!!!");
                                int damage = f.HeroTurn(player, m);                                 // calculates the damage done by player
                                Console.WriteLine("Damage Given to Monster: " + damage);            
                                m.currentHealth -= damage;                                          // reduce the monster health with the damage given by the player
                                Console.ReadLine();
                                if (f.Win(player, m))                                               // check if the player has won
                                    break;                                                          // end this game
                                turn = 1;                                                           // else it's Monster's turn
                            }
                            else
                            {
                                Console.WriteLine("It's Monster's Turn!!!");
                                int damage = f.MonsterTurn(player, m);                              // calculates the damage done by monster
                                Console.WriteLine("Damage Given to Player: " + damage);
                                player.currentHealth -= damage;                                     // reduce the player health with the damage given by the monster
                                Console.ReadLine();
                                if (f.Lost(player, m))                                              // check if the player has lost
                                    break;                                                      // end this game
                                turn = 0;                                                            // else it's player's turn
                            }
                            Console.WriteLine("1 -> Upgrade");
                            Console.WriteLine("2 -> Continue");
                            Console.Write("Your Choice: ");

                            switch (Console.ReadLine())                                                     // using switch on user input to check continue or Upgrade
                            {
                                case "1":                                                                   // if the user presses 1
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine("1 -> Upgrade Strength");
                                    Console.WriteLine("2 -> Upgrade Defence");
                                    Console.WriteLine("3 -> Upgrade Current Health");
                                    Console.Write("Your Choice: ");
                                    int upgradechoice = Int32.Parse(Console.ReadLine());                                // taking the user input

                                    if (upgradechoice == 1)                                                     // if the user presses 1
                                        player.Upgrade("Strength");                                             // Upgrade Player's strength
                                    if (upgradechoice == 2)                                                     // if the user presses 2
                                        player.Upgrade("Defence");                                               // Upgrade Player's defence
                                    if (upgradechoice == 3)                                                     // if the user presses 3
                                        player.Upgrade("Health");                                       // Upgrade Player's health
                                    break;
                                case "2":                                               // if user's press 2
                                    break;                                              // continue
                            }
                        } while (true);                                                    // while the game is being played
                        gamesPlayed++;                                                      // add the number of games played
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!!!");
                        break;
                }
            } while (true);


        }


        public static void createMonsterList()                          // creates the list of monsters
        {
            if(monsterList.Count > 0)                           // if the list is already populated
            {   
                monsterList.Clear();                            // clear the list
            }

            Random rand = new Random();                                     // random class object to randomize the values
            monsterList.Add(new Monster("Monster 1", rand.Next(60, 80), rand.Next(20, 50), 100, 100));                      // add a new monster with base strength between 60-80
            monsterList.Add(new Monster("Monster 2", rand.Next(80, 100), rand.Next(40, 70), 100, 100));                     // add a new monster with base strength between 80-100
            monsterList.Add(new Monster("Monster 3", rand.Next(100, 120), rand.Next(60, 100), 100, 100));                   // add a new monster with base strength between 100-120
            monsterList.Add(new Monster("Monster 4", rand.Next(120, 140), rand.Next(100, 140), 100, 100));                  // add a new monster with base strength between 120-140
            monsterList.Add(new Monster("Monster 5", rand.Next(140, 160), rand.Next(70, 150), 100, 100));                   // add a new monster with base strength between 140-160
        }

        public static void createWeaponList()                                   // creates a list of weapons
        {
            WeaponList.weaponList.Add(new Weapon("Glock 18",20));               // Adds a new Weapon with power 20
            WeaponList.weaponList.Add(new Weapon("AK47", 40));                          // Adds a new Weapon with power 40
            WeaponList.weaponList.Add(new Weapon("AWM", 60));                          // Adds a new Weapon with power 60
        }
        public static void createArmorList()                                    // creates a list of armour
        {
            ArmourList.armourList.Add(new Armour("Level 1", 10));                          // Adds a new armour with power 10
            ArmourList.armourList.Add(new Armour("Level 2", 20));                          // Adds a new armour with power 20
            ArmourList.armourList.Add(new Armour("Level 3", 30));                          // Adds a new armour with power 30
        }
    }
}
