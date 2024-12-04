using System;
using System.Threading;

namespace TheWhistle
{
    internal class NewGame
    {
        internal NewGame()
        {
            Features f = new Features();
            AccessDataBase a = new AccessDataBase();

            if (!a.CheckAccess())
            {
                Console.WriteLine("Unable to connect to the database.");
                bool ano = f.boolOption("\nCONTINUE CREATING CHARACTER?");
                if (!ano)
                {
                    return;
                }   
            }
            Console.Clear();
            newgame(f, a);
        }
        internal void newgame(Features f, AccessDataBase a)
        {
            Console.WriteLine("NEW GAME");
            Console.WriteLine("CREATE YOUR CHARACTER");
            Console.WriteLine("______________________________________");
            string name = string.Empty;

            while (true)
            {   
                name = f.checkName();
                if (f.IsNameUnique(name))
                {
                    Console.WriteLine($"Welcome, {name}!");
                    break;
                }
                else
                {
                    bool uulitBa = f.boolOption("Would you like to try again?");

                    if (!uulitBa)
                    {
                        return;
                    }
                }
            }

            Console.WriteLine("\nBUILD YOUR HERO!");
            string gender = f.genderOption();
            string skinTone = f.skinOption();
            string eyeColor = f.colorsOption("Eye");
            string hairStyle = f.hairOption();
            string hairColor = f.colorsOption("Hair");

            Console.WriteLine("FACE FEATURES");
            bool glasses = f.boolOption("Glasses:");
            bool moles = f.boolOption("Moles:");
            bool freckles = f.boolOption("Freckles:");
            bool dimples = f.boolOption("Dimples:");
            bool mustache = f.boolOption("Mustache:");
            bool beard = f.boolOption("Beard:");

            Console.WriteLine("DESIGN YOUR COSTUME");
            string top = f.topOption();
            string topColor = f.colorsOption("Top");
            string bottom = f.bottomOption();
            string bottomColor = f.colorsOption("Bottom");
            string shoes = f.shoesOption();
            string shoesColor = f.colorsOption("Shoes");

            Console.WriteLine("PUT SOME ACCESSORIES");
            bool cape = f.boolOption("Cape:");
            bool collar = f.boolOption("Collar:");
            bool gloves = f.boolOption("Gloves:");
            bool mask = f.boolOption("Mask:");

            Console.WriteLine("CHOOSE YOUR MAIN POWER");
            string power = f.powerOption();

            string starterSkill = string.Empty;
            string weaknesses = string.Empty;

            string[] mgaSkills = { "Magical", "Technological", "Physical", "Psychic", "Space", "Nature Manipulation", "Time", "Elemental" };

            switch (power)
            {
                case "Magical":
                    starterSkill = f.magicSkill(mgaSkills);
                    weaknesses = "Physical, Tech, and Space";
                    break;
                case "Technological":
                    starterSkill = f.techSkill(mgaSkills);
                    weaknesses = "Space, Time, and Elemental";
                    break;
                case "Physical":
                    starterSkill = f.physicalSkill(mgaSkills);
                    weaknesses = "Space, Time, and Psychic";
                    break;
                case "Psychic":
                    starterSkill = f.psychicSkill(mgaSkills);
                    weaknesses = "Tech, Plant and Nature, and Space";
                    break;
                case "Space":
                    starterSkill = f.spaceSkill(mgaSkills);
                    weaknesses = "Magic, Elemental, and Time";
                    break;
                case "Nature Manipulation":
                    starterSkill = f.plantSkill(mgaSkills);
                    weaknesses = "Space, Time, and Magic";
                    break;
                case "Time":
                    starterSkill = f.timeSkill(mgaSkills);
                    weaknesses = "Magic and Psychic";
                    break;
                case "Elemental":
                    starterSkill = f.elementalSkill(mgaSkills);
                    weaknesses = "Plant and Nature, Physical, Time";
                    break;
            }
            Character c = new Character(name, gender, skinTone, eyeColor, hairStyle, hairColor,
                                        glasses, moles, freckles, dimples, mustache, beard,
                                        top, topColor, bottom, bottomColor, shoes, shoesColor,
                                         cape, collar, gloves, mask, power, starterSkill, weaknesses);

            Console.WriteLine("\nYou have 5 tokens to distribute across the following categories:");
            Console.WriteLine("Mastery, Health, Stamina, Defense, Agility, Recovery, Speed, and Mental Health\n");
            
            DistributeTokens(c);
            DisplayCharacter(c,a);

        }
        internal void DistributeTokens(Character c)

