using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace TheWhistle
{
    public interface IFeatures
    {
        string checkName();
        bool IsNameUnique(string name);
        string genderOption();
        string skinOption();
        string hairOption();
        string topOption();
        string bottomOption();
        string shoesOption();
        string colorsOption(string ano);
        bool boolOption(string which);
        string powerOption();
        string magicSkill(string[] mgaSkills);
        string techSkill(string[] mgaSkills);
        string physicalSkill(string[] mgaSkills);  
        string psychicSkill(string[] mgaSkills);
        string spaceSkill(string[] mgaSkills);
        string plantSkill(string[] mgaSkills);
        string timeSkill(string[] mgaSkills);
        string elementalSkill(string[] mgaSkills);
    }

    public class Features : IFeatures
    {
        public string askUser(List<string> choices, string anoBa)
        {
            while (true)
            {
                Console.WriteLine($"Select {anoBa}: ");
                for (int i = 0; i < choices.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {choices[i]}");
                }
                string word = Console.ReadLine();
                bool ulit = int.TryParse(word, out int input);
                if (ulit && input <= choices.Count && input > 0)
                {
                    Console.Clear();
                    return choices[input - 1];
                }
                Console.Clear();
                Console.WriteLine($"Invalid Input. Try again.");
            }
        }
        public string askUser(List<string> choices, string anoBa, string[] mgaSkills)
        {
            while (true)
            {
                Console.WriteLine($"Select {anoBa}: ");
                for (int i = 0; i < choices.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {choices[i]}");
                }
                string word = Console.ReadLine();
                bool ulit = int.TryParse(word, out int input);
                if (ulit && input <= choices.Count && input > 0)
                {
                    Console.Clear();
                    return mgaSkills[input - 1];
                }
                Console.Clear();
                Console.WriteLine($"Invalid Input. Try again.");
            }
        }
        public bool boolOption(string which)
        {
            while (true)
            {
                Console.WriteLine(which);
                Console.WriteLine("[1] Yes");
                Console.WriteLine("[2] No");

                string choice = Console.ReadLine();
                bool ulit = int.TryParse(choice, out int input);
                if (ulit && input == 1)
                {
                    Console.Clear();
                    return true;
                }
                else if (ulit && input == 2)
                {
                    Console.Clear();
                    return false;
                }
                Console.Clear();
                Console.WriteLine($"Invalid Input. Try again.");
            }
        }
        public string colorsOption(string ano)
        {
            List<string> colors = new List<string>
            {
                "Black", "Brown", "Blue", "Red", "Yellow", "Purple", "Orange", "Green", "White"
            };
            return askUser(colors, $"{ano} Color");
        }

        public string genderOption()
        {
            List<string> genders = new List<string>
            {
                "Male", "Female", "Non-binary", "Gender-fluid", "Prefer not to say"
            };
            return askUser(genders, "Gender");
        }
        public string skinOption()
        {
            List<string> skinTones = new List<string>
            {
                "Dark", "Dark Brown", "Brown", "Light Brown", "Light"
            };
            return askUser(skinTones, "Skintone");
        }
        public string hairOption()
        {
            List<string> hairStyles = new List<string>
            {
                "Ponytail", "Buzz cut", "Short", "Long", "Low Taper Fade"
            };
            return askUser(hairStyles, "Hairstyle");
        }
        public string topOption()
        {
            List<string> tops = new List<string>
            {
                "Spandex", "Robe", "Combat", "Shirt"
            };
            return askUser(tops, "Top Costume");
        }
        public string bottomOption()
        {
            List<string> bottoms = new List<string>
            {
                "Spandex", "Robe", "Combat", "Pants", "Shorts"
            };
            return askUser(bottoms, "Bottom Costume");
        }
        public string shoesOption()
        {
            List<string> shoes = new List<string>
            {
                "Boots", "Sneakers", "Soles"
            };
            return askUser(shoes, "Shoes");
        }
        public string powerOption()
        {
            List<string> powers = new List<string>
            {
                "Magical", "Technological", "Physical", "Psychic", "Space", "Nature Manipulation", "Time", "Elemental"
            };
            return askUser(powers, "Power");
        }

        public string magicSkill(string[] mgaSkills)
        {
            List<string> skills = new List<string>
            {
                "Spell Casting" +
                "\n        Incantations like charms, hexes, and curses. Magical spells that affects people and objects " +
                "\n        once conjured.\n",
                "Reality Manipulation\n" +
                "\n        Ability to warp or distort reality through illusion.\n\n", 
                "Enchantment" +
                "\n        The practice of adding certain magical properties to an object which influences the " +
                "\n        person who uses it, as well as the object itself.\n", 
                "Dark Magic" +
                "\n        Magic that relates connection with the dead as well as dark entities.\n\n", 
                "Light Magic" +
                "\n        Magic that relates with healing and calling upon light forces.\n\n", 
                "Astral Projection" +
                "\n        The practice of separating consciousness from the physical body, " +
                "\n        allowing it to observe distant locations. \n"
            };

            return askUser(skills, "a Starter Skill", mgaSkills);
        }
        public string techSkill(string[] mgaSkills)
        {
            List<string> skills = new List<string>
            {
                "Advance Weaponry" +
                "\n        Usage and ability to create technologically advanced weapon.\n\n",
                "Super Suits" +
                "\n        Usage and ability to create technologically advanced armor which upgrades the " +
                "\n        character’s pain tolerance. \n",
                "Cybernetic Augmentation" +
                "\n        Usage and ability to create various equipment that allows the character to attain certain " +
                "\n        abilities such as flight, magnetic manipulation, size-alteration, as well as upgrade the " +
                "\n        character’s strength and speed."
            };
            return askUser(skills, "a Starter Skill", mgaSkills);
        }
        public string physicalSkill(string[] mgaSkills)
        {
            List<string> skills = new List<string>
            {
                "Super Strength" +
                "\n        Ability of incredible physical strength beyond the human capabilities. \n\n", 
                "Hyper Regeneration" +
                "\nRapid healing and recovery from injuries, as well as regeneration of lost limbs. \n\n", 
                "Shapeshifting" +
                "\n        Ability of altering appearance. Mimicking others as well as transforming into " +
                "\n        animals and objects.\n",
                "Body Durability" +
                "\n        Resistance to damage through toughness.\n\n",
                "Body Elasticity" +
                "\n        Ability to extend and stretch limbs.\n\n",
                "Super Hearing" +
                "\n        The ability to hear from great distance."
            };
            return askUser(skills, "a Starter Skill", mgaSkills);
        }
        public string psychicSkill(string[] mgaSkills)
        {
            List<string> skills = new List<string>
            {
                "Telepathy" +
                "\n        The ability to read minds, communicate through thoughts.\n\n",
                "Telekinesis" +
                "\n        The ability to move, control, or manipulate objects with the mind alone. This includes " +
                "\n        lifting, throwing, or shaping matter without physical contact.\n",
                "Mind Control" +
                "\n        The power to control another individual’s actions, emotions, or thoughts, overriding their " +
                "\n        free will or subtly nudging their decisions.\n",
                "Illusions and Reality Warping" +
                "\n        The ability to create illusions, tricking others into seeing things that aren’t there or " +
                "\n        manipulating their perceptions of reality. \n",
                "Precognition" +
                "\n        The ability to foresee events before they happen, predicting the future and potentially " +
                "\n        altering the course of events based on this knowledge."
            };
            return askUser(skills, "a Starter Skill", mgaSkills);
        }
        public string spaceSkill(string[] mgaSkills)
        {
            List<string> skills = new List<string>
            {
                "Teleportation" +
                "\n        The ability to travel instantaneously between locations, dimensions, as well as different" +
                "\n        universes.\n", 
                "Gravity Manipulation" +
                "\n        The ability to control gravitational forces, either increasing or decreasing gravity to affect " +
                "\n        objects or people, or creating anti-gravity fields.\n\n",
                "Spatial Distortion" +
                "\n        The ability to bend or warp space, altering the size or shape of areas, or trapping enemies " +
                "\n        in pocket dimensions\n",
                "Force Fields & Barriers" +
                "\n        The ability to create protective energy barriers or force fields that shield the user from" +
                "\n        damage. These barriers can be used defensively or offensively.\n"
            };
            return askUser(skills, "a Starter Skill", mgaSkills);
        }
        public string plantSkill(string[] mgaSkills)
        {
            List<string> skills = new List<string>
            {
                "Plant Growth Manipulation" +
                "\n        Accelerate the growth of plants, allowing character to create forests, vines, or flowers on " +
                "\n        command, allowing then creation of natural barriers.\n",
                "Animal Symbiosis" +
                "\n        Ability to connect with animals or plants, receiving their abilities or even merging with " +
                "\n        them temporarily.\n",
                "Toxic Natural Weaponry" +
                "\n        Release harmful toxins through plants, turning plants into poisonous or hallucinogenic traps.\n\n",
                "Photosynthetic Ability" +
                "\n        The ability to get energy from the sun, and other sources of light.\n\n"
            };
            return askUser(skills, "a Starter Skill", mgaSkills);
        }
        public string timeSkill(string[] mgaSkills)
        {
            List<string> skills = new List<string>
            {
                "Time Travel" +
                "\n        The ability to travel through time, either into the past or future, often with the potential to " +
                "\n        alter timelines.\n",
                "Time Manipulation" +
                "\n        The ability to speed up, slow down, freeze, or reverse time in localized areas, affecting the flow " +
                "\n        of time for objects or people.\n",
                "Self-Duplication" +
                "\n        The ability to create duplicates of the self from different points in time, leading to " +
                "\n        multiple versions of the same person existing simultaneously. \n",
                "Immortality" +
                "\n        The ability to live forever; eternal life.\n\n"
            };
            return askUser(skills, "a Starter Skill", mgaSkills);
        }
        public string elementalSkill(string[] mgaSkills)
        {
            List<string> skills = new List<string>
            {
                "Fire Manipulation" +
                "\n        The ability to generate, control, and manipulate flames.\n\n",
                "Water Manipulation" +
                "\n        The ability to create and control water and ice, such as summoning massive waves or " +
                "\n        creating ice structures.\n", 
                "Earth Manipulation" +
                "\n        The ability to manipulate rocks, soil, and minerals to control the earth itself. This " +
                "\n        includes creating earthquakes, stone walls\n",
                "Air Manipulation" +
                "\n        The ability to control and manipulate air currents, creating winds, storms, and even flying " +
                "\n       by controlling the atmosphere around oneself."
            };
            return askUser(skills, "a Starter Skill", mgaSkills);
        }

        public bool IsNameUnique(string name)
        {
            AccessDataBase a = new AccessDataBase();
            string conStr = a.conStr;

            string query = "SELECT COUNT(*) FROM Heroes WHERE name = @Name";
            try
            {
                using (SqlConnection connection = new SqlConnection(conStr))
                {

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@Name", name);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    bool ano = count == 0;

                    if (ano)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Error: This name is already taken. Please choose a different name.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nWARNING! CHARACTER WILL NOT BE SAVED!\n");
                return true;
            }
        }
        public string checkName()
        {
            string name = "";
            bool TamaBa = false;

            Console.WriteLine("Enter your HERO name" +
                                    "\n-Must not exceed 15 characters" +
                                    "\n-Must contain at least one special character or an uppercase letter.");

            while (!TamaBa)
            {
                Console.Write("Input Name:");
                name = Console.ReadLine();

                Console.Clear();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    continue;
                }
                if (!Regex.IsMatch(name, @"[!@#$%^&*(),.?""':;{}|<>0-9A-Z]"))
                {
                    Console.WriteLine("Hero name must contain at least one uppercase letter or special character.");
                    continue;
                }
                if (name.Length > 15)
                {
                    Console.WriteLine("Hero cannot exceed 15 characters.");
                    continue;
                }

                TamaBa = true;
            }
            return name;
        }

    }
}
