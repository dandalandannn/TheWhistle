using System;
using Microsoft.Data.SqlClient;

namespace TheWhistle;
internal class CampaignMode
{
    Features f = new Features();

    internal CampaignMode()
    {
        AccessDataBase a = new AccessDataBase();

        if (!a.CheckAccess() || a.IsEmpty(1))
        {
            Console.WriteLine(!a.CheckAccess() ? "Unable to connect to the database.": "No character found.");
            bool ano = f.boolOption("\nGENERAL CAMPAIGN MODE?");
            if (ano)
            {
                Console.WriteLine();
                CampaignOptions.Generic();
            }
            return;
        }
        campaignMode(a, a.conStr);
    }

    internal void campaignMode(AccessDataBase a, string conStr)
    {
        a.CharacterList();
        Console.Write("Input character name for campaign: ");
        string name = Console.ReadLine();
        Console.WriteLine();

        string query = "SELECT * FROM Heroes WHERE Name = @Name";

        using (SqlConnection connection = new SqlConnection(conStr))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                CampaignOptions.Personalized(reader);
            }
            else
            {
                Console.WriteLine($"Character '{name}' not found.");
                bool ano = f.boolOption("GENERAL CAMPAIGN MODE?");
                if (ano)
                {
                    Console.WriteLine();
                    CampaignOptions.Generic();
                }
            }
        }
    }
}
public struct Script
{
    public string Name;
    public string Power;
    public string StarterSkill;

    public Script(string Name, string Power, string StarterSkill)
    {
        this.Name = Name;
        this.Power = Power;
        this.StarterSkill = StarterSkill;
    }
}
class CampaignOptions
{
    public static void Personalized(SqlDataReader reader)
    {
        string Name = $"{reader["Name"]}";
        string Power = $"{reader["Power"]}";
        string StarterSkill = $"{reader["StarterSkill"]}";

        Script script = new Script(Name, Power, StarterSkill);
        Play(script);

        Console.Write("\nPRESS ANY KEY TO EXIT: ");
        Console.ReadKey(true);
        Console.Clear();
    }
    public static void Generic()
    {
        string Name = $"a young superhero";
        string Power = $"extraordinary super";
        string StarterSkill = $"your hands";

        Script script = new Script(Name, Power, StarterSkill);
        Play(script);

        Console.Write("\nPRESS ANY KEY TO EXIT: ");
        Console.ReadKey(true);
        Console.Clear();
    }
    public static void Play(Script script)
    {
        Console.Clear();
        Pampabagal p = new Pampabagal();
        p.lines("In a world where superhumans roam among us, ");
        p.lines("you, ");
        p.lines($"{script.Name}, ");
        p.lines($"are chosen para maging \nseventh member of most elite group of super heroes—");
        p.pause("“The Whistle.”. ");
        p.lines("This was the ultimate dream. ");
        p.lines("\nFinally, ");
        p.lines("makakagawa ka na ng tunay na pagbabago. ");
        p.lines($"With your {script.Power} powers \nand special skills within {script.StarterSkill}, ");
        p.lines("you’ve earned your spot in this prestigious team. \n");
        p.lines("\nEverything was going so well");
        p.el();
        Console.WriteLine("\n");

        p.lines("Pero as you rise through the ranks and gain popularity, ");
        p.lines("you begin to uncover the harsh truth of the\nindustry. ");
        p.lines("It was never about heroism or saving lives. ");
        p.lines("It’s all about money and sponsorships. ");
        p.lines("It’s all \njust business. ");
        p.lines("Unti-unti mong na-realize na peke ang image nila sa mga tao. ");
        p.lines("Worse, ");
        p.lines("they are not good\npeople. ");
        p.lines("Especially the group leader, ");
        p.pause("Home Mogger. \n\n");

        p.lines("Now, it's your chance to make your dreams come true. ");
        p.lines("Well, ");
        p.lines("hindi man exactly kagaya ng inaasahan mo,\n");
        p.lines("pero ito na ‘yon. ");
        p.lines("So, go. ");
        p.lines("Find your people. ");
        p.lines("Make your way up and reveal who Home Mogger truly is.\n\n");

        p.lines("Gumawa ka ng pag-babago");
        p.el();
        p.pause("totoong pagbabago.\n");
    }
}
class Pampabagal
{
    public void pause(string linya)
    {
        Thread.Sleep(500);
        for (int i = 0; i < linya.Length; i++)
        {
            Console.Write(linya[i]);
            Thread.Sleep(10);
        }
        Thread.Sleep(750);
    }
    public void lines(string linya)
    {
        Thread.Sleep(250);
        for (int i = 0; i < linya.Length; i++)
        {
            Console.Write(linya[i]);
            Thread.Sleep(30);
        }
        Thread.Sleep(500);
    }
    public void el()
    {
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(250);
            Console.Write(".");
        }
        Thread.Sleep(500);
    }
}

