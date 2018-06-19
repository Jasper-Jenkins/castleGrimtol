using System.Collections.Generic;

using CastleGrimtol.Project;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
   //     public int Score { get; set; }
        public string Name { get; set; }
       
        public List<Item> Inventory { get; set; }

        public Player(string name, List<Item> items){
            Name = name;
            Inventory = items;
        }
    }
}