using System;

namespace DungeonGame
{
	//This is where we have the combat encounters in the game. Their are a total of 4 combat encounters (2 on each floor)
	//Different encounters offer different challenges and they each have their own set of health and damage they can deal.
	class Encounters
	{
		static Random rand = new Random();
		public static void FirstEncounter()
		{
			Console.WriteLine("\nAs you walk through the dungeon you come across an old bag of bones");
			Console.WriteLine("\nThe bones rise up and point towards your direction....");
			Console.WriteLine("\nFight for your life!.");
			Console.ReadKey();
			Combat(false, "Crippled Skeleton man!", 3, 5);
		}

		public static void SecondEncounter()
		{
			Console.WriteLine("\nAs you walk through the dungeon you come across an old bag of bones");
			Console.WriteLine("\nThe bones rise up and point towards your direction....");
			Console.WriteLine("\nFight for your life!...Again!!");
			Console.ReadKey();
			Combat(false, "Skeleton man 2.0", 7, 10);
		}

		public static void ThirdEncounter()
		{
			Console.WriteLine("\nLooks like you've stumbled upon another enemy...");
			Console.WriteLine("\nThis is a brute known only for destruction and violence!");
			Console.WriteLine("\nVictory is slim and death is almost certain as you fight the...");
			Console.ReadKey();
			Combat(false, "Rancor", 10, 10);
		}

		public static void FinalEncounter()
		{
			Console.WriteLine("\nLooks like you've stumbled upon another enemy...");
			Console.WriteLine("\nAkuma has been looking for a worthy challenge.");
			Console.WriteLine("\nDeath is almost certainly assured");
			Console.ReadKey();
			Combat(false, "Akuma, The Raging Demon!", 20, 30);
		}

		//Encounter tools
		public static void Combat(bool random, string name, int power, int health)
		{
			string n = "";
			int p = 0;
			int h = 0;
			if (random)
			{

			}
			else
			{
				n = name;
				p = power;
				h = health;
			}
			while (h > 0)
			{
				//This is where we were able to make the user input for what they can do in these encounters
				//The plaer has 4 options: Attack, Defend, Heal,and Run
				Console.WriteLine("" + n);
				Console.WriteLine("Power level" + p + " Health level: " + h);
				Console.WriteLine("=====================");
				Console.WriteLine("|     ⚔ Attack ⚔     |");
				Console.WriteLine("|     ✧ Defend ✧     |");
				Console.WriteLine("|      ♥ Heal ♥      |");
				Console.WriteLine("|      ? Run ?       |");
				Console.WriteLine("=====================");
				Console.WriteLine("Potions: " + Program.currentPlayer.potion + " Health: " + Program.currentPlayer.health);
				string input = Console.ReadLine();
				if (input.ToLower() == "A" || input.ToLower() == "Attack" || input.ToLower() == "a")
				{
					//Attack
					Console.WriteLine("Your enemy is struck by your awesome power! The " +n+ " strikes you back.");
					int damage = p - Program.currentPlayer.armorVal;
					if (damage < 0)
						damage = 0;
					int attack = rand.Next(1, Program.currentPlayer.weaponVal) +rand.Next(1,4);
					Console.WriteLine("You lose " + damage + "  health and you dealt " + attack + " damage");
					Program.currentPlayer.health -= damage;
					h -= attack;
				}
				else if (input.ToLower() == "D" || input.ToLower() == "Defend" || input.ToLower() == "d")
				{
					//Defend
					Console.WriteLine("You raise your guard and hope to live. " + n + " strikes you and deals less damage.");
					int damage = (p/4) - Program.currentPlayer.armorVal;
					if (damage < 0)
					{
						damage = 0;
					}
					int attack = rand.Next(1, Program.currentPlayer.weaponVal) /2;
					Console.WriteLine("You lose " + damage + "  health and you dealt " + attack + " damage");
					Program.currentPlayer.health -= damage;
					h -= attack;
				}

				else if (input.ToLower() == "H" || input.ToLower() == "Heal" || input.ToLower() == "h")
				{
					//Heal
					if(Program.currentPlayer.potion == 0)
					{
						Console.WriteLine("You reach for a healing rune but it seems you ran out.");
						int damage = p - Program.currentPlayer.armorVal;
						if(damage < 0)
						{
							damage = 0;
						}
						Console.WriteLine("You took " + damage + " damage from " + n);
					}
					else
					{
						int potVal = 5;
						Console.WriteLine("You pulled out a healing rune and crush it in your hand.. You gained " +  potVal + "health");
						Program.currentPlayer.health += potVal;
						Console.WriteLine("While healing " + n + " attacks you, dealing.");
						int damage = (p / 2) - Program.currentPlayer.armorVal;
						if(damage < 0)
						{
							damage = 0;
						}
						Console.WriteLine("You took " + damage + " damage.");
					}
					Console.ReadKey();
				}//Run
				else if (input.ToLower() == "R" || input.ToLower() == "Run" || input.ToLower() == "r")
				{
					Console.WriteLine("Why would you think you can run away? You dont wanan run into the darkness.");
				}
				Console.ReadKey();
			}
		}
	}
}


