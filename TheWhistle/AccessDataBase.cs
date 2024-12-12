using System;
using Microsoft.Data.SqlClient;

namespace TheWhistle;

internal class AccessDataBase
{
    Features f = new Features();
    public string conStr = @"Data Source=DESKTOP-ITTG3JJ\SQLEXPRESS02;Initial Catalog=HeroesDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
    public bool CheckAccess()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Connection Failed: " + e.Message);
            return false;
        }
    }

    public bool IsEmpty()
    {
        try
        {
            string query = "SELECT * FROM HEROES";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                    {
                        Console.WriteLine("No character found.");
                        Console.WriteLine("PRESS ANY KEY TO EXIT");
                        Console.ReadKey(true);
                        Console.Clear();
                        return true;
                    }
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Connection Failed: " + e.Message);
            return true;
        }
    }
    public bool IsEmpty(int i)
    {
        try
        {
            string query = "SELECT * FROM HEROES";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return true;
                }
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Connection Failed: " + e.Message);
            return true;
        }
    }

    public void ViewASpecific()
    {
        if (IsEmpty()) { return; }

        CharacterList();
        Console.Write("Input character name: ");
        string name = Console.ReadLine();
        Console.Clear();
        string query = "SELECT * FROM Heroes WHERE Name = @Name";
        try
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    while (true)
                    {  
                        Console.Clear();
                        ViewCompleteInfo(name);
                        Console.WriteLine("PRESS ANY KEY TO EXIT");
                        Console.ReadKey(true);
                        Console.Clear();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"Character '{name}' not found.");
                    Console.WriteLine("PRESS ANY KEY TO EXIT");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error fetching character: " + e.Message);
            Console.WriteLine("PRESS ANY KEY TO EXIT");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
    public void ViewCompleteInfo(string Name)
    {
        if (IsEmpty()) { return; }
        string query = "SELECT * FROM Heroes WHERE Name = @Name";
        try
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", Name);
                SqlDataReader reader = command.ExecuteReader();
                

                while (reader.Read())
                {
                    Console.WriteLine($"Name: {reader["Name"]}");
                    Console.WriteLine($"Gender: {reader["Gender"]}");
                    Console.WriteLine($"Skin Tone: {reader["SkinTone"]}");
                    Console.WriteLine($"Eye Color: {reader["EyeColor"]}");
                    Console.WriteLine($"Hair Style: {reader["HairStyle"]} ({reader["HairColor"]})");

                    Console.WriteLine("\nFace Features:");
                    Console.WriteLine($"Glasses: {reader["Glasses"]}");
                    Console.WriteLine($"Moles: {reader["Moles"]}");
                    Console.WriteLine($"Freckles: {reader["Freckles"]}");
                    Console.WriteLine($"Dimples: {reader["Dimples"]}");
                    Console.WriteLine($"Mustache: {reader["Mustache"]}");
                    Console.WriteLine($"Beard: {reader["Beard"]}");

                    Console.WriteLine("\nCostume:");
                    Console.WriteLine($"Top: {reader["TopColor"]} {reader["Top_"]}");
                    Console.WriteLine($"Bottom: {reader["BottomColor"]} {reader["Bottom"]}");
                    Console.WriteLine($"Shoes: {reader["ShoesColor"]} {reader["Shoes"]}");

                    Console.WriteLine("\nAccessories:");
                    Console.WriteLine($"Cape: {reader["Cape"]}");
                    Console.WriteLine($"Collar: {reader["Collar"]}");
                    Console.WriteLine($"Gloves: {reader["Gloves"]}");
                    Console.WriteLine($"Mask: {reader["Mask"]}");

                    Console.WriteLine("\nPRESS ANY KEY TO REVIEW CHARACTER ATTRIBUTES");
                    Console.ReadKey(true);
                    Console.Clear();
                    Console.WriteLine("\nCHARACTER OVERVIEW");

                    Console.WriteLine($"\nPower: {reader["Power"]}");
                    Console.WriteLine($"Skill: {reader["StarterSkill"]}");
                    Console.WriteLine($"Weaknesses: {reader["Weaknesses"]}");

                    Console.WriteLine("\nSTATS:");
                    Console.WriteLine($"Mastery: {reader["Mastery"]}%");
                    Console.WriteLine($"Health: {reader["Health"]}%");
                    Console.WriteLine($"Stamina: {reader["Stamina"]}%");
                    Console.WriteLine($"Defense: {reader["Defense"]}%");
                    Console.WriteLine($"Agility: {reader["Agility"]}%");
                    Console.WriteLine($"Recovery: {reader["Recovery"]}%");
                    Console.WriteLine($"Speed: {reader["Speed"]}%");
                    Console.WriteLine($"Mental Health: {reader["MentalHealth"]}%");

                    Console.WriteLine();
                    Console.WriteLine($"Tokens: {reader["TokensRemaining"]}");
                }
            }
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
    public void CharacterList()
    {
        Console.WriteLine("CHARACTER LIST");
        string query = "SELECT ROW_NUMBER() OVER (ORDER BY CharacterID) AS RowNum, Name, Power FROM Heroes";

        try
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["RowNum"]}. CHARACTER NAME: {reader["Name"]} ({reader["Power"]})");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void ViewAll()
    {
        if (IsEmpty()) { return; }
        CharacterList();
        Console.WriteLine("PRESS ANY KEY TO EXIT");
        Console.ReadKey(true);
        Console.Clear();
    }

    public void Delete()
    {
        if (IsEmpty()) { return; }
        CharacterList();
        Console.WriteLine("______________________________");
        Console.Write("Input character name to delete: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Are you sure you want to delete {name}? (YES or NO)");
        string anoNa = Console.ReadLine().ToLower();

        if (anoNa != "yes")
        {
            Console.Clear();
            Console.WriteLine("Deletion aborted.");
            return;
        }

        string query = "DELETE FROM Heroes WHERE Name = @Name";
        try
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Character '{name}' has been deleted.");
                }
                else
                {
                    Console.WriteLine($"Character '{name}' not found.");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error deleting character: " + e.Message);
        }
        finally
        {
            Console.WriteLine("PRESS ANY KEY TO EXIT");
            Console.ReadKey(true);
            Console.Clear();
        }

        
    }
    public void DeleteAll()
    {
        if (IsEmpty()) { return; }
        Console.WriteLine("Are you sure you want to delete all characters? (YES or NO)");
        string anoNa = Console.ReadLine().ToLower();

        if (anoNa != "yes")
        {
            Console.Clear();
            Console.WriteLine("Deletion aborted.");
            return;
        }

        string query = "DELETE FROM Heroes; DBCC CHECKIDENT ('Heroes', RESEED, 0)";

        try
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"All characters have been deleted. {rowsAffected} rows affected.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error deleting characters: " + e.Message);
        }
        finally
        {
            Console.WriteLine("PRESS ANY KEY TO EXIT");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
    public void ViewAllWithCompleteInfo()
    {
        if (IsEmpty()) { return; }
        string query = "SELECT * FROM Heroes";
        try
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Console.Clear();
                    Console.WriteLine("CHARACTER OVERVIEW\n");
                    Console.WriteLine(string.Format("{0,-35}", $"Name: {reader["Name"]}")+ "COSTUME:");
                    Console.WriteLine(string.Format("{0,-35}", $"Gender: {reader["Gender"]}")+ $"Top: {reader["TopColor"]} {reader["Top_"]}");
                    Console.WriteLine(string.Format("{0,-35}", $"Skin Tone: {reader["SkinTone"]}")+ $"Bottom: {reader["BottomColor"]} {reader["Bottom"]}");
                    Console.WriteLine(string.Format("{0,-35}", $"Eye Color: {reader["EyeColor"]}")+ $"Shoes: {reader["ShoesColor"]} {reader["Shoes"]}");
                    Console.WriteLine(string.Format("{0,-35}", $"Hair Style: {reader["HairStyle"]} ({reader["HairColor"]})"));
                    Console.WriteLine(string.Format("{0,-35}", "")+ "Accessories:");
                    Console.WriteLine(string.Format("{0,-35}", "Face Features:")+ $"Cape: {reader["Cape"]}");
                    Console.WriteLine(string.Format("{0,-35}", $"Glasses: {reader["Glasses"]}")+ $"Collar: {reader["Collar"]}");
                    Console.WriteLine(string.Format("{0,-35}", $"Moles: {reader["Moles"]}")+ $"Gloves: {reader["Gloves"]}");
                    Console.WriteLine(string.Format("{0,-35}", $"Freckles: {reader["Freckles"]}")+ $"Mask: {reader["Mask"]}");
                    Console.WriteLine(string.Format("{0,-35}", $"Dimples: {reader["Dimples"]}"));
                    Console.WriteLine($"Mustache: {reader["Mustache"]}");
                    Console.WriteLine($"Beard: {reader["Beard"]}");

                    Console.WriteLine("\nSTATS:");
                    Console.WriteLine(string.Format("{0,-35}", $"Mastery: {reader["Mastery"]}%")+ $"Power: {reader["Power"]}");
                    Console.WriteLine(string.Format("{0,-35}", $"Health: {reader["Health"]}%")+ $"Skill: {reader["StarterSkill"]}");
                    Console.WriteLine(string.Format("{0,-35}", $"Stamina: {reader["Stamina"]}%")+ $"Weaknesses: {reader["Weaknesses"]}");
                    Console.WriteLine($"Defense: {reader["Defense"]}%");
                    Console.WriteLine(string.Format("{0,-35}", $"Agility: {reader["Agility"]}%")+ $"Tokens: {reader["TokensRemaining"]}");
                    Console.WriteLine($"Recovery: {reader["Recovery"]}%");
                    Console.WriteLine($"Speed: {reader["Speed"]}%");
                    Console.WriteLine($"Mental Health: {reader["MentalHealth"]}%");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to proceed to the next character. [1] Exit.");
                    if (Console.ReadLine() == "1")
                    {
                        Console.Clear();
                        return;
                    }

                }
                Console.Clear();
                Console.WriteLine("That's all the characters! \nPress any key to exit.");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
    public void Send(Character c)
    {
        string query = @"
            INSERT INTO Heroes (Name, Gender, SkinTone, EyeColor, HairStyle, HairColor, Glasses, Moles, Freckles, Dimples, Mustache, Beard, 
                                Top_, TopColor, Bottom, BottomColor, Shoes, ShoesColor, Cape, Collar, Gloves, Mask, Power, StarterSkill, 
                                Weaknesses, Mastery, Health, Stamina, Defense, Agility, Recovery, Speed, MentalHealth, TokensRemaining)
            VALUES (@Name, @Gender, @SkinTone, @EyeColor, @HairStyle, @HairColor, @Glasses, @Moles, @Freckles, @Dimples, @Mustache, 
                    @Beard, @Top_, @TopColor, @Bottom, @BottomColor, @Shoes, @ShoesColor, @Cape, @Collar, @Gloves, @Mask, @Power, 
                    @StarterSkill, @Weaknesses, @Mastery, @Health, @Stamina, @Defense, @Agility, @Recovery, @Speed, @MentalHealth, @TokensRemaining)";

        try
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", c.Name);
                command.Parameters.AddWithValue("@Gender", c.Gender);
                command.Parameters.AddWithValue("@SkinTone", c.SkinTone);
                command.Parameters.AddWithValue("@EyeColor", c.EyeColor);
                command.Parameters.AddWithValue("@HairStyle", c.HairStyle);
                command.Parameters.AddWithValue("@HairColor", c.HairColor);
                command.Parameters.AddWithValue("@Glasses", c.Glasses);
                command.Parameters.AddWithValue("@Moles", c.Moles);
                command.Parameters.AddWithValue("@Freckles", c.Freckles);
                command.Parameters.AddWithValue("@Dimples", c.Dimples);
                command.Parameters.AddWithValue("@Mustache", c.Mustache);
                command.Parameters.AddWithValue("@Beard", c.Beard);
                command.Parameters.AddWithValue("@Top_", c.Top_);
                command.Parameters.AddWithValue("@TopColor", c.TopColor);
                command.Parameters.AddWithValue("@Bottom", c.Bottom);
                command.Parameters.AddWithValue("@BottomColor", c.BottomColor);
                command.Parameters.AddWithValue("@Shoes", c.Shoes);
                command.Parameters.AddWithValue("@ShoesColor", c.ShoesColor);
                command.Parameters.AddWithValue("@Cape", c.Cape);
                command.Parameters.AddWithValue("@Collar", c.Collar);
                command.Parameters.AddWithValue("@Gloves", c.Gloves);
                command.Parameters.AddWithValue("@Mask", c.Mask);
                command.Parameters.AddWithValue("@Power", c.Power);
                command.Parameters.AddWithValue("@StarterSkill", c.StarterSkill);
                command.Parameters.AddWithValue("@Weaknesses", c.Weaknesses);
                command.Parameters.AddWithValue("@Mastery", c.Mastery);
                command.Parameters.AddWithValue("@Health", c.Health);
                command.Parameters.AddWithValue("@Stamina", c.Stamina);
                command.Parameters.AddWithValue("@Defense", c.Defense);
                command.Parameters.AddWithValue("@Agility", c.Agility);
                command.Parameters.AddWithValue("@Recovery", c.Recovery);
                command.Parameters.AddWithValue("@Speed", c.Speed);
                command.Parameters.AddWithValue("@MentalHealth", c.MentalHealth);
                command.Parameters.AddWithValue("@TokensRemaining", c.TokensRemaining);

                connection.Open();
                command.ExecuteNonQuery();
            }

            Console.Write("Loading Files");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1500);
                Console.Write(".");
            }
            Console.WriteLine("\nNew character is saved to database.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine("Unable to save the character.\n");
        }
        finally
        {
            Console.WriteLine("PRESS ANY KEY TO EXIT");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}