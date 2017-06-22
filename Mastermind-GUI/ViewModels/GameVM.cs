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

namespace Mastermind_GUI.ViewModels
{
    public class GameVM : ViewModelBase
    {        
        public GameVM(FJ.Interfaces.Factory factory, Game game, UserGuess userGuess )
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
              
        public DataTable CreateTable(int RowCount)        {
            
            // --------------------------BindingList statt DataTable???
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Colour1", typeof(Brush));
            tbl.Columns.Add("Colour2", typeof(Brush));
            tbl.Columns.Add("Colour3", typeof(Brush));
            tbl.Columns.Add("Colour4", typeof(Brush));
            tbl.Columns.Add("Colour5", typeof(Brush));
            tbl.Columns.Add("Colour6", typeof(Brush));
            for (int i = 0; i < RowCount; i++) {
                tbl.Rows.Add(Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray);
            }
            return tbl;
        }

        
    }
}
