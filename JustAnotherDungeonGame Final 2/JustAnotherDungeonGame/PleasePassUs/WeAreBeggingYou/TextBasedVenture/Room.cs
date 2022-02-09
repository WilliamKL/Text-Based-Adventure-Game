using System.Collections;
using System.Collections.Generic;
using System;

namespace DungeonGame
{
    public interface IRoomDelagate
    {
        //Software design pattern: Delegates
        Room Container { get; set; }
        Door getExit(string exitName);
        string getExits();
    }

    public class EndRoom : IRoomDelagate
    {
        public Room Container { get; set; }
        public Door getExit(string exitName)
        {
            return null;
        }

        public EndRoom()
        {

        }

        public string getExits()
        {
            return Container.getExits(this) + "\n*** You Win! ***"  + "\nYou can type 'Quit' to leave.";
        }

    }


    public class TrapRoom : IRoomDelagate
    {
        public Room Container { get; set; }
       
        public string MagicWord { set; get; }
        public Door getExit(string exitName)
        {
            return null;
        }
 
        public TrapRoom()
        {
            MagicWord = "Mario";
            //MagicWord = "mario";
            NotificationCenter.Instance.addObserver("PlayerWillSayWord", PlayerWillSayWord);
        }


        public string getExits()
        {
            return Container.getExits(this) + "\nYou cant leave until you solve this.\nWho am I?\nI jump high but I am not Michael Jordan.\nI have gloves but I am not Mickey Mouse\nI have a mustache but I am not Dr Robotnik";
               
        }

        
        public void PlayerWillSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if(player.currentRoom == Container)
            {
                string word = (string)notification.userInfo["word"];
                if(word != null)
                {
                    if(word.Equals(MagicWord))
                    {
                        player.informationMessage("~ You did it! ~");
                        Container.Delegate = null;
                    }
                }
            }
        }

    }

    public class TrapRoomTwo : IRoomDelagate
    {
        public Room Container { get; set; }

        public string MagicWord { set; get; }
        public Door getExit(string exitName)
        {
            return null;
        }

        public TrapRoomTwo()
        {
            MagicWord = "Gummy bear";
            NotificationCenter.Instance.addObserver("PlayerWillSayWord", PlayerWillSayWord);
        }


        public string getExits()
        {
            return Container.getExits(this) + "\nYou cant leave until you solve this.\nWhat do you call a bear with no teeth?";

        }


        public void PlayerWillSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
                string word = (string)notification.userInfo["word"];
                if (word != null)
                {
                    if (word.Equals(MagicWord))
                    {
                        player.informationMessage("~ You did it! ~");
                        Container.Delegate = null;
                    }
                }
            }
        }

    }


    public class Battle : IRoomDelagate
    {
        public Room Container { get; set; }
        public Door getExit(string exitName)
        {
            
            return Container.getExit(exitName, this);
        }
        public string getExits()
        {
            Encounters.FirstEncounter();

            return Container.getExits(this) + "\n~ Battle complete. The exits are shown now~\n";
            
        }
        public void PlayerDidSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
            }
        }
    }

    public class battleTwo : IRoomDelagate
    {
        public Room Container { get; set; }
        public Door getExit(string exitName)
        {

            return Container.getExit(exitName, this);
        }
        public string getExits()
        {
            Encounters.SecondEncounter();

            return Container.getExits(this) + "\n~ Battle complete. The exits are shown now~\n";

        }
        public void PlayerDidSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
            }
        }
    }

    public class battleThree : IRoomDelagate
    {
        public Room Container { get; set; }
        public Door getExit(string exitName)
        {

            return Container.getExit(exitName, this);
        }
        public string getExits()
        {
            Encounters.ThirdEncounter();

            return Container.getExits(this) + "\n~ Battle complete. The exits are shown now~\n";

        }
        public void PlayerDidSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
            }
        }
    }

    public class finalBattle : IRoomDelagate
    {
        public Room Container { get; set; }
        public Door getExit(string exitName)
        {

            return Container.getExit(exitName, this);
        }
        public string getExits()
        {
            Encounters.FinalEncounter();

            return Container.getExits(this) + "\n~ Battle complete. The exits are shown now~\n";

        }
        public void PlayerDidSayWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentRoom == Container)
            {
            }
        }
    }

    public class Room
    {
        private Dictionary<string, Door> exits;
        private string _tag;
        public string tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }
        private IRoomDelagate _delegate;
        public IRoomDelagate Delegate
        {
            get
            {
                return _delegate;
            }
            set
            {
                _delegate = value;
                if(_delegate != null)
                {
                    _delegate.Container = this;
                }
            }
        }

        private IItemContainer itemContainer;

        public Room() : this("No Tag")
        {

        }
        public Room(string tag)
        {
            exits = new Dictionary<string, Door>();
            this.tag = tag;
            _delegate = null;
            itemContainer = new ItemContainer();
        }
        public void drop(IItem item)
        {
            itemContainer.put(item);

        }

        public IItem pickup(string itemName)
        {
            return itemContainer.remove(itemName);
        }

        public void setExit(string exitName, Door door)
        {
            exits[exitName] = door;
        }

        public string getItems()
        {
            return itemContainer.contents();
        }

        public Door getExit(string exitName)
        {
            if(_delegate != null)
            {
                return _delegate.getExit(exitName);
            }
            else
            {
                return getExit(exitName, null);
            }
        }
        
        public Door getExit(string exitName, IRoomDelagate rDelegate)
        {
            if(rDelegate == Delegate)
            {
                Door door = null;
                exits.TryGetValue(exitName, out door);
                return door;
            }
            else
            {
                return null;
            }
        }

        public string getExits()
        {
            if(_delegate != null)
            {
                return _delegate.getExits();
            }
            else
            {
                return getExits(null);
            }
        }
        public string getExits(IRoomDelagate rDelegate)
        {
            if (rDelegate == Delegate)
            {
                string exitNames = "Exits directions are:";
                Dictionary<string, Door>.KeyCollection keys = exits.Keys;
                foreach(string exitName in keys)
                {
                    exitNames += " " + exitName;
                }
                return exitNames;
            }
            else
            {
                return "???";
            }
        }

        public string description()
        {
            return "You are in the " + this.tag + "\n" + this.getExits() + "\n" +this.getItems();
        }
    }

}
