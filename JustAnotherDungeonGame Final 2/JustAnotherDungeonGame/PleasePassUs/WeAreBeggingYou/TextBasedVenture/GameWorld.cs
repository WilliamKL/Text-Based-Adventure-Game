using System;

//Jeremy Kemp
//William Lovelace

namespace DungeonGame
{
	public class GameWorld
	{
		static private GameWorld _instance = null;
		static public GameWorld Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GameWorld();
				}
				return _instance;
			}
		}
	
		private Room _entrance;
		private Room _lobby;
		private Room _victorytrigger;

		public Room Entrance
		{
			get
			{
				return _entrance;
			}
		}
		public Room Lobby
		{
			get
			{
				return _lobby;
			}
		}
		private GameWorld()
		{
			createWorld();
			NotificationCenter.Instance.addObserver("EndGame", EndGame);
		}

		public void EndGame(Notification notification)
		{
			Player player = (Player)notification.Object;
			Room room = player.currentRoom;
			if (room == _victorytrigger)
			{
				player.informationMessage("~ You Won! ~");
			}

		}
		

		private void createWorld()
		{
			Room room1 = new Room("Main entrance to the deeper parts of the dungeon");                               //Room 1
			Room room2 = new Room("\nbedroom walkway of the dungeon.\nSeems like an old room with not much in it."); //Room 2
			Room room3 = new Room("\nstudy room of the dungeon.\nWhy would a study need to be in a dungeon?");		 //Room 3
			Room room4 = new Room("\na lobby room.");						                                         //Room 4
			Room room5 = new Room("\ncloset.\nHow anti-climactic");										             //Room 5
			Room room6 = new Room("\nsecond closet.\nYippie");                                                       //Room 6
			Room room7 = new Room("\ntrap Magic Super Doom Riddle Death Room");						                 //Room 7
			Room room8 = new Room("\nstaircase Area.\n A long staircase is in front of you which seems to lead to a higher level");//Room 8
			Room room9 = new Room("\nfirst room of the second level");											     //Room 9
			Room room10 = new Room("\nmain room of the second level");											     //Room 10
			Room room11 = new Room("\ndining hall of the death dungeon");											 //Room 11
			Room room12 = new Room("\nkitchen of the death dungeon. Maybe snacks are here.");                     //Room 12
			Room room13 = new Room("\na strange desert?");
			Room room14 = new Room("\nthe iron blood tournament");
			Room room15 = new Room("\nlaundary room.");
			Room room16 = new Room("\nbalchony of the death dungeon.\nMaybe you could get away by jumping over it.");

			//The rooms below are what would have been implemented originally but it ended up being too much.

			//Room room17 = new Room("Room 17");
			//Room room18 = new Room("Room 18");
			//Room room19 = new Room("Room 19");
			//Room room20 = new Room("Room 20");
			//Room room21 = new Room("Room 21");
			//Room room22 = new Room("Room 22");
			//Room room23 = new Room("Room 23");
			//Room room24 = new Room("Room 24");
			//Room room25 = new Room("Room 25");

			Room room0 = new Room("start screen. Use the command 'Name' to set a name, then use the command 'Done' when you are done.\n"); //Room 13

			//Exit room leading to victory
			//Room outside = new Room("Outside of the dungeon");
			

			//New Room routes
			//door = Door.MakeDoor(room,room, "", "");
			//connects a room to a door
			Door door = Door.MakeDoor(room1,room3, "north","south" );
			door.open();

			//Room routes from Room 1
			door = Door.MakeDoor(room1, room2, "northwest", "southeast");
			door = Door.MakeDoor(room1, room4, "northeast", "southwest");

			//Room routes from Room 2
			door = Door.MakeDoor(room2, room6, "north", "south");
			door = Door.MakeDoor(room2, room5, "northwest", "southeast");

			//Room routes from Room 3
			door = Door.MakeDoor(room3, room4, "east", "west");
			//door.close();

			//Room routes from Room 4
			//door = Door.MakeDoor(room4, room3, "west", "east");
			door = Door.MakeDoor(room4, room1, "southwest", "northeast");
			door = Door.MakeDoor(room4, room7, "southeast", "northwest");
			door = Door.MakeDoor(room4, room8, "northwest", "southeast");

			//Room routes from Room 7
			door = Door.MakeDoor(room7, room4, "northwest", "southeast");


			//Room routes from Room 8
			//door = Door.MakeDoor(room8, room4, "southeast", "northwest");
			door = Door.MakeDoor(room8, room9, "north", "south");

			//Room routes from room 9
			//door = Door.MakeDoor(room9,room8, "south", "north");
			door = Door.MakeDoor(room9,room10 , "east", "west");
			door = Door.MakeDoor(room9,room11 , "southeast", "northwest");

			//Room routes from room 10
			//door = Door.MakeDoor(room10,room9 , "west", "east");
			door = Door.MakeDoor(room10,room11 , "south", "north");
			door = Door.MakeDoor(room10,room16 , "east", "west");
			door = Door.MakeDoor(room10,room15, "southeast", "northwest");

			//Room routes from room 11
			//door = Door.MakeDoor(room11 ,room9 , "northwest","southeast");
			door = Door.MakeDoor(room11 ,room10, "north", "south");
			door = Door.MakeDoor(room11 ,room12, "south", "north");

			//Room routes from room 12
			//door = Door.MakeDoor(room12,room11, "north", "south");
			door = Door.MakeDoor(room12,room13, "west", "east");
			door = Door.MakeDoor(room12,room14, "southwest", "northeast");

			//Room routes from room 13
			//door = Door.MakeDoor(room13, room12, "east", "west");

			//Room routes from room 14
			//door = Door.MakeDoor(room14, room12, "northeast", "southwest");

			//Room routes from room 15
			door = Door.MakeDoor(room15, room10, "northwest", "southeast");


			//Room routes from room 16
			door = Door.MakeDoor(room16, room10, "west", "east");
			//door = Door.MakeDoor(room16, room17, "north", "south");

			//All the rooms below were commented out for time and simplicities sake.
			//we had this idea that the dungeon would be a lot bigger than what we presented
			//but as we added more rooms we had to think of more items, more encounters
			//and as that happened we started to get carried away with the amount of rooms we had
			//and focus less on the actual code behind these rooms.

			//Room routes from room 17
			//door = Door.MakeDoor(room17, room16, "south", "north");
			//door = Door.MakeDoor(room17,room22, "east", "west");
			//door = Door.MakeDoor(room17,room21, "southeast", "northwest");


			//Room routes from room 18
			//door = Door.MakeDoor(room18,room22, "west", "east");
			//door = Door.MakeDoor(room18,room19, "south", "north");

			//Room routes from room 19
			//door = Door.MakeDoor(room19,room18, "north", "south");
			//door = Door.MakeDoor(room19,room20, "east", "west");

			//Room routes from room 20
			//door = Door.MakeDoor(room20,room19, "west", "east");
			//door = Door.MakeDoor(room20,room21, "east", "west");
			//door = Door.MakeDoor(room20,room23, "southwest", "northeast");
			//door = Door.MakeDoor(room20,room24, "southeast", "northwest");

			//Room routes from room 21


			//Room routes from room 22
			//door = Door.MakeDoor(room22,room17, "west", "east");
			//door = Door.MakeDoor(room22,room18, "east", "west");
			//door = Door.MakeDoor(room22,room21, "south", "north");

			//Room routes from room 23
			//door = Door.MakeDoor(room23,room20, "northeast", "southeast");
			//door = Door.MakeDoor(room23,room25, "southwest", "northeast");

			//Room routes from room 24
			//door = Door.MakeDoor(room24,room20, "northwest", "southeast");

			//Room routes from room 25
			//none



			_entrance = room1;
			_lobby = room0;

			//This is where we make the encounters. Such as battles and trap rooms
			//The software design pattern, delegate is also used in this class to assign
			//monsters to certain rooms and make room 16 the ending room. 

			//Trap/Puzzle rooms
			TrapRoom tRoom = new TrapRoom();
			room7.Delegate = tRoom;

			TrapRoomTwo tRoomTwo = new TrapRoomTwo();
			room10.Delegate = tRoomTwo;

			//This is the room you need to go to end the game and win
			EndRoom eRoom = new EndRoom();
			room16.Delegate = eRoom;

			//These are rooms where battle encounters would start.
			//Not all monsters are created equal
			Battle bRoom = new Battle();
			room3.Delegate = bRoom;

			battleTwo bRoom2 = new battleTwo();
			room8.Delegate = bRoom2;

			battleThree bRoom3 = new battleThree();
			room16.Delegate = bRoom3;

			finalBattle bRoom4 = new finalBattle();
			room14.Delegate = bRoom4;



			//This is where we created items
			IItem sword = new Item("Sword", 50f);
			room2.drop(sword);

			IItem gSword = new Item("GreatSword", 100f);
			room3.drop(gSword);

			IItem Gold = new Item("GoldCoin", 0.0f);
			room1.drop(Gold);

			IItem LargeR = new Item("LargeRock", 1000f);
			room5.drop(LargeR);

			IItem SkullH = new Item("SkullHead", 0.0f);
			room6.drop(SkullH);

			//IItem SilverK = new Item("SilverKey", 0.0f, 0f, 0f);
			//IItem WoodenW = new Item("WoodenWand", 0.0f, 0f, 0f);

			IItem Necklace = new Item("Necklace", 0.0f);
			room13.drop(Necklace);

			//IItem GlassEye = new Item("GlassEye", 0.0f, 0f, 0f);

			IItem Vine = new Item("Vine", 0.0f);
			room14.drop(Vine);

			//IItem Axe = new Item("Axe", 0.0f, 0f, 0f);

			IItem apple = new Item("Apple", 0.0f);
			room12.drop(apple);

			IItem akumaBelt = new Item("Belt", 0.0f);
			room12.drop(akumaBelt);


		}


	}
}
