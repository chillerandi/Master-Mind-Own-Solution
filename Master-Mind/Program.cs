using MasterMind_Kernel;
using MasterMind_GUI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Mind
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            do {
                Console.Clear();
                Console.WriteLine("************** Lass uns Master-Mind spielen!! **************\n");
                Console.WriteLine("Mit wie vielen Ziffern möchtest Du spielen? (3-6)");
                var inputLength = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Mit wie vielen Versuchen möchtest Du spielen?");
                var inputTries = Int32.Parse(Console.ReadLine());
                game.SecretLength = inputLength;
                int PCLength = game.SecretLength;

                game.Start(inputLength, inputTries);

                Console.WriteLine(String.Format("Die geheime Zahl muss aus {0} Ziffern zwischen 0 und 6 bestehen!", PCLength));
                Console.WriteLine("Eine 2 bedeutet einen Treffer an einer richtigen Stelle.\nEine 1 bedeutet eine richtige Zahl, aber an der falschen Stelle.\nEine 0 bedeutet daneben.\n"
                + "Bitte gib Deinen Tip ab und bestätige mit der Enter-Taste! Viel Erfolg!");
                while (game.State == Game.GameState.Running) {
                    try {
                        var input = Console.ReadLine();
                        game.UserInput(input);
                        Console.WriteLine(game.Info());
                    }
                    catch (Exception error) {
                        Console.WriteLine(error.Message);
                    }
                }
                if (game.State == Game.GameState.won) {
                    Console.WriteLine("Du hast gewonnen!!");
                    Console.WriteLine("Die gesuchte Zahl war tatsächlich: " + game.Secret);
                    Console.Write("\nWürdest Du gerne nochmal spielen (J/N)? Beenden mit jeder anderen Taste.");
                }
                else {
                    Console.WriteLine("Du hast verloren!!");
                    Console.WriteLine("Die gesuchte Zahl war: " + game.Secret);
                    Console.Write("\nWürdest Du gerne nochmal spielen (J/N)? Beenden mit jeder anderen Taste.");
                }
            }
            while (Console.ReadLine().ToUpper() == "J");

        }
    }
}