        {            int tokensRemaining = 5;

            int mastery = 10 + AskForTokens("Mastery", ref tokensRemaining);
            int health = (10 + AskForTokens("Health", ref tokensRemaining));
            int stamina = (10 + AskForTokens("Stamina", ref tokensRemaining));
            int defense =(10 + AskForTokens("Defense", ref tokensRemaining));
            int agility =(10 + AskForTokens("Agility", ref tokensRemaining));
            int recovery =(10 + AskForTokens("Recovery", ref tokensRemaining));
            int speed = (10 + AskForTokens("Speed", ref tokensRemaining));
            int mentalHealth =(10 + AskForTokens("Mental Health", ref tokensRemaining));

            Console.WriteLine(tokensRemaining == 1 ? "Single token left" : $"{tokensRemaining} tokens left" );

            c.tokens(mastery, health, stamina, defense, agility, recovery, speed, mentalHealth, tokensRemaining);
            Console.Write("Creating character");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1500);
                Console.Write(".");
            }
            Console.WriteLine();
        }

        internal int AskForTokens(string category, ref int tokensRemaining)
        {
            int allocatedTokens = 0;
            if (tokensRemaining <= 0) { return 0; }
            Console.WriteLine($"How many tokens would you like to allocate to {category}? (Tokens remaining: {tokensRemaining})");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out allocatedTokens) && allocatedTokens >= 0 && allocatedTokens <= tokensRemaining)
                {
                    tokensRemaining -= allocatedTokens;
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter a number between 0 and {tokensRemaining}.");
                }
            }

            return allocatedTokens * 5;
        }

        public void DisplayCharacter(Character c, AccessDataBase a)
        {
            Console.WriteLine();
            Console.WriteLine($"{c.Name.ToUpper()} CREATED SUCCESSFULLY!\n");
            Console.WriteLine($"Name: {c.Name}");
            Console.WriteLine($"Gender: {c.Gender}");
            Console.WriteLine($"Skin Tone: {c.SkinTone}");
            Console.WriteLine($"Eye Color: {c.EyeColor}");
            Console.WriteLine($"Hair Style: {c.HairStyle} ({c.HairColor})");

            Console.WriteLine("\nFace Features:");
            Console.WriteLine($"Glasses: {c.Glasses}");
            Console.WriteLine($"Moles: {c.Moles}");
            Console.WriteLine($"Freckles: {c.Freckles}");
            Console.WriteLine($"Dimples: {c.Dimples}");
            Console.WriteLine($"Mustache: {c.Mustache}");
            Console.WriteLine($"Beard: {c.Beard}");

            Console.WriteLine("\nCostume:");
            Console.WriteLine($"Top: {c.TopColor} {c.Top_}");
            Console.WriteLine($"Bottom: {c.BottomColor} {c.Bottom} ");
            Console.WriteLine($"Shoes: {c.ShoesColor} {c.Shoes}");

            Console.WriteLine("\nAccessories:");
            Console.WriteLine($"Cape: {c.Cape}");
            Console.WriteLine($"Collar: {c.Collar}");
            Console.WriteLine($"Gloves: {c.Gloves}");
            Console.WriteLine($"Mask: {c.Mask}");

            Console.WriteLine("\nPRESS ANY KEY TO REVIEW CHARACTER ATTRIBUTES");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("\nCHARACTER OVERVIEW");

            Console.WriteLine($"\nPower: {c.Power}");
            Console.WriteLine($"Skill: {c.StarterSkill}");
            Console.WriteLine($"Weaknesses: {c.Weaknesses}");
            Console.WriteLine("\nSTATS:");
            Console.WriteLine($"Mastery: {c.Mastery}%");
            Console.WriteLine($"Health: {c.Health}%");
            Console.WriteLine($"Stamina: {c.Stamina}%");
            Console.WriteLine($"Defense: {c.Defense}%");
            Console.WriteLine($"Agility: {c.Agility}%");
            Console.WriteLine($"Recovery: {c.Recovery}%");
            Console.WriteLine($"Speed: {c.Speed}%");
            Console.WriteLine($"Mental Health {c.MentalHealth}%");
            Console.WriteLine();
            Console.WriteLine($"Remaining Tokens: {c.TokensRemaining}");

            Console.WriteLine("\nPRESS ANY KEY TO SAVE:");
            Console.ReadKey(true);
            a.Send(c);
        }
    }
}