using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FJ;
using FJ.Interfaces;
using System.ComponentModel;

namespace Mastermind_GUI.ViewModels
{
    class UserGuessDisplayVM : ViewModelBase
    {
        public UserGuessDisplayVM(FJ.Interfaces.Factory factory, BindingList<UserGuessVM> guessList )
        {
            Guesses = guessList;
        }

        public BindingList<UserGuessVM> Guesses { get; set; }

    }
}
