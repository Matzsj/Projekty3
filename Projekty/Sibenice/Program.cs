using System;
using System.IO;

class Sibenice
{
    static string zamaskovani;
    static char pismeno;
    static int pokusy;  

    static void Main()
    {
        string[] slova = File.ReadAllLines("slova.txt");

        Random vyberSlova = new Random();
        string tajneSlovo = slova[vyberSlova.Next(slova.Length)];

        zamaskovani = new string('_', tajneSlovo.Length);
        pokusy = 6;

        
        while (pokusy > 0 && zamaskovani.Contains('_'))
        {
            privitani();

            
            if (tajneSlovo.Contains(pismeno))
            {
                for (int i = 0; i < tajneSlovo.Length; i++)
                {
                    if (tajneSlovo[i] == pismeno)
                    {
                        zamaskovani = zamaskovani.Remove(i, 1).Insert(i, pismeno.ToString());
                    }
                }
            }
            else
            {
                pokusy--; 
            }
        }

        
        if (!zamaskovani.Contains('_'))
            Console.WriteLine($"Vyhrál jsi! Slovo bylo: {tajneSlovo}");
        else
            Console.WriteLine($"Prohrál jsi! Slovo bylo: {tajneSlovo}");
    }

    static void privitani()
    {
        Console.WriteLine("Vítej ve hře Šibenice!");
        Console.WriteLine();
        Console.WriteLine(zamaskovani);
        Console.WriteLine();
        Console.WriteLine($"Počet pokusů: {pokusy}");
        Console.Write("Zadej písmeno: ");
        pismeno = Console.ReadLine()[0];
    }
}
