using System;

namespace TheWhistle;

internal class LoadGame
{
    public LoadGame()
    {
        AccessDataBase a = new AccessDataBase();
        Features f = new Features();
        if (!a.CheckAccess())
        {

            Console.WriteLine("Unable to connect to the database.");
            bool ano = f.boolOption("\nCONTINUE TO LOAD GAME?");
            if (!ano)
            {
                return;
            }
        }
        loadgame(a);
    }
    internal void loadgame(AccessDataBase a)
    {
        bool repeat = true;

        do
        {
            Console.WriteLine("LOAD GAME");
            Console.WriteLine("________________________________________");
            Console.WriteLine("[1] VIEW ALL SAVED CHARACTERS");
            Console.WriteLine("[2] VIEW A SAVED CHARACTER");
            Console.WriteLine("[3] DELETE A CHARACTER");
            Console.WriteLine("[4] DELETE ALL");
            Console.WriteLine("[5] GO BACK TO MAIN MENU");

            switch (Console.ReadLine())
            {
                case "1": Console.Clear(); a.ViewAll(); break;
                case "2": Console.Clear(); a.View(); break;
                case "3": Console.Clear(); a.Delete(); break;
                case "4": Console.Clear(); a.DeleteAll(); break;
                case "5": Console.Clear(); repeat = false; 
                    break;
                default: Console.Clear(); Console.WriteLine("Please choose from 1-5"); break;
            }


        } while (repeat);
    }
}
