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
            
           // bool inGame = true;
            while(castleGame.inGame){
            
            //use 'wizard' as your name to get cheats for accessing the scroll room and using the magic orb.






                castleGame.Play();
            
            }
        }
    }
}
