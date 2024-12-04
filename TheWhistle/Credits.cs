using System;
using System.Threading;

namespace TheWhistle
{
    public class Credits
    {
        public static void credits()
        {
            Console.WriteLine("CREDITS");
            Dan dan = new Dan();
            Kas kas = new Kas();
            Alt alt = new Alt();

            dan.job();
            dan.name();
            Console.WriteLine();
            dan.desc();
            dan.motto();

            kas.job(); 
            kas.name();
            Console.WriteLine();
            kas.desc();
            kas.motto();

            alt.job();
            alt.name();
            Console.WriteLine();
            alt.desc();
            alt.motto();

            Console.WriteLine("\nPRESS ANY KEY TO EXIT");
            Console.ReadKey(true);
            Console.Clear();

        }
        public static void lines(string linya)
        {
            for (int i = 0; i < linya.Length; i++)
            {
                Console.Write(linya[i]);
                Thread.Sleep(25);
            }
            Thread.Sleep(1000);

        }
    }

    abstract class IntroduceYourself()
    {
        public abstract void job();
        public abstract void name();
        public abstract void desc();
        public abstract void motto();
    }

    class Dan: IntroduceYourself
    {
        public override void job()
        {
            Credits.lines("\nPROGRAMMERIST: ");
        }
        public override void name()
        {
            Credits.lines("Daniel Gwen Domingo");
        }
        public override void desc()
        {
            Credits.lines("\n-Mabait, magaling, perfect.");
        }
        public override void motto()
        {
            Credits.lines("\n\"I'm not superstitious...but I'm a little stitious.\"\n");
        }

    }

    class Kas: IntroduceYourself
    {
        public override void job()
        {
            Credits.lines("\nDOCUMENTATIONIST: ");
        }
        public override void name()
        {
            Credits.lines("Kassandra Mae Perdez");
        }
        public override void desc()
        {
            Credits.lines("\n-Okay naman.");
        }
        public override void motto()
        {
            Credits.lines("\n\"Hello world today, hello lord tomorrow.\"\n");
        }
    }

    class Alt: IntroduceYourself
    {
        public override void job()
        {
            Credits.lines("\nPANSITKANTONERIST: ");
        }
        public override void name()
        {
            Credits.lines("Althea Gorgonia");
        }
        public override void desc()
        {
            Credits.lines("\n-Sakto lang.");
        }
        public override void motto()
        {
            Credits.lines("\n\"Kapag may pera, may pang nilaga.\"\n");
        }
    }
}
