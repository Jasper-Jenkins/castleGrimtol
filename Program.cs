using System;
using CastleGrimtol.Project;
namespace textadventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Game castleGame = new Game();
            castleGame.Setup();
            Console.Clear();
           // bool inGame = true;
            while(castleGame.inGame){
              
                castleGame.Play();
            
            }
        }
    }
}
