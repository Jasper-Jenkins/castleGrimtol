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

            if (CurrentPlayer.Alive == false)
            {
                Console.WriteLine("You died!");
                Console.WriteLine("Would you like to play again?");
                string choose = Console.ReadLine();
                if (choose == "yes")
                {
                    Reset();

                }
                else if (choose == "no")
                { //DOESNT WORK PROPERLY.. itnerates through the game for a bit before the inGame is caught.
                    inGame = false;
                }

            }

            // for (var i = 0; i < CurrentPlayer.Inventory.Count; i++)
            // {
            Item searchy = CurrentPlayer.Inventory.Find(x => x.Name.Contains("torch"));
            if (searchy != null)
            {
                UseTorch(searchy.Name);
            }

            Console.WriteLine("You are in the " + CurrentRoom.Name + " room!");
            if (CurrentRoom.Name == "west") //WEST ROOM IS ON FIRE SO YOU SHOULDNT NEED A TORCH TO SEE WHATS IN THE ROOM.
            {
                Item torchy = CurrentPlayer.Inventory.Find(x => x.Name.Contains("torch"));
                if (torchy != null)
                {

                }
                else
                {
                    UseItem("torch");
                }
                if (CurrentRoom.Activated != true)
                {
                    Console.WriteLine(@"A Dragon is in the room");
                }
                else
                {
                    Console.WriteLine(@"The Dragaon lays dead.");
                }
            }
            displayInventory();
            if (CurrentPlayer.Deaths == 0)
            {

            }
            else
            {
                Console.WriteLine($"You have died {CurrentPlayer.Deaths} times.");
            }

            Console.WriteLine("What would you like to do!");
            Console.WriteLine("\'help\' can guide you");
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

            // Item reveal = CurrentPlayer.Inventory.Find(x=>x.Name.Contains("torch"));
            // if(reveal == null){




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

                    Item torchy = CurrentPlayer.Inventory.Find(x => x.Name.Contains("torch"));

                    if (torchy == null)
                    {
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
                                    else if (CurrentRoom.Items[i].Name == "magic orb")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
                                    else if (CurrentRoom.Items[i].Name == "fire orb")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write(CurrentRoom.Items[i].Name);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(" ");
                                    }
                                    else if (CurrentRoom.Items[i].Name == "magic orb")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
                    }
                    else
                    {
                        Console.Write(@"Your ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(@"torch ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(@"burns brightly and reveals all that is in the room already.
                ");
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

            // }else{
            //     Console.WriteLine("Your torch is already revealing all for you to see.");
            // }

        }
        public void Setup()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(@"                                       Enter your name traveler: 
                        ");
            string userName = Console.ReadLine().Trim();
            if (userName == "")
            {
                Console.Clear();
                Console.WriteLine("You must enter a name!");
                Console.WriteLine(@"                                       Enter your name traveler: 
                        ");
                userName = Console.ReadLine().Trim();
            }
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
            Room room5 = new Room("west", "So much fire! It is seriously hot in this room.");// As you enter the room the door behind you slams shut!

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
            if (CurrentPlayer.Name == "wizard")
            {
                CurrentPlayer.Inventory.Add(magicOrb);
                CurrentPlayer.Inventory.Add(scroll);
            }

        }

        public void UseTorch(string torch)
        {

            // Console.Clear();
            // Item torchch = CurrentPlayer.Inventory.Find(x=> x.Name.Contains("torch"));
            // if(torchch != null){

            // }
            //         if(CurrentRoom.Name == "west"){  
            //         Console.WriteLine(@"
            // The room is already illuminated");
            //         }

            //  if(CurrentRoom.Lit == false){
            //   Console.Clear();
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
                        else if (CurrentRoom.Items[i].Name == "ice orb")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(CurrentRoom.Items[i].Name);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(", ");
                        }
                        else if (CurrentRoom.Items[i].Name == "magic orb")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
                        else if (CurrentRoom.Items[i].Name == "ice orb")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(CurrentRoom.Items[i].Name);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ");
                        }
                        else if (CurrentRoom.Items[i].Name == "magic orb")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(CurrentRoom.Items[i].Name);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ");
                        }
                        else if (CurrentRoom.Items[i].Name == "fire orb")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
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
                Console.Write(@"in the room.
");
                Console.WriteLine(CurrentRoom.Description);
            }
            CurrentRoom.Lit = true;
            //    }
            // else {
            //     Console.WriteLine("The room is already illuminated");
            //     CurrentRoom.Lit = false;
            // }

        }

        public void UseItem(string itemName)
        {
            switch (itemName)
            {
                case "torch":

                    Console.Write(@"Your ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(@"torch ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(@"burns brightly and reveals all that is in the room already.
");

                    break;

                //    break;
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
        at the fact that such a puny creature would challenge its might. The Dragon opens its maw 
        and breathes forth a terrifying display of fire that washes over you. The fire orb glows 
        brightly as the Dragon fire surround you. You continue forward unhindered and slam the sword 
        into the Dragons belly. 
         ");
                                    CurrentRoom.Activated = true;
                                }
                                else
                                {
                                    Item scrolly = CurrentPlayer.Inventory.Find(x => x.Name.Contains("scroll"));
                                    if (scrolly != null)
                                    {
                                        Console.WriteLine(@"   
        You move towards the Dragon knowing its either you or him. It is surprised momentarily at the 
        fact that such a puny creature would challenge its might. The Dragon opens its maw and breathes 
        forth a terrifying display of fire that washes over you. The searing flame burns the flesh and 
        organs from your skeleton. You take one last awkward step as the last bit of muscle is burned 
        off your bones. 
        ");
                                        Console.Write(@"
        The");
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.Write(@" scroll");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(@" in your pocket senses the energy in your body diminishing. Your skeleton becomes 
        translucent and stands up and walks back to the entrance of the room. The Dragon looks on in 
        confusion as your body reforms back to its original state at the entrance of the room. 
        ");
                                        CurrentPlayer.Deaths++;
                                    }
                                    else
                                    {
                                        Console.WriteLine(@"   
        You move towards the Dragon knowing its either you or him. It is surprised momentarily at the 
        fact that such a puny creature would challenge its might. The Dragon opens its maw and breathes 
        forth a terrifying display of fire that washes over you. The searing flame burns the flesh and 
        organs from your skeleton. You take one last awkward step as the last bit of muscle is burned 
        off your bones. 
        ");
                                        CurrentPlayer.Alive = false;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(@"       
        You look at the corpse of the Dragon and wonder how the hell you could have survived! 
        You poke at it a few times with your sword!");
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
                    if (CurrentRoom.Name != "scroll")
                    {
                        Console.WriteLine(@"
                Your focused attention on the orb causes it to flare to light, emitting a
                crackling energy that flashes through your body. Other than the invigorating
                sensation that courses through your body, using the orb does nothing else in this room.
                        ");
                    }
                    else
                    {
                        Console.WriteLine(@"
                Your focused attention on the orb causes it to flare to light, emitting a 
                crackling energy that flashes across your body. The sensation of being pulled 
                updward lasts only a moment and you find yourself in the forest. You have escaped the
                dungeon. Winnder Winnder Chicken Dinner.
                        ");

                        Console.WriteLine(@"
                        Would you like to play again?");
                        string yaDone = "";
                        yaDone = Console.ReadLine().ToLower().Trim();

                        switch (yaDone)
                        {
                            case "yes":
                                {

                                }
                                break;
                        }
                        if (yaDone == "yes")
                        {
                            inGame = true;
                            Setup();
                        }
                        else if (yaDone == "no")
                        {
                            inGame = false;

                        }

                    }
                    break;
                case "ice orb":
                    if (CurrentRoom.Name != "east")
                    {
                        Console.WriteLine(@"
        The orb feels cool to the touch, but does nothing.");
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

        public void youDied(string doa)
        {
            string temp = doa;

            switch (temp)
            {
                case "yes":
                    {

                    }
                    break;
                default:
                    {

                    }
                    break;
            }

        }

        public void TakeItem(string itemName) //taking magic orb doesnt work right now
        {
            //   switch(itemName){
            //     case "fire orb":
            //     {

            //     } 
            //     break;       
            //   }  
            if (CurrentRoom.Name == "east" && (itemName == "fire orb" || itemName == "orb"))
            {
                Item ice = CurrentRoom.Items.Find(x => x.Name.Contains("ice orb"));
                //  Console.ForegroundColor = ConsoleColor.DarkRed;
                Item fire = CurrentRoom.Items.Find(x => x.Name.Contains("fire orb"));
                Console.ForegroundColor = ConsoleColor.White;
                if (ice != null && CurrentRoom.Activated == true)
                {
                    Console.Clear();
                    //  Console.WriteLine("Good work moron");
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
                    Console.Write(@"
        You jump into the water and swim towards the ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{fire.Name}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(@". As you paddle intently across the  
        water you feel a slimey and firm sensation sliding around the back of your neck
        working its way quickly around to the front. A quick jerk and you feel your neck 
        break as you are pulled into the dark water.
                    ");
                    Item magic = CurrentPlayer.Inventory.Find(x => x.Name.Contains("scroll"));
                    if (magic != null)
                    {
                        Console.Write(@"
        The");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(@" scroll");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(@" in your pocket senses the energy in your body diminishing. You become 
        translucent and slip from the grasp of the creature that pulled you under water.
        Your body floats back to the entrance of the room and reforms. You are oddly aware 
        that you just died and are surprised to find yourself looking back at the water 
        you were just swimming through. 
                    ");
                        CurrentPlayer.Deaths++;
                    }
                    else
                    {

                        CurrentPlayer.Alive = false;
                    }
                }
            }
            else if (CurrentRoom.Name == "west" && itemName == "magic orb") //( || itemName == "orb")
            {
                Item item = CurrentRoom.Items.Find(x => x.Name.Contains("magic orb"));
                Console.Clear();
                //    Console.WriteLine("We have made it this far");
                if (item != null)
                {
                    if (CurrentRoom.Activated != true)
                    {
                        Item magic = CurrentPlayer.Inventory.Find(x => x.Name.Contains("scroll"));
                        if (magic != null)
                        {
                            //    Console.Clear();
                            Console.WriteLine(@"
        You attempt to walk around the Dragon to get the Magic Orb. 
        The Dragon lifts it arm and effortlessly crushes you to death!
                        ");
                            Console.Write(@"
        The");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(@" scroll");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(@" in your pocket senses the energy in your body diminishing. You become 
        translucent and slip from beneath the heavy hand of the Dragon. The Dragon watches 
        as your body floats back to the entrance of the room and reforms. Upset at the fact 
        dinner has escaped, the dragon takes a deep breath as if its preparing to burn you 
        to ash.       
        ");
                            CurrentPlayer.Deaths++;
                        }
                        else
                        {

                            Console.WriteLine(@"
        You attempt to walk around the Dragon to get the Magic Orb. 
        The Dragon lifts it arm and effortlessly crushes you to death!
                        ");
                            CurrentPlayer.Alive = false;
                        }
                        //             Console.WriteLine(@"
                        // You attempt to walk around the Dragon to get the Magic Orb. 
                        // he Dragon lifts it arm and effortlessly crushes you to death
                        //             ");
                        //             CurrentPlayer.Alive = false;

                    }
                    else
                    {
                        Console.Clear();
                        //Console.WriteLine("Good work moron");
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
                }
                else
                {
                    Console.WriteLine("There is no " + itemName + " in this room.");
                    // Console.Clear();
                }
            }
        }
        public void displayInventory()
        {
            if (CurrentPlayer.Inventory.Count == 0)
            {
                Console.WriteLine("You have no items!");
            }
            else
            {

                Console.WriteLine(@"
                Inventory: ");
                for (var i = 0; i < CurrentPlayer.Inventory.Count; i++)
                {
                    if (CurrentPlayer.Inventory[i].Name == "sword")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
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
                    else if (CurrentPlayer.Inventory[i].Name == "magic orb")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
        public void commands()
        {



        }

        // public void RoomExits(){
        //     foreach(string k in CurrentRoom.Exits){
        //         Console.WriteLine($"{k}");
        //     }
        // }
    }
}