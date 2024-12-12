using System;

namespace TheWhistle;

internal class Program
{
    public static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("\nT H E   W H I S T L E\n\nMAIN MENU:");
            Console.WriteLine("[1] NEW GAME");
            Console.WriteLine("[2] LOAD GAME");
            Console.WriteLine("[3] CAMPAIGN MODE");
            Console.WriteLine("[4] CREDITS ");
            Console.WriteLine("[5] EXIT");
            string invalid = Console.ReadLine();
                int.TryParse(invalid, out int ano);
                switch (ano)
                {
                    case 1: Console.Clear(); NewGame n = new NewGame();  break;
                    case 2: Console.Clear(); LoadGame l = new LoadGame(); break;
                    case 3: Console.Clear(); CampaignMode cm = new CampaignMode(); break;
                    case 4: Console.Clear(); Credits.credits(); break;
                    case 5:
                        Console.Write("\nGame Exits");
                        for(int i = 0; i < 3; i++)
                    {
                        Thread.Sleep(200);
                        Console.Write(".");
                    }
                        Thread.Sleep(200);
                        Environment.Exit(0);
                        break;
                    default:
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Try Again.");
                        break;
                }

        } while (true);
    }
}
