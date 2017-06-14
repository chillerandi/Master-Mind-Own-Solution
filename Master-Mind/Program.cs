using MasterMind_Kernel;
using System;
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
                Console.WriteLine("************** Lass uns Master-Mind spielen!! **************\n");
            //Parameter für länge der Zahl und anzahl an Versuchen
            Console.WriteLine(string.Format("Die geheime Zahl muss aus {0} Ziffern zwischen 1 und 6 bestehen!\n" +
                    "Eine 2 bedeutet einen Treffer an einer richtigen Stelle.\n" +
                    "Eine 1 bedeutet eine richtige Zahl, aber an der falschen Stelle.\n" +
                    "Eine 0 bedeutet daneben.\n" +
                    "Bitte gib Deinen Tip ab und bestätige mit der Enter-Taste! Viel Erfolg!", game.SecretLength));
            do {
                game.Start();
                            
                while (game.State == GameState.Running) {

                    var input = Console.ReadLine();

                    try {
                        game.UserInput(input);
                        Console.WriteLine(game.Info());
                    }
                    catch (Exception error) {
                        Console.WriteLine(error.Message);
                    }
                }
                if (game.State == GameState.won) {
                    Console.WriteLine("Du hast gewonnen!!");
                    Console.WriteLine("Die gesuchte Zahl war tatsächlich: " + game.Secret);
                }
                else {
                    Console.WriteLine("Du hast verloren!!");
                    Console.WriteLine("Die gesuchte Zahl war: " + game.Secret);
                }
                
                Console.Write("\nWürdest Du gerne nochmal spielen (J/N)? ");
                //Console.Read();
            }           
            while (Console.ReadLine().ToUpper() == "J");
            Console.WriteLine("Also gut, los geht's! ");
            
        }
    }
}
