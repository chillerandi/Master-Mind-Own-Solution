using System;
using System.Windows.Forms;
using MasterMind_Kernel;
using Ninject.Modules;
using Mastermind_GUI.ViewModels;

namespace MasterMind_GUI
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MessageBox.Show("Willkommen bei Andis Master-Mind-App!!\n\n" + "Bitte gib Deinen Tip ab und bestätige mit der Validate-Taste!\n" + "Eine 2 bedeutet einen Treffer an einer richtigen Stelle.\nEine 1 bedeutet eine richtige Zahl, aber an der falschen Stelle.\nEine 0 bedeutet daneben.\n"
                + "Viel Erfolg!");
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
                    Kernel.Bind<GuessViewModel>().ToSelf().InSingletonScope();
                   
                }
            }

            public Module()
            {
                Implementation_ = new Inner();
            }
        }
    }
}
