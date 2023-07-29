using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaration of an array with 8 elements
            string[] woerter = { "alpha", "beta", "gamma", "delta", "epsilon", "zeta", "eta", "theta" }; //<- Enter any number of words as a string here
            //Wort auswählen
            Random wuerfel = new Random();
            int zufallszahl = wuerfel.Next(0, 8);
            string geheimwort = woerter[zufallszahl];
            int bustabenanz = geheimwort.Length;


            //Determine search word / fill up with hyphens
            string suchwort = "";
            for (int i = 0; i < geheimwort.Length; i++)
            {
                suchwort += "-";
            }
            int fehler = 0;
            //Gameplay
            Console.WriteLine("Hangman");
            Console.WriteLine("-------------\n");
            Console.WriteLine("Number of letters: " + geheimwort.Length);
            Console.WriteLine("Secred Word: " + suchwort);
            Console.Write("User input: ");
            while (fehler < 5 && suchwort != geheimwort)
            {
                char eingabe;
                eingabe = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                //End player won / lost
                bool treffer = false;
                string kopieSuchwort = "";
                for (int i = 0; i < geheimwort.Length; i++)
                {
                    if (eingabe == geheimwort[i])
                    {
                        treffer = true;
                        kopieSuchwort += eingabe;
                        
                    }
                    else
                    {
                        kopieSuchwort += suchwort[i];
                        
                    }

                }
                if (!treffer)
                {
                    fehler++;
                    Console.WriteLine("Fault: " + fehler );
                }

                if (fehler>=5 )
                {
                    Console.WriteLine("!!!LOSE!!!");
                }
                else
                {
                    Console.WriteLine("Win");
                }
                suchwort = kopieSuchwort;
                Console.WriteLine("Secret word: " + suchwort);

            }

            Console.ReadKey();
        }
    }
}
