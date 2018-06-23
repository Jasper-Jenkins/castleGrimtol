using System;
using System.Collections.Generic;
using CastleGrimtol.Project;
using System.Threading.Tasks;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public Boolean inGame { get; set; }
        public void Reset()
        {
            Setup();
        }

        public void Play()
        {
            if(CurrentPlayer.Alive == false)
            {
                Console.WriteLine("You died!");
                Reset();
            }

            for (var i = 0; i < CurrentPlayer.Inventory.Count; i++)
            {
                Item searchy = CurrentPlayer.Inventory.Find(x => x.Name.Contains("torch"));
                if (searchy != null)
                {
              //     Console.Clear();
                   UseItem(searchy.Name);
                }
            }
            displayInventory();
            Console.WriteLine("You are in the " + CurrentRoom.Name + " room!");
            Console.WriteLine("What would you like to do!");
            string userInput = "";
            //      Console.ForegroundColor = ConsoleColor.DarkMagenta;
            userInput = Console.ReadLine().ToLower().Trim();
            //   Console.ForegroundColor = ConsoleColor.White;
            string[] input = userInput.Split(" ");
            if (input.Length > 2)
            {
                //Console.Write(input[1]+" "+input[2]);

                input[1] = input[1] + " " + input[2];
            }

            //USER COMMANDS
            switch (input[0])
            {
                case "restart":
                    Console.Clear();
                    Console.WriteLine(@"You have chosen to give up, but unfortunately for you that is not how you escape!

");
                    Reset();
                    break;
                case "quit":
                    inGame = false;
                    break;
                case "search":
                    Console.Clear();

                    if (CurrentRoom.Items.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine(CurrentRoom.Description);
                        Console.WriteLine("The room is empty, except for you!");
                    }
                    else
                    {
                        //  string roomItems = "";
                        Console.Write("There is a ");
                        // + roomItems + "in the room");

                        for (var i = 0; i < CurrentRoom.Items.Count; i++)
                        {
                            if (i == CurrentRoom.Items.Count - 1 && CurrentRoom.Items.Count > 1)
                            {
                                Console.Write("and ");
                            }

                            if (i != CurrentRoom.Items.Count && i != CurrentRoom.Items.Count - 1 && CurrentRoom.Items.Count > 2)
                            {
                                if (CurrentRoom.Items[i].Name == "torch")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(", ");
                                }
                                else if (CurrentRoom.Items[i].Name == "sword")
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(", ");
                                }
                                else if (CurrentRoom.Items[i].Name == "scroll")
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(", ");
                                }
                                else if (CurrentRoom.Items[i].Name == "ice orb")
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(", ");
                                }
                                else if (CurrentRoom.Items[i].Name == "fire orb")
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(", ");
                                }
                                else
                                {
                                    // if (CurrentRoom.Items[i].Name == "torch")
                                    // {
                                    //     Console.ForegroundColor = ConsoleColor.Yellow;
                                    //     Console.Write(CurrentRoom.Items[i].Name);
                                    //     Console.ForegroundColor = ConsoleColor.White;
                                    //     Console.Write(", ");
                                    // }
                                    // else if (CurrentRoom.Items[i].Name == "sword")
                                    // {
                                    //     Console.ForegroundColor = ConsoleColor.DarkGray;
                                    //     Console.Write(CurrentRoom.Items[i].Name);
                                    //     Console.ForegroundColor = ConsoleColor.White;
                                    //     Console.Write(", ");
                                    // }
                                    // else if (CurrentRoom.Items[i].Name == "scroll")
                                    // {
                                    //     Console.ForegroundColor = ConsoleColor.Magenta;
                                    //     Console.Write(CurrentRoom.Items[i].Name);
                                    //     Console.ForegroundColor = ConsoleColor.White;
                                    //     Console.Write(", ");
                                    // }
                                    // // Console.Write(@"" + CurrentRoom.Items[i].Name + ", "
                                    // );
                                }

                            }
                            else
                            {
                                if (CurrentRoom.Items[i].Name == "torch")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(" ");
                                }
                                else if (CurrentRoom.Items[i].Name == "sword")
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(" ");
                                }
                                else if (CurrentRoom.Items[i].Name == "scroll")
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(" ");
                                }
                                else if (CurrentRoom.Items[i].Name == "ice orb")
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(" ");
                                }
                                else if (CurrentRoom.Items[i].Name == "ice orb")
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(CurrentRoom.Items[i].Name + " ");
                                }
                            }
                        }
                        Console.Write(@"in the room
");
                        Console.WriteLine(CurrentRoom.Description);
                    }
                    break;
                case "go":
                    if (input.Length == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You have chosen to go no where!");
                    }
                    else
                    {
                        if (CurrentRoom.Go(input[1]) == null)
                        {
                            Console.Clear();
                            Console.WriteLine("You peer into the blackness and see only a wall ahead, your path is blocked");
                        }
                        else
                        {
                            CurrentRoom = CurrentRoom.Go(input[1]);
                            Console.Clear();
                        }
                    }
                    break;
                case "take":
                    if (input.Length == 1)
                    {
                        Console.WriteLine("You have picked up nothing!");
                    }
                    else
                    {
                       TakeItem(input[1]);
                 
                    }
                    break;
                case "inventory":
                    Console.Clear();

                    if (CurrentPlayer.Inventory.Count == 0)
                    {
                        Console.WriteLine("You have no items!");
                    }
                    else
                    {
                        for (var i = 0; i < CurrentPlayer.Inventory.Count; i++)
                        {
                            if (CurrentPlayer.Inventory[i].Name == "sword")
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (CurrentPlayer.Inventory[i].Name == "scroll")
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (CurrentPlayer.Inventory[i].Name == "torch")
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (CurrentPlayer.Inventory[i].Name == "ice orb")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (CurrentPlayer.Inventory[i].Name == "fire orb")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                            }
                        }
                    }
                    break;
                case "help":
                    Console.Clear();
                    Console.WriteLine(@"                        Commands: 
                    ___________________________________________________
                                                                    
                        go <cardinal direction>: 'go north'           
                        take <name of item in room>: 'take torch'     
                        use <name of item in invetory>: 'use sword'
                        drop <name of item in inventory>: 'drop torch'
                        search: 'search'
                        quit game: 'quit' 
                        restart game: 'restart'   
                        inventory: 'inventory'                        
                        help: 'help'                                  
                    ___________________________________________________
");
                    break;
                case "use":
                    if (input.Length == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You did not choose an item to use!");
                    }
                    else
                    {
                        Console.Clear();
                        UseItem(input[1]);
                    }
                    break;
                case "drop":
                    if (input.Length == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You did not choose an item to drop!");
                    }
                    else
                    {
                        Console.Clear();
                        DropItem(input[1]);
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\"" + input[0] + "\" is not a proper Command, figure out what else you can do");
                    break;
            };

        }
        public void Setup()
        {
            Console.WriteLine(@"                                       Enter your name traveler: 
                        ");
            string userName = Console.ReadLine().Trim();
            Player player1 = new Player(userName);
            inGame = true;
            string tester = "Welcome " + userName + " to the Super Fun Time Murder Dungeon!";
            for (int i = 0; i < tester.Length; i++)
            {
                var t = Task.Run(async delegate
                  {
                      await Task.Delay(80);
                      return tester[i];
                  });
                t.Wait();
                Console.Write("{0}", t.Result);
            }
            var k = Task.Run(async delegate
            {
                await Task.Delay(1000);
                return "";
            });
            k.Wait();
            Console.Clear();

            Room room1 = new Room("main", "The room is dark, other than a faint glow of a torch burning.");
            Room room2 = new Room("north", "The room is freezing, and everything is covered in ice.");
            Room room3 = new Room("east", "As you walk into the room, you notice the floor is just a giant pool of water");
            Room room4 = new Room("scroll", "The room emits a soft purple glow.");
            Room room5 = new Room("west", "So much fire! It is seriously hot in this room. As you enter the room the door behind you slams shut!");

            Item torch = new Item("torch", "Helps brings light to the darkness");
            Item sword = new Item("sword", "Helps fight your way through the darkness");
            Item scroll = new Item("scroll", "Helps to traverse the darkness");
            Item magicOrb = new Item("magic orb", "Emits a warm glowing energy");
            Item iceOrb = new Item("ice orb", "Emits a cold energy");
            Item fireOrb = new Item("fire orb", "Emits a fierce heat, but doesnt burn when touched.");


            //  room1.Exits.Add("scroll", room4);
            room2.Exits.Add("scroll", room4);
            room3.Exits.Add("scroll", room4);
            room5.Exits.Add("scroll", room4);
            //
            room1.Exits.Add("scroll", room4);
            room1.Exits.Add("north", room2);
            room1.Exits.Add("east", room3);
            room1.Exits.Add("west", room5);

            room1.Items.Add(torch);
            room1.Items.Add(sword);
            room1.Items.Add(scroll);
            room2.Items.Add(iceOrb);
            room3.Items.Add(fireOrb);
            room5.Items.Add(magicOrb);

            room2.Exits.Add("south", room1);

            room3.Exits.Add("west", room1);

            room4.Exits.Add("main", room1);

            room5.Exits.Add("east", room1);

            CurrentRoom = room1;
            CurrentPlayer = player1;

        }
        public void UseItem(string itemName)
        {
            switch (itemName)
            {

                case "torch":
                    Console.Clear();
                    Console.WriteLine("Room exits: ");
                    foreach (KeyValuePair<string, Room> i in CurrentRoom.Exits)
                    {
                        
                        if (i.Key != "scroll")
                        {
                            Console.Write("{0} ", i.Key);
                        }
                    }
                    Console.WriteLine(" ");
                    if (CurrentRoom.Items.Count == 0)
                    {
                      
                        Console.WriteLine(CurrentRoom.Description);
                        Console.WriteLine("The room is empty, except for you!");
                    }
                    else
                    {
                        //  string roomItems = "";
                        Console.Write("There is a ");
                        // + roomItems + "in the room");

                        for (var i = 0; i < CurrentRoom.Items.Count; i++)
                        {
                            if (i == CurrentRoom.Items.Count - 1 && CurrentRoom.Items.Count > 1)
                            {
                                Console.Write("and ");
                            }

                            if (i != CurrentRoom.Items.Count && i != CurrentRoom.Items.Count - 1 && CurrentRoom.Items.Count > 2)
                            {
                                if (CurrentRoom.Items[i].Name == "torch")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(", ");
                                }
                                else if (CurrentRoom.Items[i].Name == "sword")
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(", ");
                                }
                                else if (CurrentRoom.Items[i].Name == "scroll")
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(", ");
                                }
                                else
                                {
                                    if (CurrentRoom.Items[i].Name == "torch")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(CurrentRoom.Items[i].Name);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(", ");
                                    }
                                    else if (CurrentRoom.Items[i].Name == "sword")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.Write(CurrentRoom.Items[i].Name);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(", ");
                                    }
                                    else if (CurrentRoom.Items[i].Name == "scroll")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.Write(CurrentRoom.Items[i].Name);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(", ");
                                    }
                                    // Console.Write(@"" + CurrentRoom.Items[i].Name + ", "
                                    // );
                                }

                            }
                            else
                            {
                                if (CurrentRoom.Items[i].Name == "torch")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(" ");
                                }
                                else if (CurrentRoom.Items[i].Name == "sword")
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(" ");
                                }
                                else if (CurrentRoom.Items[i].Name == "scroll")
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(CurrentRoom.Items[i].Name);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(CurrentRoom.Items[i].Name + " ");
                                }
                            }
                        }
                        Console.Write(@"in the room
");
                        Console.WriteLine(CurrentRoom.Description);
                    }
                    break;
                case "scroll":
                    if (CurrentRoom.Name != "scroll")
                    {
                        Item usedItem = CurrentPlayer.Inventory.Find(x => x.Name.Contains("scroll"));
                        if (usedItem != null)
                        {
                            CurrentRoom.UseItem(usedItem);
                            CurrentRoom = CurrentRoom.Go(itemName);
                            // System.Console.WriteLine(itemName + " : " + CurrentRoom.Name );
                            break;
                        }
                        else
                        { //handle no scroll in inventory
                            Console.WriteLine("You do not have that item in your inventory");
                        }
                        break;
                    }
                    else if (CurrentRoom.Name == "scroll")
                    {
                        //System.Console.WriteLine("Using scroll in scroll Room..........");
                        Item usedItem = CurrentPlayer.Inventory.Find(x => x.Name.Contains("scroll"));
                        if (usedItem != null)
                        {
                            CurrentRoom.UseItem(usedItem);
                            CurrentRoom = CurrentRoom.Go("main");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You do not have that item in your inventory");
                        }
                    }
                    else
                    {
                        Console.WriteLine(itemName + " is of no use to you here.");
                    }
                    break;
                case "sword":
                    if (CurrentRoom.Name != "west")
                    {
                        Item usedItem = CurrentPlayer.Inventory.Find(x => x.Name.Contains("sword"));
                        if (usedItem != null)
                        {
                            // CurrentRoom.UseItem(usedItem);
                            // CurrentRoom = CurrentRoom.Go(itemName);
                            Console.WriteLine("You swing the sword around a few times to test its weight.");
                            break;
                        }
                        else
                        { //handle no book in inventory
                            Console.WriteLine("You do not have that item in your inventory");
                        }
                        break;
                    }
                    else if (CurrentRoom.Name == "west")
                    {
                        //System.Console.WriteLine("Using book in Book Room..........");
                        Item usedItem = CurrentPlayer.Inventory.Find(x => x.Name.Contains("sword"));
                        if (usedItem != null)
                        {
                            Item fire = CurrentPlayer.Inventory.Find(x => x.Name.Contains("fire orb"));
                            //Item ice = CurrentPlayer.Inventory.Fird(x => x.Name.Contains("ice orb"));
                            if (CurrentRoom.Activated != true)
                            {
                                if (fire != null)
                                {
                                    Console.WriteLine(@"  
        You move towards the Dragon knowing its either you or him. It is surprised momentarily 
        at the fact that such a puny creture would challenge its might. The Dragon opens its maw 
        and breathes forth a terrifying display of fire that washes over you. The fire orb glows 
        brightly as the Dragon fire surround you. You continue forward unhindered and slam the sword 
        into the Dragons belly. 
         ");
                                    CurrentRoom.Activated = true;
                                }
                                else
                                {
                                    Console.WriteLine(@"   
        You move towards the Dragon knowing its either you or him. It is surprised momentarily at the 
        fact that such a puny creture would challenge its might. The Dragon opens its maw and breathes 
        forth a terrifying display of fire that washes over you. The searing flame burns the flesh and 
        organs from your skeleton. You take one last awkward step as the last bit of muscle is burned 
        off your bones. 
        ");
                                    CurrentPlayer.Alive = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine(@"        You look at the corpse of the Dragon and wonder how the hell you could have survived! You poke at it a few times with your sword!");
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You do not have that item in your inventory");
                        }
                    }
                    else
                    {
                        Console.WriteLine(itemName + " is of no use to you here.");
                    }
                    break;
                case "magic orb":

                    break;
                case "ice orb":
                    if (CurrentRoom.Name != "east")
                    {
                        Console.WriteLine(@"The orb feels cool to the touch, but does nothing.");
                    }
                    else
                    {

                        Item frosty = CurrentPlayer.Inventory.Find(x => x.Name.Contains("ice orb"));
                        CurrentPlayer.Inventory.Remove(frosty);
                        CurrentRoom.Items.Add(frosty);

                        Console.WriteLine(@"
                        You kneel near the edge of the water and place the orb in. It slowly dips below the  
                        surface and a soft white-blue light flashes through the water. The sound of cracking ice 
                        fills your ears as you look over a now frozen lake.
                        ");
                        CurrentRoom.Activated = true;


                    }

                    break;
            }
        }

        public void DropItem(string itemName)
        {
            for (var i = 0; i < CurrentPlayer.Inventory.Count; i++)
            {
                if (itemName == CurrentPlayer.Inventory[i].Name)
                {
                    Console.Clear();
                    CurrentRoom.Items.Add(CurrentPlayer.Inventory[i]);
                    CurrentPlayer.Inventory.Remove(CurrentPlayer.Inventory[i]);
                    Console.WriteLine("You have dropped a " + itemName);
                }

            }
        }

        public void TakeItem(string itemName)
        {
            // switch(itemName){
            //     case :
            // }







            if (CurrentRoom.Name == "east" && (itemName == "fire orb" || itemName == "orb"))
            {
                Item ice = CurrentRoom.Items.Find(x => x.Name.Contains("ice orb"));
                if (ice != null && CurrentRoom.Activated == true)
                {
                    Console.Clear();
                    Console.WriteLine("Good work moron");
                    var checker = 0;
                    Item partialItemName = CurrentRoom.Items.Find(x => x.Name.Contains(itemName));
                    if (partialItemName != null)
                    {

                        string temp = partialItemName.Name;

                        for (var i = 0; i < CurrentRoom.Items.Count; i++)
                        {
                            if (temp == CurrentRoom.Items[i].Name)
                            {
                                checker++;
                            }
                            if (itemName != temp)
                            {
                                CurrentPlayer.Inventory.Add(partialItemName);
                                CurrentRoom.Items.Remove(partialItemName);
                                Console.WriteLine("You have picked up a " + partialItemName.Name);
                            }
                            else if (itemName == CurrentRoom.Items[i].Name)
                            {
                                string iName = CurrentRoom.Items[i].Name;
                                CurrentPlayer.Inventory.Add(CurrentRoom.Items[i]);
                                CurrentRoom.Items.Remove(CurrentRoom.Items[i]);
                                Console.WriteLine("You have picked up a " + iName);
                            }

                        }
                        if (checker < 1)
                        {
                            Console.WriteLine("There is no " + itemName + " in this room.");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You attempt to move towards the fire and fall into the water, only to find out the water is infested pirahnas. The eat you! The end");
                    CurrentPlayer.Alive = false;
                }
            }
            else if (CurrentRoom.Name == "west" && (itemName == "magic orb"|| itemName == "orb"))
            {
                Item item = CurrentRoom.Items.Find(x => x.Name.Contains(itemName));

             //   Console.WriteLine("We have made it this far");
                if (item != null)
                {
                    if (CurrentRoom.Activated != true)
                    {
                        
                        Console.WriteLine("You attempt to walk around the Dragon to get the Magic Orb. The Dragon lifts it arm and effortlessly crushes you to death");
                        CurrentPlayer.Alive = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Good work moron");
                        var checker = 0;
                        Item purpleOrb = CurrentRoom.Items.Find(x => x.Name.Contains(itemName));
                        if (purpleOrb != null)
                        {

                            string temp = purpleOrb.Name;

                            for (var i = 0; i < CurrentRoom.Items.Count; i++)
                            {
                                if (temp == CurrentRoom.Items[i].Name)
                                {
                                    checker++;
                                }
                                if (itemName != temp)
                                {
                                    CurrentPlayer.Inventory.Add(purpleOrb);
                                    CurrentRoom.Items.Remove(purpleOrb);
                                    Console.WriteLine("You have picked up a " + purpleOrb.Name);
                                }
                                else if (itemName == CurrentRoom.Items[i].Name)
                                {
                                    string iName = CurrentRoom.Items[i].Name;
                                    CurrentPlayer.Inventory.Add(CurrentRoom.Items[i]);
                                    CurrentRoom.Items.Remove(CurrentRoom.Items[i]);
                                    Console.WriteLine("You have picked up a " + iName);
                                }

                            }
                            if (checker < 1)
                            {
                                Console.WriteLine("There is no " + itemName + " in this room.");
                            }
                        }
                    }
                }
            }
            else
            {
                 Console.Clear();
           //     var checker = 0;
                Item partialItemName = CurrentRoom.Items.Find(x => x.Name.Contains(itemName));
                if (partialItemName != null && partialItemName.Name != "fire orb" && partialItemName.Name != "magic orb")
                {
                    string temp = partialItemName.Name;
                    for (var i = 0; i < CurrentRoom.Items.Count; i++)
                    {
                        if (temp == CurrentRoom.Items[i].Name)
                        {
                          //  Console.Clear();
                          //  checker++;
                            CurrentPlayer.Inventory.Add(partialItemName);
                            CurrentRoom.Items.Remove(partialItemName);
                            Console.WriteLine("You have picked up a " + partialItemName.Name);
                        }
                        // if (itemName != temp)
                        // {
                        //     CurrentPlayer.Inventory.Add(partialItemName);
                        //     CurrentRoom.Items.Remove(partialItemName);
                        //     Console.WriteLine("You have picked up a " + partialItemName.Name);
                        // }
                        // else if (itemName == CurrentRoom.Items[i].Name)
                        // {
                        //     string iName = CurrentRoom.Items[i].Name;
                        //     CurrentPlayer.Inventory.Add(CurrentRoom.Items[i]);
                        //     CurrentRoom.Items.Remove(CurrentRoom.Items[i]);
                        //     Console.WriteLine("You have picked up a " + iName);
                        // }

                    }
                }else{
                    Console.WriteLine("There is no " + itemName + " in this room.");
                    // Console.Clear();
                }
            }
        }
        public void displayInventory()
        {
            //  Console.Clear();

            if (CurrentPlayer.Inventory.Count == 0)
            {
                Console.WriteLine("You have no items!");
            }
            else
            {
                Console.WriteLine("Inventory: ");
                for (var i = 0; i < CurrentPlayer.Inventory.Count; i++)
                {
                    if (CurrentPlayer.Inventory[i].Name == "sword")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (CurrentPlayer.Inventory[i].Name == "scroll")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (CurrentPlayer.Inventory[i].Name == "torch")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (CurrentPlayer.Inventory[i].Name == "ice orb")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (CurrentPlayer.Inventory[i].Name == "fire orb")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine("                       " + CurrentPlayer.Inventory[i].Name + " ");
                    }
                }
            }
        }
        public void commands(string command)
        {

        }

        // public void RoomExits(){
        //     foreach(string k in CurrentRoom.Exits){
        //         Console.WriteLine($"{k}");
        //     }
        // }
    }
}