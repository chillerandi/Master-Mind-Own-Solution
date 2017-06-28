using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FJ;
using FJ.Interfaces;
using System.Drawing;
using MasterMind_Kernel;
using System.Data;
using System.Reflection;
using System.ComponentModel;


namespace Mastermind_GUI.ViewModels
{
    public class GameVM : ViewModelBase
    {
        public GameVM(/*FJ.Interfaces.Factory factory,*/ Game game, GuessViewModel guessesViewModel)
        {
            //Resolver = factory;
            guessesViewModel_ = guessesViewModel;
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


        public GuessViewModel guessesViewModel_ { get; private set; }

        public BindingList<GuessViewModel> UserGuesses { get { return guessesViewModel_.Guesses; } }

      
        //public DataTable table { get; private set; }
        //public DataTable CreateTable(int RowCount)
        //{
        //    // --------------------------BindingList statt DataTable???----------------------------------------
        //    DataTable tbl = new DataTable();
        //    tbl.Columns.Add("Colour1", typeof(Brush));
        //    tbl.Columns.Add("Colour2", typeof(Brush));
        //    tbl.Columns.Add("Colour3", typeof(Brush));
        //    tbl.Columns.Add("Colour4", typeof(Brush));
        //    tbl.Columns.Add("Score", typeof(String));

        //    for (int i = 0; i < RowCount; i++) {
        //        tbl.Rows.Add(Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, RowMatch );
        //    }
        //    table = tbl;
        //    return table;
        //}

        //public void MakeGuess()
        //{
        //    var colorRow = GetColorRow();
        //    if (colorRow.Contains(Brushes.LightGray)) return;
        //    MakeUserGuessString(colorRow);
        //    var row = table.Rows[GuessesCount];
        //    row[4] = Match;
        //    GuessesCount++;
        //}      

        private string match;
        public string Match
        {
            get { return model.Info(); }
            set { match = value; RaisePropertyChanged(); }
        }

        

        //private Brush[] GetColorRow()
        //{
        //    var row = table.Rows[GuessesCount];   
        //    var brushes = row.ItemArray.OfType<Brush>().ToArray();
        //    return brushes;
        //}

        //public void MakeUserGuessString(Brush[] brushes)
        //{
        //    StringBuilder Builder = new StringBuilder();
        //    foreach (var brush in brushes) {
        //        if (brush == Brushes.LightGray) Builder.Append("0");
        //        if (brush == Brushes.Red) Builder.Append("1");
        //        if (brush == Brushes.Yellow) Builder.Append("2");
        //        if (brush == Brushes.Green) Builder.Append("3");
        //        if (brush == Brushes.Pink) Builder.Append("4");
        //        if (brush == Brushes.Blue) Builder.Append("5");
        //        if (brush == Brushes.LightBlue) Builder.Append("6");
        //    }
        //    model.UserInput(Builder.ToString());
        //    Match = model.Info();

        //}

        // TODO : #############  Für die Ausgabe der Secret als Farbzeile aus dem String "Secret" ein Array aus Brushes machen
        //
        //public void MakeSecretToBrushArray()
        //{
        //    Brush[] SecretBrushMatch= new Brush[4];
        //    foreach(int secretInt in model.Secret)
        //    if(model.matcher.Secret. == "1") {}
        //}
    }
}
