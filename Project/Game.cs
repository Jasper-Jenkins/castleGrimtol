using System;
using System.Collections.Generic;
using CastleGrimtol.Project;


namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public void Reset()
        {
            
        }

        public void Play(){
          //  Console.Clear();
            Console.WriteLine("You are in the " + CurrentRoom.Name + " room!");
            if(CurrentRoom.Items.Count == 0){
                 Console.WriteLine("The room is empty, except for you!");
            }else{
               
                string roomItems = "";
                for(var i =0; i<CurrentRoom.Items.Count;i++){
                    if(i == CurrentRoom.Items.Count-1&&CurrentRoom.Items.Count > 1){
                        roomItems += "and ";
                    }
                    roomItems += CurrentRoom.Items[i].Name + " ";
                }

                Console.WriteLine(@"There is a " + roomItems + "in the room");
            }

            Console.WriteLine("Where do you want to go?");
                   
            string userInput = "";
            userInput = Console.ReadLine().ToLower().Trim();
            string[] input = userInput.Split(" ");
            for(var i = 0; i < input.Length; i++){
                Console.WriteLine(input[i]);
            
            };
            switch(input[0])
            {
                case "go":
                if(input.Length == 1){
                    Console.Clear();
                    Console.WriteLine("You have chosen to go no where!");
                }else{    
                    if(CurrentRoom.Go(input[1])==null){
                        Console.Clear();
                        Console.WriteLine("You peer into the blackness and see only a wall ahead, your path is blocked");
                    }else{
                        CurrentRoom = CurrentRoom.Go(input[1]);
                        Console.Clear();
                    }
                }
                break;
                case "take":
                if(input.Length == 1){
                    Console.WriteLine("You have picked up nothing!");
                }else{ 
                    Console.Clear();
                    for(var i = 0; i < CurrentRoom.Items.Count; i++){
                     //   Console.WriteLine(CurrentRoom.Items[i].Name);
                        
                        if(input[1] == CurrentRoom.Items[i].Name){
                            string itemName = CurrentRoom.Items[i].Name;
                          //  Item take = new Item(CurrentRoom.Items[i].Name, CurrentRoom.Items[i].Description);
                            CurrentPlayer.Inventory.Add(CurrentRoom.Items[i]);
                            CurrentRoom.Items.Remove(CurrentRoom.Items[i]);
                            Console.WriteLine("You have picked up a "+ itemName);
                        };
                    }
                }
                break;
                case "inventory":
                    Console.Clear();
                   
                       if(CurrentPlayer.Inventory.Count == 0){
                            Console.WriteLine("You have no items!");
                       }else{
                            for(var i = 0; i < CurrentPlayer.Inventory.Count; i++){
                                Console.WriteLine(CurrentPlayer.Inventory[i].Name);
                            }
                        }
                break;
                case "help":
                    Console.Clear();
                    Console.Write(@"Commands: 

    go <cardinal direction>: 'go north'
    take <name of item in room>: 'take torch'
    inventory: 'inventory'
    help: 'help'

");
                break;
                case "use":
                    Console.Clear();
                    UseItem(input[1]);
                    // if(CurrentRoom.Name == "main" && input[1] == "book"){
                    //     Item usedItem = CurrentPlayer.Inventory.Find(x=> x.Name.Contains("book"));
                    //     CurrentRoom.UseItem(usedItem);
                    //     CurrentRoom = CurrentRoom.Go(input[1]);
                    // }
                    // else if(CurrentRoom.Name == "book" && input[1] == "book"){
                    //     Item usedItem = CurrentPlayer.Inventory.Find(x=> x.Name.Contains("book"));
                    //     CurrentRoom.UseItem(usedItem);
                    //     CurrentRoom = CurrentRoom.Go("main");
                    // }else{
                    //     Console.WriteLine(input[1] + " is of no use to you here.");
                    // }
                break;
            };
           
        }
        public void Setup()
        {   
          //  int[,] rooms = new int[,]{{},{},{},{},{}};
            Player player1 = new Player("Player1");
                      
            Room room1 = new Room("main", "Dark and Dreary, worn and weary");
            Room room2 = new Room("north", "Dark as fuck, better find a light");
            Room room3 = new Room("east", "Lots of light, better find some shade");
            Room room4 = new Room("book", "So much water, can you swim?");
            Room room5 = new Room("west", "So much fire, are you fire proof");
           
            Item torch = new Item("torch", "Helps brings light to the darkness");
            Item sword = new Item("sword", "Helps fight the darkness");
            Item book = new Item("book", "Helps to know the darkness");

            room1.exits.Add("north", room2);
            room1.exits.Add("east", room3);
            room1.exits.Add("west", room5);
            room1.exits.Add("book", room4);

            room1.Items.Add(torch);
            room1.Items.Add(sword);
            room1.Items.Add(book);
            


            room2.exits.Add("south", room1);

            room3.exits.Add("west", room1);

            room4.exits.Add("main", room1);





            room5.exits.Add("east", room1);

            CurrentRoom = room1;
            CurrentPlayer = player1;
              
        }
        public void UseItem(string itemName)
        {
           
           switch(itemName){
                case "book":
                    if(CurrentRoom.Name == "main"){
                        Item usedItem = CurrentPlayer.Inventory.Find(x=> x.Name.Contains("book"));
                        CurrentRoom.UseItem(usedItem);
                        CurrentRoom = CurrentRoom.Go(itemName);
                    }else if(CurrentRoom.Name == "book"){
                        Item usedItem = CurrentPlayer.Inventory.Find(x=> x.Name.Contains("book"));
                        CurrentRoom.UseItem(usedItem);
                        CurrentRoom = CurrentRoom.Go("main");
                    }else{
                        Console.WriteLine(itemName + " is of no use to you here.");
                    }
                break;
                case "sword":
                break;
                case "torch":
                break; 
           }
           
           
           
           
            if(CurrentRoom.Name == "main" && itemName == "book"){
                        Item usedItem = CurrentPlayer.Inventory.Find(x=> x.Name.Contains("book"));
                        CurrentRoom.UseItem(usedItem);
                        CurrentRoom = CurrentRoom.Go(itemName);
                    }
            else if(CurrentRoom.Name == "book" && itemName == "book"){
                Item usedItem = CurrentPlayer.Inventory.Find(x=> x.Name.Contains("book"));
                CurrentRoom.UseItem(usedItem);
                CurrentRoom = CurrentRoom.Go("main");
            }else{
                Console.WriteLine(itemName + " is of no use to you here.");
            }
        }
       
    }
}