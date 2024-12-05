using System;

namespace TheWhistle;

public class Character
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string SkinTone { get; set; }
    public string EyeColor { get; set; }
    public string HairStyle { get; set; }
    public string HairColor { get; set; }

    public bool Glasses { get; set; }
    public bool Moles { get; set; }
    public bool Freckles { get; set; }
    public bool Dimples { get; set; }
    public bool Mustache { get; set; }
    public bool Beard { get; set; }

    public string Top_ { get; set; }
    public string TopColor { get; set; }
    public string Bottom { get; set; }
    public string BottomColor { get; set; }
    public string Shoes { get; set; }
    public string ShoesColor { get; set; }
    public bool Cape { get; set; }
    public bool Collar { get; set; }
    public bool Gloves { get; set; }
    public bool Mask { get; set; }

    public string Power { get; set; }
    public string StarterSkill { get; set; }
    public string Weaknesses { get; set; }

    public int Mastery { get; set; }
    public int Health { get; set; }
    public int Stamina { get; set; }
    public int Defense { get; set; }
    public int Agility { get; set; }
    public int Recovery { get; set; }
    public int Speed { get; set; }
    public int MentalHealth { get; set; }
    public int TokensRemaining { get; set; }

    public void tokens(int Mastery, int Health, int Stamina, int Defense, int Agility, int Recovery, int Speed, int MentalHealth, int TokensRemaining)
    {
        this.Mastery = Mastery;
        this.Health = Health;
        this.Stamina = Stamina;
        this.Defense = Defense;
        this.Agility = Agility;
        this.Recovery = Recovery;
        this.Speed = Speed;
        this.MentalHealth = MentalHealth;
        this.TokensRemaining = TokensRemaining;

    }
    public Character(string name, string gender, string skinTone, string eyeColor,
                     string hairStyle, string hairColor, bool glasses, bool moles,
                     bool freckles, bool dimples, bool mustache, bool beard, string top,
                     string topColor, string bottom, string bottomColor, string shoes,
                     string shoesColor, bool cape, bool collar, bool gloves, bool mask,
                     string power, string starterSkill, string weaknesses)
    {
        Name = name;
        Gender = gender;
        SkinTone = skinTone;
        EyeColor = eyeColor;
        HairStyle = hairStyle;
        HairColor = hairColor;
        Glasses = glasses;
        Moles = moles;
        Freckles = freckles;
        Dimples = dimples;
        Mustache = mustache;
        Beard = beard;
        Top_ = top;
        TopColor = topColor;
        Bottom = bottom;
        BottomColor = bottomColor;
        Shoes = shoes;
        ShoesColor = shoesColor;
        Cape = cape;
        Collar = collar;
        Gloves = gloves;
        Mask = mask;
        Power = power;
        StarterSkill = starterSkill;
        Weaknesses = weaknesses;
    }
}
