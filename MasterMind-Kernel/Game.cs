using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Kernel
{
    public class Game
    {
        public Matcher matcher;
        public int MaxGuesses;
        public enum GameState
        {
            Initial, Running, won, lost
        }

        public GameState State
        {
            get {
                return matcher == null ? GameState.Initial : (matcher.Match.Any() && matcher.Match.All(item => item == '2') ?
                  GameState.won : (matcher.Count >= MaxGuesses ? GameState.lost : GameState.Running));
            }
        }

        public string Secret
        {
            get { return matcher.Secret; }
        }

        private int secretLength_;
        public int SecretLength
        {
            get { return secretLength_; }
            set { secretLength_ = value; }
        }

        public void Start(int secretLength_, int maxGuesses)
        {
            SecretLength = secretLength_;
            MaxGuesses = maxGuesses;
            var Count = SecretLength;
            var Result = new StringBuilder();
            matcher = new Matcher();
            var Generator = new Random(DateTime.Now.Millisecond);
            for (int Index = 0; Index < Count; ++Index) {
                Result.Append(Generator.Next(1, 7));
            }
            matcher.Secret = Result.ToString();
        }

        public void UserInput(string v)
        {
            var Count = SecretLength;
            if (State != GameState.Running) {
                throw new InvalidOperationException("Spiel noch nicht gestartet oder schon gestoppt!");
            }
            // ----------------------- Eingabe auf Zahlen von 1 - 6 begrenzen ---------------------         
            for (int i = 0; i < Count; ++i) {
                if (v.Any(c => c > 54 == true) || v.Any(c => c < 49 == true)) { throw new InvalidOperationException("Es sind nur Zahlen von 1 - 6 erlaubt!"); }
            }
            if (v.Length != SecretLength) throw new ArgumentException(string.Format("Die Zahl muss aus {0} Ziffern bestehen!", SecretLength));
            if (v.Any(c => char.IsDigit(c) == false)) throw new ArgumentException("Die Eingabe darf nur aus Ziffern bestehen!");
            matcher.UserInput(v);
        }

        public string RowMatch { get { return matcher.RowMatches.Any() ? matcher.RowMatches.Last() : string.Empty; } }

        public string Match { get { return Info(); } }

        public string Info()
        {
            return matcher.Match;
        }
    }
}
