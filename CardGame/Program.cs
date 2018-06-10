using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Module;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.Clear();
            Console.WriteLine("1 - карточная игра\n2 - подсчет слов в тексте");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    Game g = new Game();
                    g.Start();
                    if(Console.ReadKey().Key == ConsoleKey.Enter)
                        goto start;
                    break;

                case 2:
                    string text =
                        "Вот дом, Который построил Джек. А это пшеница, Которая в темном  чулане хранится В доме, Который построил Джек. А это веселая птица синица, Которая часто ворует пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

                    var words = text.Split(' ', ',', '.');
                    Dictionary<string, int> dict = new Dictionary<string, int>();
                    foreach (var item in words)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            if (!dict.ContainsKey(item)) dict[item] = 0;
                            dict[item]++;
                        }
                    }

                    int i = 0;
                    Console.WriteLine("\tСлово\t\t\tКол-во");
                    foreach (var word in dict)
                        Console.WriteLine("{0}\t{1}\t\t\t{2}", ++i, word.Key, word.Value);
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        goto start;
                    break;

            }
            

      
            Console.ReadLine();
        }
    }
}
