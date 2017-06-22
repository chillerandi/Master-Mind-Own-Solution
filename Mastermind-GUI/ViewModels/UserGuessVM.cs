using MasterMind_Kernel;

namespace Mastermind_GUI.ViewModels
{
    public class UserGuessVM : ViewModelBase
    {
        
        public UserGuessVM()
        {
            UserGuess Guess = new UserGuess();            
        }

        public UserGuess Guess;
    }
}