using System;

namespace WastedEarth
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

           
            using(Game1 game = new Game1())
            {
                game.Run();
            }

            //MainMenu menu = new MainMenu();
            //StatesManager statesManager = new StatesManager();
            
            //while(StatesManager.state !=0)
            //switch(StatesManager.state)
            //{
                   
            //    case 1: menu.Run();
            //        break;
            //    case 2: game.Run();
            //        break;
            //}

                
         
        }
    }
}

