using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Kernel
{
    public class UserGuess
    {      
        
        public UserGuess()
        {
            matcher = new Matcher();
            var combination = GetColorRow();
            MakeUserGuessString(combination);
            
        }

        public Matcher matcher { get; }

        public string MakeUserGuessString(Brush[] brushes)
        {
            StringBuilder Builder = new StringBuilder();
            foreach (var brush in brushes) {
                if (brush == Brushes.Red) Builder.Append("1");
                if (brush == Brushes.Yellow) Builder.Append("2");
                if (brush == Brushes.Green) Builder.Append("3");
                if (brush == Brushes.Pink) Builder.Append("4");
                if (brush == Brushes.Blue) Builder.Append("5");
                if (brush == Brushes.LightBlue) Builder.Append("6");
            }

            matcher.UserInput(Builder.ToString());            
            return matcher.Match;
        }
        
        private Brush[] GetColorRow()
        {
            //List<Brushes> ColorRow = new List<Brushes>();
            //---------------------------------------------------Hart Gecodete Brush[]
            Brush[] brushes = new Brush[] { Brushes.Yellow, Brushes.Red, Brushes.Green, Brushes.Pink, Brushes.Blue, Brushes.LightBlue };
            return brushes;   
        }
    }
}
