using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Kernel
{
    public class Game
    {
        Matcher matcher;

        
        public GameState State
        {
            get { return matcher == null ? GameState.Initial : (matcher.Match.Any() && matcher.Match.All(item => item == '2') ? 
                    GameState.won : (matcher.Count >= MaxGuesses ? GameState.lost : GameState.Running)); }
        }

        public string  Secret
        {
            get { return matcher.Secret; }
        }

        const int SecretLength = 5;
        public const int MaxGuesses = 10;

        public void Start()
        {
            var Count = SecretLength;
            var Result = new StringBuilder();
            matcher = new Matcher();
            var Generator = new Random(DateTime.Now.Millisecond);
            for (int Index = 0; Index < Count; ++Index) {
                Result.Append((char)Generator.Next(48, 56));
            }
            matcher.Secret = Result.ToString();
        }

        public void UserInput(string v)
        {
            if(State != GameState.Running) {
                throw new InvalidOperationException("Game not started or already stopped!");
            }
            if (v.Length != SecretLength) throw new ArgumentException(string.Format("input must consist of {0} digits", SecretLength));
            if (v.Any(c => char.IsDigit(c) == false)) throw new ArgumentException("input must consist of digits only");            
            matcher.UserInput(v);
        }
        
        public string Info()
        {
            return matcher.Match;
        }
    }

    public enum GameState
    {
        Initial,
        Running,
        won,
        lost
    }
}
