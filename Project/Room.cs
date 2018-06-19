using System;
using System.Collections.Generic;
using CastleGrimtol.Project;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public Dictionary<string, Room> exits = new Dictionary<string, Room>();
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }


        // string Name { get; set; }
        // string Description { get; set; }
        // List<Item> Items { get; set; }
        //   void UseItem();
       
        
        public Room Go(string direction){
            if(exits.ContainsKey(direction)){
                return exits[direction];
            }
            return null;
        }
        
        // public Item itemsForRoom(List<Item> items) 
        // {
        //     if(items==empt)){
                
        //        //
        //         return exits[direction];
        //     }

        //     return null;    
        // }
        public void UseItem(Item item)
        {
           if(item.Name == "book"){
               Console.WriteLine(@"As you begin to read the book, smoke swirls around your body. 
You continue to read and as you finish the sentence a swirls of light and smoke engulfs you.");
           } 
           if(item.Name == "sword"){
                Console.WriteLine(@"You get into a fighting stance and prepare for battle.
The Dragon watches for a few seconds then engulfs you in massive fireball that burns you to ash
and melts the stone arond where you stood");
           }          
        }   

        public Room(string name, string description){
            Name = name;
            Description = description;
            Items = new List<Item>();
         //   exits = new Dictionary<string, Room>();
        }

    }
}