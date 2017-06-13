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
            //Parameter für länge der Zahl und anzahl an Versuchen
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
            if(game.State == GameState.won) {
                Console.WriteLine("You won!!");
                Console.WriteLine(game.Secret);
            }
            else {
                Console.WriteLine("You lost!!");
                Console.WriteLine(game.Secret);
            }
            Console.Read();
        }
    }
}
