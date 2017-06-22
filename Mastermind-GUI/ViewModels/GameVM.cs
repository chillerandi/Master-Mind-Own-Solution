using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FJ;
using FJ.Interfaces;
using System.Drawing;
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

        FJ.Interfaces.Factory Resolver
        {
            get; set;
        }

        private Game model;

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

        internal void addGuess()
        {
           
        }

        public string UserGuessString(Brush[] brushes)
        {            
            StringBuilder Builder = new StringBuilder(); 
            foreach(var brush in brushes) {
                if (brush == Brushes.Red) Builder.Append("1");
                if (brush == Brushes.Yellow) Builder.Append("2");
                if (brush == Brushes.Green) Builder.Append("3");
                if (brush == Brushes.Pink) Builder.Append("4");
                if (brush == Brushes.Blue) Builder.Append("5");
                if (brush == Brushes.LightBlue) Builder.Append("6");
            }
            
            model.UserInput(Builder.ToString());
            return model.Info();           
        }
    }
}
