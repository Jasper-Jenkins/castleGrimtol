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


            //         var t = Task.Run(async delegate
            //           {
            //              await Task.Delay(1000);
            //              return 42;
            //           });
            //   t.Wait();
            //   Console.WriteLine("Task t Status: {0}, Result: {1}",
            //                     t.Status, t.Result);
            if (CurrentPlayer.Alive == true)
            {
                Console.WriteLine("Still Alive!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You fucked up!");
                Reset();
            }
            //  Console.Clear();
            Console.WriteLine("You are in the " + CurrentRoom.Name + " room!");
            // if (CurrentRoom.Items.Count == 0)
            // {
            //     Console.WriteLine(CurrentRoom.Description);
            //     Console.WriteLine("The room is empty, except for you!");
            // }
            // else
            // {
            //     string roomItems = "";
            //     for (var i = 0; i < CurrentRoom.Items.Count; i++)
            //     {
            //         if (i == CurrentRoom.Items.Count - 1 && CurrentRoom.Items.Count > 1)
            //         {
            //             roomItems += "and ";
            //         }
            //         roomItems += CurrentRoom.Items[i].Name + " ";
            //     }
            //     Console.WriteLine(CurrentRoom.Description);
            //     Console.WriteLine(@"There is a " + roomItems + "in the room");
            // }
            Console.WriteLine("What would you like to do!");

            string userInput = "";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            userInput = Console.ReadLine().ToLower().Trim();
            Console.ForegroundColor = ConsoleColor.White;
            string[] input = userInput.Split(" ");
            if(input.Length>2){
                //Console.Write(input[1]+" "+input[2]);

                input[1] = input[1]+ " "+ input[2];
            }
            // for (var i = 0; i < input.Length; i++)
            // {
            //   if(input.Length>2){
            //     Console.Write(input[1]+" "+input[2]);
            //   }
            //      var j = Task.Run(async delegate
            // {
            //     await Task.Delay(1000);
            //     return "";
            // });
            // j.Wait();
            // };
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
                                //Console.Write(CurrentRoom.Items[i].Name + " ");
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
                        Console.Clear();
                        var checker = 0;
                        for (var i = 0; i < CurrentRoom.Items.Count; i++)
                        {
                            if (input[1] == CurrentRoom.Items[i].Name)
                            {
                                checker++;
                            }

                            if (input[1] == CurrentRoom.Items[i].Name)
                            {
                                string itemName = CurrentRoom.Items[i].Name;
                                //  Item take = new Item(CurrentRoom.Items[i].Name, CurrentRoom.Items[i].Description);
                                CurrentPlayer.Inventory.Add(CurrentRoom.Items[i]);
                                CurrentRoom.Items.Remove(CurrentRoom.Items[i]);
                                Console.WriteLine("You have picked up a " + itemName);
                            }

                        }
                        if (checker < 1)
                        {
                            Console.WriteLine("There is no " + input[1] + " in this room.");
                        }
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
            Console.WriteLine("Enter your name traveler: ");
            string userName = Console.ReadLine();
            Player player1 = new Player(userName);
            inGame = true;
            string tester = "Welcome " +userName+ " to the Super Fun Time Murder Dungeon!";
            for (int i = 0; i < tester.Length; i++)
            {
                var t = Task.Run(async delegate
                  {
                      await Task.Delay(100);
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

            Room room1 = new Room("main", "The room is pitch black, other than a faint glow on the ground.");
            Room room2 = new Room("north", "The room is freezing, and everything is covered in ice.");
            Room room3 = new Room("east", "As you walk into the room, you notice the floor is just a giant pool of water");
            Room room4 = new Room("scroll", "The room emits a soft purple glow.");
            Room room5 = new Room("west", "So much fire! It is seriously hot in here.");

            Item torch = new Item("torch", "Helps brings light to the darkness");
            Item sword = new Item("sword", "Helps fight your way through the darkness");
            Item scroll = new Item("scroll", "Helps to traverse the darkness");
            Item orb = new Item("orb", "Emits a warm energy");
            Item ice = new Item("ice orb", "Emits a cold energy");
            room1.exits.Add("scroll", room4);
            room1.exits.Add("north", room2);
            room1.exits.Add("east", room3);
            room1.exits.Add("west", room5);

            room1.Items.Add(torch);
            room1.Items.Add(sword);
            room1.Items.Add(scroll);


            room2.exits.Add("south", room1);

            room3.exits.Add("west", room1);

            room4.exits.Add("main", room1);

            room5.exits.Add("east", room1);

            CurrentRoom = room1;
            CurrentPlayer = player1;

        }
        public void UseItem(string itemName)
        {
            switch (itemName)
            {
                case "scroll":
                    if (CurrentRoom.Name == "main")
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
                            CurrentRoom.UseItem(usedItem);
                            CurrentPlayer.Alive = false;
                            //CurrentRoom = CurrentRoom.Go("main");
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
                case "orb":

                break;
                case "ice orb":
                
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
    }
}