namespace KamenNuzkyPapir
{
    internal class programprvni
    {
        static void Main(string[] args)
        {
            List<string> seznam = new List<string> { "kámen", "nůžky", "papír" };

            Console.Write("Ahoj, zadej kámen, nůžky, nebo papír: ");

            string vystup;
            vystup = Console.ReadLine();

            Random vyber = new Random();

            int volba = vyber.Next(seznam.Count);
            string nahodnaVolba = seznam[volba];

            Console.WriteLine("ja vybral " + nahodnaVolba);

            if (vystup == nahodnaVolba)
            {
                Console.WriteLine("Remiza");
            }
            else if (vystup == "kámen" && nahodnaVolba == "nůžky")
            {
                Console.WriteLine("Vyhrál si");
            }
            else if (vystup == "nůžky" && nahodnaVolba == "kámen")
            {
                Console.WriteLine("Prohrál si");
            }
            else if (vystup == "papír" && nahodnaVolba == "nůžky")
            {
                Console.WriteLine("Prohrál si");
            }
            else if (vystup == "nůžky" && nahodnaVolba == "papír")
            {
                Console.WriteLine("Vyhrál si");
            }

        }
    }
}
