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

        private int sectretLength_;
        public int SecretLength
        {
            get { return sectretLength_; }
            set { sectretLength_ = value; }
        }
        public int MaxGuesses ;
        public string numberCount;

        public void Start(int secretLength = 5, int maxGuesses = 3)
        {
            SecretLength = secretLength;
            MaxGuesses = maxGuesses;           
            var Count = SecretLength;
            var Result = new StringBuilder();
            matcher = new Matcher();
            var Generator = new Random(DateTime.Now.Millisecond);
            for (int Index = 0; Index < Count; ++Index) {
                Result.Append((char)Generator.Next(49, 54));
            }
            matcher.Secret = Result.ToString();
        }

        public void UserInput(string v)
        {
            if(State != GameState.Running) {
                throw new InvalidOperationException("Spiel noch nicht gestartet oder schon gestoppt!");
            }
            if (v.Length != SecretLength) throw new ArgumentException(string.Format("Die Zahl muss aus {0} Ziffern bestehen!", SecretLength));
            if (v.Any(c => char.IsDigit(c) == false)) throw new ArgumentException("Die Eingabe darf nur aus Ziffern bestehen!");            
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
