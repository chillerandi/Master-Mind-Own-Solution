using MasterMind_Kernel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Mastermind_GUI.ViewModels
{
    public class GuessViewModel : ViewModelBase
    {
        public GuessViewModel()
        {
            GetEmptyTable();
        }

        public BindingList<RowViewModel> Guesses = new BindingList<RowViewModel>();
        private int GuessesCount = 0;
        public Brush[] brushes = new Brush[] { Brushes.Red, Brushes.Yellow, Brushes.Green, Brushes.Pink, Brushes.Blue, Brushes.LightBlue };
        
        public void GetEmptyTable()
        {
            for (int i = 0; i < 12; i++) Guesses.Add(new RowViewModel());            
        }

        public void MakeGuess(Game gameModel)
        {
            var colorRow = GetColorRow();
            if (colorRow.Contains(Brushes.LightGray)) return;
            MakeUserGuessString(colorRow, gameModel);
            Guesses[GuessesCount].Result = gameModel.Info();          
            GuessesCount++;
        }

        private Brush[] GetColorRow()
        {
            var current = Guesses[GuessesCount];
            return new[] { current.Column1, current.Column2, current.Column3, current.Column4 };
        }

        public void MakeUserGuessString(Brush[] brushes, Game gameModel)
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
            gameModel.UserInput(Builder.ToString());           
        }
    }
}
