using System;
using CastleGrimtol.Project;
namespace textadventure
{
    class Program
    {
        static void Main(string[] args)
        {
           

  // Player p1 = new Player(player1,);

            Game castleGame = new Game();
            castleGame.Setup();
            Console.Clear();
            bool inGame = true;
            while(inGame){
                // Console.Clear();
                castleGame.Play();
                // Console.WriteLine("You are in the " + castleGame.CurrentRoom.Name + " room!");
                // Console.WriteLine("Where do you want to go?");
                // string direction = Console.ReadLine();
                // castleGame.CurrentRoom.Go(direction);
                // Console.WriteLine("You are in the " +castleGame.CurrentRoom.Name +" room!");
            }


        }
    }
}
