using Mastermind_GUI.ViewModels;
using MasterMind_GUI;
using MasterMind_Kernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind_GUI.ViewModels
{
    public class GuessViewModel
    {
        private int GuessesCount = 0;

        public GuessViewModel(Guess guess,  Matcher matcher, Game game)
        {
            game_ = game;                     
            model = guess;
            matcher_ = matcher;
        }

        public Brush[] brushes = new Brush[] { Brushes.Red, Brushes.Yellow, Brushes.Green, Brushes.Pink, Brushes.Blue, Brushes.LightBlue };
        public BindingList<GuessViewModel> Guesses { get; set; }
        public Guess model { get; }
        public GameForm GameForm_ { get; private set; }
        public Matcher matcher_ { get; private set; }
        public GameVM GameVM_ { get; private set; }
        public Game game_ { get; private set; }
        public string Match { get; private set; }

        public void MakeGuess()
        {
            var colorRow = GetColorRow();
            if (colorRow.Contains(Brushes.LightGray)) return;
            MakeUserGuessString(colorRow);
           // var  row = GameForm_.
            //row[4] = GameVM_.Match;
            GuessesCount++;
        }

        private Brush[] GetColorRow()
        {
            var row = GameForm_.selectedRow;
            //var brushes = Guesses.  /*ItemArray.OfType<Brush>().ToArray();*/
            return null/*brushes*/;
        }

        public void MakeUserGuessString(Brush[] brushes)
        {
            StringBuilder Builder = new StringBuilder();
            foreach (var brush in brushes) {
                if (brush == Brushes.LightGray) Builder.Append("0");
                if (brush == Brushes.Red) Builder.Append("1");
                if (brush == Brushes.Yellow) Builder.Append("2");
                if (brush == Brushes.Green) Builder.Append("3");
                if (brush == Brushes.Pink) Builder.Append("4");
                if (brush == Brushes.Blue) Builder.Append("5");
                if (brush == Brushes.LightBlue) Builder.Append("6");
            }
            game_.UserInput(Builder.ToString());
            Match = game_.Info();

        }
    }
}
