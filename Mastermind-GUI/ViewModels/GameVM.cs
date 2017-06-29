using MasterMind_Kernel;

namespace Mastermind_GUI.ViewModels
{
    public class GameVM : ViewModelBase
    {
        public GameVM(FJ.Interfaces.Factory factory, Game game)
        {
            Resolver = factory;            
            model = game;
        }

        public readonly Game model;

        FJ.Interfaces.Factory Resolver
        {
            get; set;
        }       

        public string Secret
        {
            get { return model.Secret; }
        }

        public int SecretLength
        {
            get { return model.SecretLength; }
            set { model.SecretLength = value; }
        }

        public int MaxGuesses
        {
            get { return model.MaxGuesses; }
            set { model.MaxGuesses = value; }
        }

        public string RowMatch
        {
            get { return model.RowMatch; }
        }

        private string match;
        public string Match
        {
            get { return model.Info(); }
            set { match = value; RaisePropertyChanged(); }
        }
    }
}
