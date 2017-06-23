using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MasterMind_Kernel;
using Ninject.Modules;
using Mastermind_GUI.ViewModels;
using FJ;
using FJ.Interfaces;

namespace MasterMind_GUI
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FJ.Factory.Instance.Get<GameForm>());            
        }

        public class Module : FJ.FactoryModule
        {
            class Inner : NinjectModule
            {
                public override void Load()
                {
                    // Alles was einen Status hat, muss in SingletonScope, alles was keinen Status hat, Kann, muss aber nicht in SS
                    Kernel.Bind<Game>().ToSelf().InSingletonScope();                    
                    Kernel.Bind<GameVM>().ToSelf().InSingletonScope();
                    Kernel.Bind<ViewModelBase>().ToSelf().InSingletonScope();
                    Kernel.Bind<GameForm>().ToSelf().InSingletonScope();   
                }
            }

            public Module()
            {
                Implementation_ = new Inner();
            }
        }
    }
}
