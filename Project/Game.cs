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
                 Console.WriteLine("There is a "+CurrentRoom.Items[0].Name + " in the room");
            }

            Console.WriteLine("Where do you want to go?");
                   
            string userInput = "";
            userInput = Console.ReadLine().ToLower();
            string[] input = userInput.Split(" ");
            switch(input[0])
            {
                case "go":
                if(CurrentRoom.Go(input[1])==null){
                    Console.Clear();
                    Console.WriteLine("You peer into the blackness and see only a wall ahead, your path is blocked");
                }else{
                    CurrentRoom = CurrentRoom.Go(input[1]);

                    Console.Clear();
                }
                break;
                case "take":
                for(var i = 0; i< CurrentRoom.Items.Count; i++){
                    Console.WriteLine(CurrentRoom.Items[i].Name);
                    
                    // if(input[1] == i.Name){
                    //     CurrentPlayer.Inventory.Add(i);
                    //     CurrentRoom.Items.Remove(i);
                    //     Console.WriteLine("You have picked up an item");
                    // }
                }
              
                break;
            };
            // Console.WriteLine("You are in the " +CurrentRoom.Name +" room!");
            
        }
        public void Setup()
        {   
          //  int[,] rooms = new int[,]{{},{},{},{},{}};
            Room room1 = new Room("Main", "Dark and Dreary, worn and weary");
            Room room2 = new Room("North", "Dark as fuck, better find a light");
            Room room3 = new Room("East", "Lots of light, better find some shade");
            Room room4 = new Room("South", "So much water, can you swim?");
            Room room5 = new Room("West", "So much fire, are you fire proof");
           
            Item torch = new Item("torch", "Helps brings light to the darkness");
            Item sword = new Item("sword", "Helps fight the darkness");
            Item book = new Item("book", "Helps to know the darkness");

            room1.exits.Add("north", room2);
            room1.exits.Add("east", room3);
            room1.exits.Add("west", room5);
            room1.Items.Add(torch);
            room1.Items.Add(sword);
            room1.Items.Add(book);
            
            room2.exits.Add("south", room1);

            room3.exits.Add("west", room1);

            room5.exits.Add("east", room1);

            CurrentRoom = room1;
            // room1.Exits("north");
            // room1.Exits("up");
            // room1.Exits("east");
            // room1.Exits("right");
            // room1.Exits("west");
            // room1.Exits("left");

            // Console.WriteLine(CurrentRoom.Description);
            // Console.WriteLine(CurrentPlayer.Name);          
        }
        public void UseItem(string itemName)
        {
            
        }
        // public Game(Room room, Player player){
        //     CurrentPlayer = player;
        //     CurrentRoom = room;
    
        // }
       
    }
}