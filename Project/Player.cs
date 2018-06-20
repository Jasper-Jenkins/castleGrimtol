using System.Collections.Generic;

using CastleGrimtol.Project;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
   //     public int Score { get; set; }
        public string Name { get; set; }
         
        public bool Alive {get;set;}
        public List<Item> Inventory { get; set; }

        public Player(string name){
            Name = name;
            Alive = true;
            Inventory = new List<Item>();
        }
    }
}